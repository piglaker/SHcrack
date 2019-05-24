# -*- coding: utf-8 -*-
"""
Created on Wed Apr 10 18:55:05 2019

@author: Acer
"""
from skimage import morphology
import numpy as np
from PIL import Image
# 定义像素点周围的8邻域

#                P9 P2 P3

#                P8 P1 P4

#                P7 P6 P5

 

def neighbours(x,y,image):

    img = image

    x_1, y_1, x1, y1 = x-1, y-1, x+1, y+1

    return [ img[x_1][y],img[x_1][y1],img[x][y1],img[x1][y1],         # P2,P3,P4,P5

            img[x1][y], img[x1][y_1], img[x][y_1], img[x_1][y_1] ]    # P6,P7,P8,P9

 

# 计算邻域像素从0变化到1的次数

def transitions(neighbours):

    n = neighbours + neighbours[0:1]      # P2,P3,...,P8,P9,P2

    return sum( (n1, n2) == (0, 1) for n1, n2 in zip(n, n[1:]) )  # (P2,P3),(P3,P4),...,(P8,P9),(P9,P2)

 

# Zhang-Suen 细化算法



            
def zhangsuen(image):
    Image_Thinned = image.copy()  # Making copy to protect original image
    
    changing1 = changing2 = 1

    print("zhangsuen skeletonize starts !")

    while changing1 or changing2:   # Iterates until no further changes occur in the image
    
        # Step 1
    
        changing1 = []
    
        rows, columns = Image_Thinned.shape
    
        for x in range(1, rows - 1):
    
            for y in range(1, columns - 1):
    
                P2,P3,P4,P5,P6,P7,P8,P9  = neighbours(x, y, Image_Thinned)
                
                n=neighbours(x, y, Image_Thinned)
    
                if (Image_Thinned[x][y] == 1     and    # Condition 0: Point P1 in the object regions 
    
                    2 <= sum(n) <= 6   and    # Condition 1: 2<= N(P1) <= 6
    
                    transitions(n) == 1 and    # Condition 2: S(P1)=1  
    
                    P2 * P4 * P6 == 0  and    # Condition 3   
    
                    P4 * P6 * P8 == 0):         # Condition 4
    
                    changing1.append((x,y))
    
        for x, y in changing1: 
    
            Image_Thinned[x][y] = 0
    
        # Step 2
    
        changing2 = []
    
        for x in range(1, rows - 1):
    
            for y in range(1, columns - 1):
    
                P2,P3,P4,P5,P6,P7,P8,P9  = neighbours(x, y, Image_Thinned)
                
                n=neighbours(x, y, Image_Thinned)
    
                if (Image_Thinned[x][y] == 1   and        # Condition 0
    
                    2 <= sum(n) <= 6  and       # Condition 1
    
                    transitions(n) == 1 and      # Condition 2
    
                    P2 * P4 * P8 == 0 and       # Condition 3
    
                    P2 * P6 * P8 == 0):            # Condition 4
    
                    changing2.append((x,y))    
    
        for x, y in changing2: 
    
            Image_Thinned[x][y] = 0
            
    return Image_Thinned


