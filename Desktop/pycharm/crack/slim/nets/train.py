# -*- coding: utf-8 -*-
"""
Created on Wed Dec 12 19:52:50 2018

@author: zhang
"""

import cv2
import glob
import numpy as np
import os
import tensorflow as tf
import model
import matplotlib.pyplot as plt

flags = tf.app.flags

#flags.DEFINE_string('images_path','E:\\zxtdeeplearning\\images_path','Path to training images.')
#flags.DEFINE_string('model_output_path','E:\\zxtdeeplearning\\outputs', 'Path to model checkpoint.')
#FLAGS = flags.FLAGS
images_path='E:\\zxtdeeplearning\\images_path'

MODEL_SAVE_PATH='E:\\zxtdeeplearning\\outputs-2.3.ckpt'
Learning_RATE=0.001
STEPS=20000
MODEL_NAME='6'

def get_train_data(images_path):
    if not os.path.exists(images_path):
        raise ValueError('images_path is not exist.')    
    images = []
    labels = []
    images_path = os.path.join(images_path, '*.jpg')
    count = 0
    for image_file in glob.glob(images_path):
        count += 1
        if count % 100 == 0:
            print('Load {} images.'.format(count))
        image = cv2.imread(image_file)
        image = cv2.resize(image,(220,220),interpolation=cv2.INTER_CUBIC)
        image = cv2.cvtColor(image, cv2.COLOR_BGR2RGB)
        # Assume the name of each image is imagexxx@label$.jpg
        label = int(image_file.split('@')[-1].split('$')[0])#trick
        images.append(image)
        labels.append(label)
    images = np.array(images)
    labels = np.array(labels)
    return images, labels
    #np.ndarray [all,length,wideth,channel]  labels: np.ndarray one dimension tensor 



def next_batch_set(images, labels, batch_size=60):
    indices = np.random.choice(len(images), batch_size)
    batch_images = images[indices]
    batch_labels = labels[indices]
    return batch_images, batch_labels
    #随机取

def main(_):
    inputs = tf.placeholder(tf.float32, shape=[None, 220, 220, 3], name='inputs')
    labels = tf.placeholder(tf.int32, shape=[None], name='labels')   
    cls_model = model.Model(is_training=True, num_classes=2)   
    preprocessed_inputs = cls_model.preprocess(inputs)#inputs预处理   
    prediction_dict = cls_model.predict(preprocessed_inputs)#predict  （forward）  
    postprocessed_logits=cls_model.postprocess_logits(prediction_dict)#后处理   
    logits=postprocessed_logits['logits']#    
    logits_ = tf.identity(logits,name='logits')#用于测试（necessary）   
    loss_dict = cls_model.loss(prediction_dict, labels)   
    loss = loss_dict['loss']           
    postprocessed_dict = cls_model.postprocess_classes(prediction_dict)    
    classes = postprocessed_dict['classes']    
    classes_ = tf.identity(classes, name='classes')#用于测试（necessary）    
    acc = tf.reduce_mean(tf.cast(tf.equal(classes, labels), 'float'))    
    global_step = tf.Variable(0, trainable=False)   
    learning_rate = tf.train.exponential_decay(Learning_RATE, global_step, 150, 0.99)#指数衰减学习率   
    optimizer = tf.train.MomentumOptimizer(learning_rate, 0.99)#优化器   
    train_step = optimizer.minimize(loss, global_step)   
    saver = tf.train.Saver()    
    images, targets = get_train_data(images_path)#获取训练images labels （np.ndarray）    
    init = tf.global_variables_initializer()
    loss_graph=[]    
    x=[]    
    with tf.Session() as sess:
        sess.run(init)
        writer=tf.summary.FileWriter("E:\\zxtdeeplearning\\tensorboard\\3",sess.graph)#tensorboard绘图
        #打开tensorboard：anaconda navigator->open terminal ->cd logdir -> tensorboard --logdir=....-> ...                
        ckpt=tf.train.get_checkpoint_state(MODEL_SAVE_PATH)
        if ckpt and ckpt.model_checkpoint_path:
            saver.restore(sess,ckpt.model_checkpoint_path)                      
        for i in range(STEPS):
            batch_images, batch_labels = next_batch_set(images, targets)
            train_dict = {inputs: batch_images, labels: batch_labels}            
            sess.run(train_step, feed_dict=train_dict)                                  
            loss_, acc_ = sess.run([loss, acc], feed_dict=train_dict)           
            train_text = 'step: {}, loss: {}, acc: {}'.format(
                i+1, loss_, acc_)
            loss_graph.append(loss_)
            x.append(i)
            print(train_text)            
        writer=tf.summary.FileWriter("E:\\zxtdeeplearning\\tensorboard\\1",sess.graph)    
        saver.save(sess,os.path.join(MODEL_SAVE_PATH,MODEL_NAME),global_step=global_step)
    writer.close()
    plt.figure()
    plt.plot(x,loss_graph)
    plt.show()    
if __name__ == '__main__':
    tf.app.run()



