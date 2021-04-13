from mnist import *
import numpy as np
import matplotlib.pyplot as plt


raw_data = read_mnist_csv ("mnist_test_200.csv")
print (raw_data.shape)

grouped_data = group_by_label (raw_data)
#for elem in grouped_data:
#    print (elem.shape)

img_data = convert_to_images (grouped_data)
#for elem in img_data:
#    print (elem.shape)

draw_image (img_data[0][0])
plt.show()

draw_image_row (img_data)
plt.show()

avg_imgs = calc_group_averages (img_data)
draw_image_row (avg_imgs)
plt.show()
