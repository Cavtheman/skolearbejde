import cv2
import numpy as np

def gridify (img, grid_size, intensity, offset_x=0, offset_y=0):
    '''
    A function that takes an image and adds grid lines on top.

    Parameters:
    -----------
    img : np.ndarray
        The input image. Can be any size, including in the color channel.

    grid_size : int
        The size, in pixels, of each individual square

    intensity : float
        Determines how bright/dark the grid lines should be.
        Uses values between -1 and 1, and larger inputs will simply be squished to those.
        -1 is black, 1 is white.

    offset_x : int
        How much the grid should be offset, in pixels, on the x axis

    offset_y : int
        How much the grid should be offset, in pixels, on the y axis

    Returns:
    -----------
    norm_img : np.ndarray
        The image, now with grid lines.
    '''

    img = np.asarray(img)
    grid_pixel = [intensity] * img.shape[2]

    no_vert = np.array([ grid_pixel if (x + offset_x) % grid_size == 0 else [0,0,0] for x in range(img.shape[1]) ])
    vertical = np.array(([grid_pixel] * img.shape[1]))
    grid = np.array([ vertical if (y + offset_y) % grid_size == 0 else no_vert for y in range(img.shape[0]) ])

    if np.any(np.where(img > 1, True, False)):
        img = img/255

    overunderflow_img = img + grid
    norm_img = np.where(overunderflow_img > 1, 1, overunderflow_img)
    norm_img = np.where(norm_img < 0, 0, norm_img)
    return norm_img
