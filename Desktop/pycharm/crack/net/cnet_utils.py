import torch
import torch.nn as nn
import torch.nn.functional as F
import numpy
import random


class region:
    def __init__(self, img, num):
        super(region, self).__init__()
        self.num = num
        self.img = img
        self.width = len(img)
        self.length = len(img[0])
        self.unit = self.tune(self)
        self.r = self.divide(self)


    def divide(self):
        r = {}
        for i in range(self.num):
            r[str(i)] = self.unit[i]

        return r



