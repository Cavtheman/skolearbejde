import numpy as np
import matplotlib.pyplot as plt


def read_mnist_csv (filename):
    raw = np.genfromtxt (filename, delimiter=",")
    return raw[1:]

def group_by_label (data):
    labels = data[:,0]
    data = data[:,1:]
    return [ data[np.where (labels == i)] for i in range (len (np.unique (labels))) ]

def convert_to_images (data):
    return [ elem.reshape (-1,28,28) for elem in data ]

def draw_image (img_arr):
    plt.axis("off")
    plt.imshow(img_arr, cmap="gray")

def draw_image_row (img_arr_list):
    fig, axs = plt.subplots (1, len (img_arr_list))

    for i in range (len (img_arr_list)):
        axs[i].imshow(img_arr_list[i][0], cmap="gray")

        axs[i].xaxis.set_visible(False)
        axs[i].yaxis.set_visible(False)

def calc_group_averages (img_arr_list):
    return [ np.average (elem, axis=0).reshape(-1,28,28) for elem in img_arr_list ]
