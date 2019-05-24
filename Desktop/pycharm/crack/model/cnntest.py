# -*- coding: utf-8 -*-
"""
Created on Sat Dec 15 12:56:06 2018

@author: Xiaoyin
"""



import tensorflow as tf
import rawtrain
import datawriter

slim = tf.contrib.slim
    
#model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-0.ckpt\\0-81600"#99.26
#model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-1.ckpt\\0-51600"#99.3
#model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-2.ckpt\\0-1050"#98.56
model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-3.ckpt\\0-7000"#99.48
#model_path="E:\\zxtdeeplearning\\crack\\model\\ecs\\0-3500"#99.34

#model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-2.ckpt\\1-3550"

img_path="E:\\zxtdeeplearning\\crack\\test_2"

#我意外发现你的test_pic的string不能包含中文字符，不然会报-215Asseration
#注意，测试集不能太多，否则gtx1080也会炸，batch几十都ok（2353：->oom）
foot=10
def accuracy(predicted_label,labels):
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


def main(_):    
    images,labels=rawtrain.get_train_data(img_path)    
    with tf.Session() as sess:
        ckpt_path = model_path
        saver = tf.train.import_meta_graph(ckpt_path + '.meta')
        saver.restore(sess, ckpt_path)       
        inputs = tf.get_default_graph().get_tensor_by_name('inputs:0')       
        classes = tf.get_default_graph().get_tensor_by_name('classes:0')        
        logits = tf.get_default_graph().get_tensor_by_name('logits:0')#logits
        #fc1 = slim.get_variables(scope="fc1")

        predicted_label_list=[]        
        predicted_logits_list=[]        
        a,b=0,9        
        for i in range(int(len(images)/foot)):            
            image_batch=datawriter.get_batch(images,a,b)                                 
            a,b=(a+foot),(b+foot)            
            predicted_logits=sess.run(logits, feed_dict={inputs: image_batch})
            predicted_label = sess.run(classes, feed_dict={inputs: image_batch})
            for j in range(len(predicted_label)):
                predicted_label_list.append(predicted_label[j])                
                predicted_logits_list.append(predicted_logits[j])                 
        for i in range(len(predicted_logits)):
            predicted_logits[i][0],predicted_logits[i][1]=predicted_logits[i][0],predicted_logits[i][1]                        
        for i in range(len(labels)):           
            print("fact:",labels[i],' ',"predict:",predicted_label_list[i],' ','logits:',predicted_logits_list[i])            

        print(accuracy(predicted_label_list,labels))
        
        
if __name__ == '__main__':
    tf.app.run()



          