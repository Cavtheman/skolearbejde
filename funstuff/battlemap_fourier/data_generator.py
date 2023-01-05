import torch
import torch.nn.functional as F
from torch.utils import data
import torchvision.transforms.functional as TF
from torchvision.transforms import ToTensor
import random
from os import walk

from gridifier import *

from PIL import Image


# Data consists of artificially gridded images, labels are the ungridded originals
class ArtificialDataset(data.Dataset):

    # Lists all files in the directory, including those in folders
    def __get_all_files__(self, path):
        if not path[-1] == "/":
            path = path+"/"

        (_, sub_folders, filenames) = next(walk(path))
        filenames = [ path + elem for elem in filenames ]

        if sub_folders:
            sub_filenames = [ self.get_all_files (path + elem) for elem in sub_folders ]
            sub_filenames = [ item for sublist in sub_filenames for item in sublist ]
            filenames.extend (sub_filenames)

        return filenames

    def __init__(self, max_imgs, base_path, grid_size, grid_intensity, grid_offset_x, grid_offset_y, crop=None, hflip=None, vflip=None, angle=0, shear=0, brightness=1, pad=(0,0,0,0), contrast=1, use_channel=None, seed=None):

        self.data_paths = self.__get_all_files__(base_path)[:max_imgs]
        self.grid_size = grid_size
        self.grid_intensity = grid_intensity
        self.grid_offset_x = grid_offset_x
        self.grid_offset_y = grid_offset_y
        self.crop = crop
        self.hflip = hflip
        self.vflip = vflip
        self.angle = angle
        self.shear = shear
        self.brightness = brightness
        self.pad = pad
        self.contrast = contrast
        self.use_channel = use_channel
        self.seed = seed
        if seed:
            #print ("setting seed:", self.seed)
            random.seed(seed)
            torch.manual_seed(seed)
            torch.cuda.manual_seed(seed)

    def __augment_data__(self, labels, grid_size, grid_intensity, grid_offset_x, grid_offset_y, crop, hflip, vflip, angle, shear, brightness, pad, contrast, use_channel):



        grid_size = random.randint(grid_size[0], grid_size[1])
        grid_intensity = random.uniform(grid_intensity[0], grid_intensity[1])
        grid_offset_x = random.randint(grid_offset_x[0], grid_offset_x[1])
        grid_offset_y = random.randint(grid_offset_y[0], grid_offset_y[1])

        # Cropping
        if crop != (0,0):
            w, h = labels.size
            top = random.randint(0,w-crop[0])
            left = random.randint(0,h-crop[1])
            labels = TF.crop (labels, top, left, crop[0], crop[1])

        # Gridifying
        data = Image.fromarray(np.uint8(gridify(labels, grid_size, grid_intensity, grid_offset_x, grid_offset_y) * 255))
        #data = deepcopy(labels)

        # Flipping the image horizontally
        if hflip and random.random() > hflip:
            data = TF.hflip(data)
            labels = TF.hflip(labels)

        # Flipping the image vertically
        if vflip and random.random() > vflip:
            data = TF.vflip(data)
            labels = TF.vflip(labels)

        # Adjusts the brightness randomly
        if type(brightness) is tuple:
            brightness = random.uniform(brightness[0], brightness[1])

        # Rotates image randomly
        if type(angle) is tuple:
            angle = random.randint(angle[0], angle[1])

        # Shears image randomly
        if type(shear) is tuple:
            shear = random.uniform(shear[0], shear[1])

        if type(contrast) is tuple:
            contrast = random.uniform(contrast[0], contrast[1])

        data = TF.adjust_contrast(data, contrast)
        labels = TF.adjust_contrast(labels, contrast)

        data = TF.adjust_brightness(data, brightness)
        labels = TF.adjust_brightness(labels, brightness)

        data = TF.affine(data, angle, (0,0), 1, shear)
        labels = TF.affine(labels, angle, (0,0), 1, shear)

        data = F.pad(ToTensor()(data), pad)
        labels = F.pad(ToTensor()(labels), pad)

        if use_channel:
            data = torch.narrow(data, 0, use_channel, 1)

        return data, labels


    def __len__(self):
        return len(self.data_paths)

    def __getitem__(self, index):
        # Generates one sample of data
        temp = Image.open (self.data_paths[index]).convert("RGB")

        # Augment the data and labels randomly using given arguments
        data, labels = self.__augment_data__(temp, self.grid_size, self.grid_intensity, self.grid_offset_x, self.grid_offset_y, self.crop, self.hflip, self.vflip, self.angle, self.shear, self.brightness, self.pad, self.contrast, self.use_channel)
        temp.close()
        #return data, labels
        return { "grid" : data, "nogrid" : labels }



