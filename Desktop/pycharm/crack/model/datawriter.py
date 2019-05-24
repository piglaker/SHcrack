# -*- coding: utf-8 -*-
"""
Created on Mon Dec 17 18:01:12 2018

@author: Xiaoyin
"""

import numpy as np
import tensorflow as tf
import rawtrain

model_path="E:\\zxtdeeplearning\\outputs-2.3.ckpt\\6-20000"

#其实也不需要，那天给他穿数据用了一下，用处是吧image_path的图片输入把logits写入txt 


#img_path='E:\\zxtdeeplearning\\train_reason_svm'
img_path='E:\\zxtdeeplearning\\train_misty_svm'


def get_batch(images,a,b):
    image_batch = images[a:b+1]
    return image_batch



def main(_):    
    images,labels=rawtrain.get_train_data(img_path)    
    #f=open('E:\\zxtdeeplearning\\svm_train_data\\dataset1.txt','a')
    f=open('E:\\zxtdeeplearning\\svm_train_data\\dataset_0.txt','a')    
    with tf.Session() as sess:
        ckpt_path = model_path        
        saver = tf.train.import_meta_graph(ckpt_path + '.meta')
        saver.restore(sess, ckpt_path)        
        inputs = tf.get_default_graph().get_tensor_by_name('inputs:0')                
        logits = tf.get_default_graph().get_tensor_by_name('logits:0')#logits
        a,b=0,19        
        for i in range(int(len(images)/20)):            
            image_batch=get_batch(images,a,b)            
            a,b=(a+20),(b+20)            
            predicted_logits=sess.run(logits, feed_dict={inputs: image_batch})                        
            print(predicted_logits)                          
            for i in range(len(predicted_logits)):
                np.savetxt(f, predicted_logits[i])                                          
    f.close()
        
if __name__ == '__main__':
    tf.app.run()

