# -*- coding: utf-8 -*-
"""
Created on Fri Feb 15 22:25:55 2019

@author: zhang
"""

import cv2
import numpy as np
moon=cv2.imread(r'E:\Desktop\JRBMpy\expriments\pic2\2.27\pic (2).jpg',0)
#moon = cv2.imread(r'E:\Desktop\JRBMpy\expriments\pic2\0.jpg', 0)
#moon = cv2.imread(r'D:\MATLAB\R2017a\bin\I1.jpg', 0)
#moon = cv2.imread(r'E:\Desktop\JRBMpy\blur_img_0.jpg', 0)

row, column = moon.shape
moon_f = np.copy(moon)
moon_f = moon_f.astype("float")

gradient = np.zeros((row, column))

for x in range(row - 1):
    for y in range(column - 1):
        gx = abs(moon_f[x + 1, y] - moon_f[x, y])
        gy = abs(moon_f[x, y + 1] - moon_f[x, y])
        gradient[x, y] = gx + gy

sharp = moon_f + gradient
sharp = np.where(sharp < 0, 0, np.where(sharp > 255, 255, sharp))

gradient = gradient.astype("uint8")
sharp = sharp.astype("uint8")
#cv2.imshow("moon", 0)
#cv2.imshow("gradient", gradient)

cv2.imwrite("gradient_img_1.jpg",gradient)
#cv2.imwrite("gradient_img_0.jpg",gradient)

#cv2.imshow("sharp", sharp)



