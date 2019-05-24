# -*- coding: utf-8 -*-
"""
Created on Mon Dec 17 15:24:09 2018

@author: Xiaoyin
"""

import tensorflow as tf  

from tensorflow.examples.tutorials.mnist import input_data  

  

#载入数据集  

mnist = input_data.read_data_sets("MNIST_data",one_hot=True)  

  

#每个批次的大小和总共有多少个批次  

batch_size = 100  

n_batch = mnist.train.num_examples // batch_size  

 

#定义函数

def variable_summaries(var):

    with tf.name_scope('summaries'):

        mean = tf.reduce_mean(var)

        tf.summary.scalar('mean', mean) #平均值

        with tf.name_scope('stddev'):

            stddev = tf.sqrt(tf.reduce_mean(tf.square(var-mean)))

        tf.summary.scalar('stddev', stddev) #标准差

        tf.summary.scalar('max', tf.reduce_max(var))

        tf.summary.scalar('min', tf.reduce_min(var))

        tf.summary.histogram('histogram', var) #直方图

        

#命名空间

with tf.name_scope("input"):

    #定义两个placeholder  

    x = tf.placeholder(tf.float32,[None,784], name = "x_input")  

    y = tf.placeholder(tf.float32,[None,10], name = "y_input")  

  

with tf.name_scope("layer"):

    #创建一个简单的神经网络 

    with tf.name_scope('weights'):

        W = tf.Variable(tf.zeros([784,10]), name='W') 

        variable_summaries(W)

    with tf.name_scope('biases'):    

        b = tf.Variable(tf.zeros([10]), name='b') 

        variable_summaries(b)

    with tf.name_scope('wx_plus_b'):  

        wx_plus_b = tf.matmul(x,W)+b

    with tf.name_scope('softmax'):

        prediction = tf.nn.softmax(wx_plus_b)  

 

with tf.name_scope('loss'):

    #交叉熵代价函数 

    loss = tf.reduce_mean(tf.nn.softmax_cross_entropy_with_logits(labels=y, logits=prediction))  

    tf.summary.scalar('loss', loss)

with tf.name_scope('train'):

    #使用梯度下降法 

    train_step = tf.train.GradientDescentOptimizer(0.2).minimize(loss)  

  

#初始化变量  

init = tf.global_variables_initializer()  

 

with tf.name_scope('accuracy'):

    with tf.name_scope('correct_prediction'):

        #结果存放在一个布尔型列表中  

        correct_prediction = tf.equal(tf.argmax(y,1),tf.argmax(prediction,1))#argmax返回一维张量中最大的值所在的位置  

    with tf.name_scope('accuracy'):

        #求准确率  

        accuracy = tf.reduce_mean(tf.cast(correct_prediction,tf.float32))  

        tf.summary.scalar('accuracy', accuracy)

 

#合并所有的summary

merged = tf.summary.merge_all()

 

with tf.Session() as sess:  

    sess.run(init)  

    writer = tf.summary.FileWriter("log/", sess.graph) #写入到的位置

    for epoch in range(51):  

        for batch in range(n_batch):  

            batch_xs,batch_ys =  mnist.train.next_batch(batch_size)  

            summary,_ = sess.run([merged,train_step],feed_dict={x:batch_xs, y:batch_ys})  

        

        writer.add_summary(summary,epoch)  

        acc = sess.run(accuracy,feed_dict={x:mnist.test.images,y:mnist.test.labels})  

        print("epoch " + str(epoch)+ "   acc " +str(acc)) 
