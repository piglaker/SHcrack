# -*- coding: utf-8 -*-
"""
Created on Thu Mar 21 08:06:59 2019

@author: Xiaoyin
"""

import numpy as np
import cv2
import glob
import utils
import os
normal_size=224

images_path='./predictions/images/'
image_path='./predictions/prediction.jpg'
area_path='./predictions/area.txt'

def draw_map(a,b,image,images):   
    for i in range(a,a+normal_size,1):
        for j in range(b,b+normal_size,1):
            #print(a,b,i,j)
            if images[i-a][j-b]>=20:
                image[i][j][0]=255
                image[i][j][1]=255
                image[i][j][2]=0
            
    return image


area=np.loadtxt(area_path)
images=[]

images_path = os.path.join(images_path, '*.jpg')

for image_file in glob.glob(images_path):
    img = cv2.imread(image_file,0)
    #img = cv2.resize(img,(224,224),interpolation=cv2.INTER_CUBIC)
    #img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    #print(img)
    img=utils.gradient(img)
    images.append(img)

image=cv2.imread(image_path)

n=len(area)

#print(images)

count=0

for i in range(len(area)):
    for j in range(len(area[i])):
        if area[i][j]==1:
            image=draw_map(i*normal_size,j*normal_size,image,images[count])     
            count+=1
        
cv2.imwrite('./predictions/t.jpg',image)



   
'''
images='./predictions/images/crack_4_29.jpg'
img = cv2.imread(images,0)
#img = cv2.resize(img,(224,224),interpolation=cv2.INTER_CUBIC)
#img=np.array(img)
#img=img.astype(np.uint8)
#img = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
img=utils.gradient(img)


print(img)

image=cv2.imread(image_path)


image=draw_map(0,5*224,image,img)

cv2.imwrite('./predictions/t.jpg',image)

'''
    
