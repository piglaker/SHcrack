# -*- coding: utf-8 -*-
"""
Created on Sun Dec 16 15:36:14 2018

@author: Xiaoyin
"""


import glob
import os
import tensorflow as tf
import cv2


#用于数据清洗
#一般不需要，当你导入图片的时候总是很灵异的报错的时候建议你试一下这个包治百病

def main(_):
    
    #images_path='E:\\zxtdeeplearning\\images_path'
    #images_path='E:\\zxtdeeplearning\\pic_source\\dirty'
    images_path='E:\\zxtdeeplearning\\pic_source\\test_pic_0'
    if not os.path.exists(images_path):
        raise ValueError('images_path is not exist.')        
    images_path = os.path.join(images_path, '*.jpg')
    count = 0
    waste=0    
    for image_file in glob.glob(images_path):
        count += 1
        print(image_file)
        try:
            image = cv2.imread(image_file)    
            image = cv2.resize(image,(220,220),interpolation=cv2.INTER_CUBIC)
            image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)           
        except :
            os.remove(image_file)#直接删了
            waste+=1   
    print(waste)#报告图片异常
if __name__ == '__main__':
    tf.app.run()

