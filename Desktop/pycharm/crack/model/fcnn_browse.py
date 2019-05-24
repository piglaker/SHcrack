# -*- coding: utf-8 -*-
"""
Created on Sun Mar 24 18:23:34 2019

@author: Xiaoyin
"""

import cv2
import focal_cnn
import argparse
output_dir='./result'
path='./result'
'''
input: a folder :
    0.jpg
    1.jpg
    ...
output: a folder:
    0:images area.txt predictons...
    1
    2
    ...
'''


def get_args():
    parser = argparse.ArgumentParser()
    #parser = OptionParser()
    parser.add_argument('--images_path', '-d', metavar='INPUT', nargs='+',
                        default='E:\\zxtdeeplearning\\crack\\matlab_proc\\batch', help='dir of img')
    parser.add_argument('--output_dir', '-o',
                      default='E:\\zxtdeeplearning\\crack\\matlab_proc\\batch_output', help='output_dir of result')
        
    parser.add_argument('--normal_size', '-s',
                      default=224, help='normal_size')
    parser.add_argument('--focal_degree', '-f', 
                      default=0, help='focal_degree:2~20')
    parser.add_argument('--method', '-t',
                      default='quick', help='method:quick or deep')
    parser.add_argument('--model_path', '-m',  default='./outputs-0.ckpt/0-81600',
                      help='batch size')
    parser.add_argument('--precision', '-p' , default=5,
                       help='precision')
    parser.add_argument('--admin', '-a',
                      default=True, help='administer')
    parser.add_argument('--free', '-fr',
                      default=False, help='free')
    parser.add_argument('--unet', '-u',
                      default=True, help='unet')
    parser.add_argument('--photo', '-i',
                      default='raw', help='output of photo:gray,raw,gradient')
    parser.add_argument('--review', '-r',
                      default=False, help='method:quick or deep')
    
    #(options, args) = parser.parse_args()
    return parser.parse_args()


if __name__ == '__main__':
    args = get_args()
    images_path = args.images_path
    image_path = images_path[0]
    focal_cnn.browse(image_path
                     , output_dir=args.output_dir,
                     model_path='./outputs-0.ckpt/0-81600'
                     , n=5
                     , normal_size=224
                     , focal_degree=0
                     , method='quick'
                     , review=False
                     ,photo='raw',
                     admin=False)