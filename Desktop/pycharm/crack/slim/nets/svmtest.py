# -*- coding: utf-8 -*-
"""
Created on Wed Dec 19 11:24:40 2018

@author: Xiaoyin
"""
from sklearn.preprocessing import StandardScaler
import numpy as np
import tensorflow as tf
import train
from sklearn.externals import joblib
import os
model_path="E:\\zxtdeeplearning\\outputs-2.3.ckpt\\6-20000"


#img_path='E:\\zxtdeeplearning\\pic_source\\test_pic_1'
#img_path=input('input the path and the img name')
#img_path='E:\\zxtdeeplearning\\test_pic(dirt)'
#img_path='E:\\zxtdeeplearning\\pic_source\\dirty'
#img_path='E:\\zxtdeeplearning\\test_pic'
img_path='E:\\zxtdeeplearning\\test_pic_misty'
#img_path="E:\\zxtdeeplearning\\test_pic_formal"
logits_outputs_path='E:\\zxtdeeplearning\\svm_train_data\\dataset_test.txt'

#我意外发现你的test_pic的string不能包含中文字符，不然会报-215Asseration
#注意，测试集不能太多，否则gtx1080也会炸，batch几十都ok（2353：->oom）


def accuracy_cnn(predicted_label,labels):
    a=predicted_label-labels
    t=0
    for i in range(len(a)):
        if a[i] !=0:
            t+=1
    return 1-t/len(a)                   
def ave(mum):
    total=0
    for i in range(len(mum)):
        total=total+mum[i]
    return total/len(mum)
def accuracy_svm(t):
    a=0
    for i in range(len(t)):
        if t[i]==1:
            a+=1
    return a/len(t)
def svm(predicted_logits,logits_outputs_path):
    f=open(logits_outputs_path,'a')#用于给svm提供txt
    for i in range(len(predicted_logits)):
        np.savetxt(f, predicted_logits[i])   
    f.close()
    dataset_1=np.loadtxt(r"E:\zxtdeeplearning\svm_train_data\dataset_test.txt")
    x=np.linspace(0,len(predicted_logits)*2-2,len(predicted_logits))
    y=np.linspace(1,len(predicted_logits)*2-1,len(predicted_logits))
    data1=[]
    data11=[]
    for i in x:
        i=int(i)
        data1.append(dataset_1[i])
    for i in y:
        i=int(i)
        data11.append(dataset_1[i])  
    dataset=np.c_[data1,data11]
    dataset= StandardScaler().fit_transform(dataset)
    clf=joblib.load(r'E:\zxtdeeplearning\svc.pkl')
    result=clf.predict(dataset)
    os.remove("E:\zxtdeeplearning\svm_train_data\dataset_test.txt")  
    return result
def main(_):
    
    images,labels=train.get_train_data(img_path)
    
    with tf.Session() as sess:
        ckpt_path = model_path
        saver = tf.train.import_meta_graph(ckpt_path + '.meta')
        saver.restore(sess, ckpt_path)
        
        inputs = tf.get_default_graph().get_tensor_by_name('inputs:0')
        
        classes = tf.get_default_graph().get_tensor_by_name('classes:0')
        
        logits = tf.get_default_graph().get_tensor_by_name('logits:0')#logits

        predicted_label = sess.run(classes, feed_dict={inputs: images})
        predicted_logits=sess.run(logits, feed_dict={inputs: images})
        '''
        predicted_label_list=[]
        
        predicted_logits_list=[]
        
        a,b=0,9
        
        for i in range(int(len(images)/10)):
            
            image_batch=datawriter.get_batch(images,a,b)
                                 
            a,b=(a+10),(b+10)
            
            predicted_logits=sess.run(logits, feed_dict={inputs: image_batch})

            predicted_label = sess.run(classes, feed_dict={inputs: image_batch})

            for j in range(len(predicted_label)):
                predicted_label_list.append(predicted_label[j])
                
                predicted_logits_list.append(predicted_logits[j])'''
        print(svm(predicted_logits,logits_outputs_path))
        print(accuracy_svm(svm(predicted_logits,logits_outputs_path)))            
        print(predicted_label)
        
if __name__ == '__main__':
    tf.app.run()

