# -*- coding: utf-8 -*-
"""
Created on Wed Mar 27 12:51:19 2019

@author: Xiaoyin
"""

import utils2
import argparse


def get_args():
    parser = argparse.ArgumentParser()
    parser.add_argument('--path', '-p', metavar='INPUT', nargs='+',
                        default='E:\\zxtdeeplearning\\crack\\matlab_proc\\single_output', help='images')
    return parser.parse_args()


if __name__ == '__main__':
    args = get_args()
    utils2.joint(args.path)
