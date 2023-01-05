import cv2
import numpy as np
import matplotlib.pyplot as plt
from scipy.fft import fft2, ifft2, fftshift
from data_generator import *
from torch.utils import data
from einops import *

def plot_spectrum (spectrum, filename, title):
    x_vals = np.linspace (0, 255, spectrum.shape[1])
    y_vals = np.linspace (0, 255, spectrum.shape[0])
    X, Y = np.meshgrid (x_vals, y_vals)
    Z = np.log (1 + abs (fftshift (spectrum)))

    print (X.shape, Y.shape, Z.shape)

    for i in range (Z.shape[2]):
        fig = plt.figure ()
        plot = plt.contourf (X, Y, Z[:,:,i], cmap="gray")
        plt.title (title)
        fig.colorbar (plot)
        fig.savefig (filename + f"{i}.png")



if __name__ == "__main__":

    #path = "~/skolearbejde/degridifier/data/train/nogrid/"
    path = "../../degridifier/data/train/nogrid/"
    augments = {"grid_size" : (30,90),
            "grid_intensity" : (-1,1),
            "grid_offset_x" : (0,90),
            "grid_offset_y" : (0,90),
            "crop" : (400,400),
            "hflip" : 0.5,
            "vflip" : 0.5,
            "angle" : 0,
            "shear" : 0,
            "brightness" : (0.75,1.25),
            "pad" : (0,0,0,0),
            "contrast" : (0.5,1.25)}
    dataset = ArtificialDataset (1000, path, **augments)
    loader = data.DataLoader (dataset, shuffle=True)
    print (len (loader))
    for elem in loader:
        print (elem["grid"].shape)
        grid = rearrange (elem["grid"], "() a b c -> b c a")
        nogrid = rearrange (elem["nogrid"], "() a b c -> b c a")
        print (grid.shape)
        print (elem["grid"].squeeze(0).transpose(2,0).shape)
        grid_spect = fft2 (grid.detach().numpy(), axes=(0,1))
        nogrid_spect = fft2 (nogrid.detach().numpy(), axes=(0,1))
        plot_spectrum (grid_spect, "grid_spect", "Spectrum of image")
        plot_spectrum (nogrid_spect, "nogrid_spect", "Spectrum of image")
        break
        #plt.axis("off")
        #plt.imshow (test)
        #plt.show()