# Data should load one gridded and one ungridded image in
class CombinedDataset(data.Dataset):

    # Lists all files in the directory, including those in folders
    def __get_all_files__(self, path):
        if not path[-1] == "/":
            path = path+"/"

        (_, sub_folders, filenames) = next(walk(path))
        filenames = [ path + elem for elem in filenames ]

        if sub_folders:
            sub_filenames = [ self.get_all_files (path + elem) for elem in sub_folders ]
            sub_filenames = [ item for sublist in sub_filenames for item in sublist ]
            filenames.extend (sub_filenames)

        return filenames

    def __init__(self, max_imgs, grid_path, nogrid_path, crop=None, hflip=None, vflip=None, angle=0, shear=0, brightness=1, pad=(0,0,0,0), contrast=1, use_channel=None, seed=None):

        if seed:
            #print ("setting seed:", self.seed)
            random.seed(seed)
            torch.manual_seed(seed)
            torch.cuda.manual_seed(seed)

        self.grid_paths = self.__get_all_files__(grid_path)
        self.nogrid_paths = self.__get_all_files__(nogrid_path)

        #self.data_paths = [ elem[1] for elem in combined_paths ]

        self.crop = crop
        self.hflip = hflip
        self.vflip = vflip
        self.angle = angle
        self.shear = shear
        self.brightness = brightness
        self.pad = pad
        self.contrast = contrast
        self.use_channel = use_channel
        self.seed = seed
        self.max_imgs = max_imgs

    def __augment_data__(self, data):

        # Cropping
        if self.crop != (0,0):
            w, h = data.size
            top = random.randint(0,w-self.crop[0])
            left = random.randint(0,h-self.crop[1])
            data = TF.crop (data, top, left, self.crop[0], self.crop[1])

        # Flipping the image horizontally
        if self.hflip and random.random() > self.hflip:
            data = TF.hflip(data)

        # Flipping the image vertically
        if self.vflip and random.random() > self.vflip:
            data = TF.vflip(data)

        # Adjusts the brightness randomly
        if type(self.brightness) is tuple:
            brightness = random.uniform(self.brightness[0], self.brightness[1])
        else:
            brightness = 1

        # Rotates image randomly
        if type(self.angle) is tuple:
            angle = random.randint(self.angle[0], self.angle[1])
        else:
            angle = 0

        # Shears image randomly
        if type(self.shear) is tuple:
            shear = random.uniform(self.shear[0], self.shear[1])
        else:
            shear = 0

        if type(self.contrast) is tuple:
            contrast = random.uniform(self.contrast[0], self.contrast[1])
        else:
            contrast = 1

        data = TF.adjust_contrast(data, contrast)

        data = TF.adjust_brightness(data, brightness)

        data = TF.affine(data, angle, (0,0), 1, shear)

        data = F.pad(ToTensor()(data), self.pad)

        if self.use_channel:
            data = torch.narrow(data, 0, self.use_channel, 1)

        return data


    def __len__(self):
        return min (len(self.grid_paths), len(self.nogrid_paths), self.max_imgs)

    def __getitem__(self, index):
        temp_grid = Image.open (self.grid_paths[index]).convert("RGB")
        grid = self.__augment_data__(temp_grid)
        temp_grid.close()

        temp_nogrid = Image.open (self.nogrid_paths[index]).convert("RGB")
        nogrid = self.__augment_data__(temp_nogrid)
        temp_nogrid.close()

        #return data.float(), label.float()
        return { "grid" : grid, "nogrid" : nogrid }

#no_grid = "data/train/nogrid"
#art_no_grid = "data/artificial_val"
#test = CombinedDataset(10, no_grid, art_no_grid)
