# -*- coding: utf-8 -*-
"""
Created on Fri Jan 11 11:45:05 2019

@author: Xiaoyin
"""

from sklearn.preprocessing import StandardScaler
import os
import numpy as np
import tensorflow as tf
import train
from sklearn.externals import joblib
model_path="E:\\zxtdeeplearning\\outputs-2.3.ckpt\\6-20000"



def main(_):
    img_path = input('Input the path (you hava to put the test_pic in a file):')    
    images,labels=train.get_train_data(img_path)    
    with tf.Session() as sess:
        ckpt_path = model_path
        saver = tf.train.import_meta_graph(ckpt_path + '.meta')
        saver.restore(sess, ckpt_path)       
        inputs = tf.get_default_graph().get_tensor_by_name('inputs:0')       
        classes = tf.get_default_graph().get_tensor_by_name('classes:0')           
        predicted_label = sess.run(classes, feed_dict={inputs: images})      
        
        print(predicted_label)                                               
        if predicted_label==0:
            print("图中衣服为羽绒服 !")
        else :
            print("图中衣服为短袖 !")
            
        
        
if __name__ == '__main__':
    tf.app.run()