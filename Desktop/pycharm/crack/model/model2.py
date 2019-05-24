# -*- coding: utf-8 -*-
"""
Created on Wed Dec 12 19:52:31 2018

@author: zhang
"""

import tensorflow as tf

slim = tf.contrib.slim
    
        
class Model(object):
    def __init__(self,
                 is_training,
                 num_classes):
        self._num_classes = num_classes
        self._is_training = is_training

    def num_classes(self):
        return self._num_classes          

    def preprocess(self, inputs):
        preprocessed_inputs = tf.to_float(inputs)
        preprocessed_inputs = tf.subtract(preprocessed_inputs, 128.0)
        preprocessed_inputs = tf.div(preprocessed_inputs, 128.0)
        return preprocessed_inputs   

    def predict(self, preprocessed_inputs):
        with slim.arg_scope([slim.conv2d, slim.fully_connected],
                            activation_fn=tf.nn.relu):
            net = preprocessed_inputs
            net = slim.repeat(net, 2, slim.conv2d, 32, [3, 3], scope='conv1')
            net = slim.max_pool2d(net, [2, 2], scope='pool1')
            
            net = slim.repeat(net, 2, slim.conv2d, 64, [3, 3], scope='conv2')
            net = slim.max_pool2d(net, [2, 2], scope='pool2')
            
            net = slim.repeat(net, 2, slim.conv2d, 128, [3, 3], scope='conv3')
            net = slim.max_pool2d(net, [2, 2], scope='pool3')
            
            net = slim.repeat(net, 2, slim.conv2d, 256, [3, 3], scope='conv4')
            net = slim.max_pool2d(net, [2, 2], scope='pool4')
            
            net = slim.flatten(net, scope='flatten')
            net = slim.dropout(net, keep_prob=0.5, 
                               is_training=self._is_training)
            net = slim.fully_connected(net, 512, scope='fc1')
            
            net = slim.fully_connected(net, self.num_classes, 
                                       activation_fn=None, scope='fc2')
        prediction_dict = {'logits': net}
        return prediction_dict

    def postprocess_logits(self, prediction_dict):
        logits = prediction_dict['logits']
        logits = tf.cast(logits, dtype=tf.float32)
        logits_dict = {'logits': logits}
        return logits_dict  

    def postprocess_classes(self, prediction_dict):
        logits = prediction_dict['logits']
        logits = tf.nn.softmax(logits)
        classes = tf.cast(tf.argmax(logits, axis=1), dtype=tf.int32)
        postprecessed_dict = {'classes': classes}
        return postprecessed_dict    

    def loss(self, prediction_dict, groundtruth_lists):
        logits = prediction_dict['logits']
        loss = tf.reduce_mean(
            tf.nn.sparse_softmax_cross_entropy_with_logits(
                logits=logits, labels=groundtruth_lists))
        loss_dict = {'loss': loss}
        return loss_dict
