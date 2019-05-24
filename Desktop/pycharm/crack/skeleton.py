# -*- coding: utf-8 -*-
"""
Created on Fri Apr  5 17:39:28 2019

@author: MSQ
"""
import os
import argparse
import numpy as np
import skimage.io as io
from skimage import measure
import skimage
import cv2
import skimage
from skeletonize import zhangsuen

from PIL import Image
def gray_to_binary(img,height,width):
    for i in range(height):
        for j in range(width):
            if img[i,j]!=0:
                img[i,j]=1
    return img


def binary_to_gray(img,height,width):
    for i in range(height):
        for j in range(width):
            if img[i,j]==1:
                img[i,j]=255
            else:
                img[i,j]=0
    return img
 

def concat_pic(img1,img2,height,width):
    img2=np.array(img2)
    print(img1.shape)
    print(img2.shape)
    for i in range(height):
        for j in range(width):
            if img1[i,j]!=0:
                img2[i,j,0]=255
                img2[i,j,1]=0
                img2[i,j,2]=0
    return img2


def count_pixel(img,height,width):
    num=0
    for i in range(height):
        for j in range(width):
            if img[i,j]!=0:
                num+=1
    return num


def cal_length(img):
    img=np.array(img)
    flag=0
    [height,width]=img.shape
    for i in range(height):
        for j in range(width):
            li=found_around(img,i,j,height,width)
            if len(li)==1 and img[i,j]>0:           #find the endpoint
                w=i
                e=j
                flag=1
                break
            else:
                li=[]
        if flag==1:
            break
    clength=0
    wait_li=[]
    while len(li)!=0 or len(wait_li)!=0:
        img[w,e]=0
        if len(li)==1:
            if li[0]==1:
                w=w-1
                e=e-1
                clength=clength+np.sqrt(2)
            elif li[0]==2:
                w=w-1
                clength=clength+1
            elif li[0]==3:
                w=w-1
                e=e+1
                clength=clength+np.sqrt(2)
            elif li[0]==4:
                e=e-1
                clength=clength+1
            elif li[0]==5:
                e=e+1
                clength=clength+1
            elif li[0]==6:
                w=w+1
                e=e-1
                clength=clength+np.sqrt(2)
            elif li[0]==7:
                w=w+1
                clength=clength+1
            elif li[0]==8:
                w=w+1
                e=e+1
                clength=clength+np.sqrt(2)
        if len(li)>1:
            w1=w
            e1=e
            if li[0]==1:
                w=w-1
                e=e-1
                clength=clength+np.sqrt(2)
            elif li[0]==2:
                w=w-1
                clength=clength+1
            elif li[0]==3:
                w=w-1
                e=e+1
                clength=clength+np.sqrt(2)
            elif li[0]==4:
                e=e-1
                clength=clength+1
            elif li[0]==5:
                e=e+1
                clength=clength+1
            elif li[0]==6:
                w=w+1
                e=e-1
                clength=clength+np.sqrt(2)
            elif li[0]==7:
                w=w+1
                clength=clength+1
            elif li[0]==8:
                w=w+1
                e=e+1
                clength=clength+np.sqrt(2)
            del li[0]
            wait_point=[]
            for i in li:
                wait_point.append(i)
            wait_li.append([w1,e1,wait_point])
        if len(li)==0:
            li.append(wait_li[0][2][0])
            w=wait_li[0][0]
            e=wait_li[0][1]
            if li[0]==1:
                w=w-1
                e=e-1
                clength=clength+np.sqrt(2)
            elif li[0]==2:
                w=w-1
                clength=clength+1
            elif li[0]==3:
                w=w-1
                e=e+1
                clength=clength+np.sqrt(2)
            elif li[0]==4:
                e=e-1
                clength=clength+1
            elif li[0]==5:
                e=e+1
                clength=clength+1
            elif li[0]==6:
                w=w+1
                e=e-1
                clength=clength+np.sqrt(2)
            elif li[0]==7:
                w=w+1
                clength=clength+1
            elif li[0]==8:
                w=w+1
                e=e+1
                clength=clength+np.sqrt(2)
            del wait_li[0][2][0]
            if wait_li[0][2]==[]:
                del wait_li[0]
        li=[]
        li=found_around(img,w,e,height,width)
    return clength


def cal_width(length,pixel):
    width=pixel/length
    return width


def get_direction(img,height,width):
    img=np.array(img)
    [w,e]=np.where(img>0)
    c=[w,e]
    w.sort()
    e.sort()
    num=count_pixel(img,height,width)
    x_core=np.sum(e)/num+e[0]
    y_core=np.sum(w)/num+w[0]
    cut=np.ceil(w.shape[0]/10)
    cut=int(cut)
    left_y=len(w[0:cut])
    left_y_core=np.sum(w[0:cut])/left_y+w[0]
    v1=np.where(c[1]<=left_y)
    for i in v1:
        li=[]
        li.append(c[0][i])
    li=np.array(li)
    li.sort()
    left_x_core=np.sum(e[0:cut])/len(e[0:cut])+e[0]
    end=w.shape[0]
    right_y=len(w[end-cut:end])
    right_y_core=np.sum(w[end-cut:end])/right_y+w[end-cut]
    v2=np.where(c[1]>=right_y)
    for i in v2:
        li=[]
        li.append(c[0][i])
    li=np.array(li)
    li.sort()
    right_x_core=np.sum(e[end-cut:end])/len(e[end-cut:end])+e[end-cut]
    left_angle=np.arctan((left_y_core-y_core)/(x_core-left_x_core))*180/3.1415926
    right_angle=np.arctan((y_core-right_y_core)/(right_x_core-x_core))*180/3.1415926
    angle=left_angle-right_angle
    if np.abs(angle)>22.5:
        ctype=5
    else:
        if np.abs(left_angle)<22.5:
            Ltype=1
        elif np.abs(left_angle-45)<22.5:
            Ltype=3
        elif np.abs(left_angle+45)<22.5:
            Ltype=4
        else:
            Ltype=2
        if np.abs(right_angle)<22.5:
            Rtype=1
        elif np.abs(right_angle-45)<22.5:
            Rtype=3
        elif np.abs(right_angle+45)<22.5:
            Rtype=4
        else:
            Rtype=2
        if Ltype>Rtype:
            ctype=Ltype
        else:
            ctype=Rtype
    return ctype


def found_around(image,i,j,height,width):  #the input image must be h*w*1 
    li=[]
    if i==0 and j==0:
        if image[i,j+1]>0:
            li.append(5)
        if image[i+1,j]>0:
            li.append(7)
        if image[i+1,j+1]>0:
            li.append(8)
    elif i==height-1 and j==0:
        if image[i-1,j]>0:
            li.append(2)
        if image[i-1,j+1]>0:
            li.append(3)
        if image[i,j+1]>0:
            li.append(5)
    elif i==0 and j==width-1:
        if image[i,j-1]>0:
            li.append(4)
        if image[i+1,j-1]>0:
            li.append(6)
        if image[i+1,j]>0:
            li.append(7)
    elif i==height-1 and j==width-1:
        if image[i-1,j-1]>0:
            li.append(1)
        if image[i-1,j]>0:
            li.append(2)
        if image[i,j-1]>0:
            li.append(4)
    elif i==0 and j!=0 and j!=width-1:
        if image[i,j-1]>0:
            li.append(4)
        if image[i,j+1]>0:
            li.append(5)
        if image[i+1,j-1]>0:
            li.append(6)
        if image[i+1,j]>0:
            li.append(7)
        if image[i+1,j+1]>0:
            li.append(8)
        
    elif i==height-1 and j!=0 and j!=width-1:
        if image[i-1,j-1]>0:
            li.append(1)
        if image[i-1,j]>0:
            li.append(2)
        if image[i-1,j+1]>0:
            li.append(3)
        if image[i,j-1]>0:
            li.append(4)
        if image[i,j+1]>0:
            li.append(5)
    elif j==0 and i>0 and i<height-1:
        if image[i-1,j]>0:
            li.append(2)
        if image[i-1,j+1]>0:
            li.append(3)
        if image[i,j+1]>0:
            li.append(5)
        if image[i+1,j]>0:
            li.append(7)
        if image[i+1,j+1]>0:
            li.append(8)
    elif j==width-1 and i>0 and i<height-1:
        if image[i-1,j-1]>0:
            li.append(1)
        if image[i-1,j]>0:
            li.append(2)
        if image[i,j-1]>0:
            li.append(4)
        if image[i+1,j-1]>0:
            li.append(6)
        if image[i+1,j]>0:
            li.append(7)
    else:
        if image[i-1,j-1]>0:
            li.append(1)
        if image[i-1,j]>0:
            li.append(2)
        if image[i-1,j+1]>0:
            li.append(3)
        if image[i,j-1]>0:
            li.append(4)
        if image[i,j+1]>0:
            li.append(5)
        if image[i+1,j-1]>0:
            li.append(6)
        if image[i+1,j]>0:
            li.append(7)
        if image[i+1,j+1]>0:
            li.append(8)
    return li


def get_args():
    parser = argparse.ArgumentParser()
    parser.add_argument('--binary_imgdir', '-b', metavar='binary_imgdir', 
                        help='filenames of input images', required=True)
    parser.add_argument('--trash_imgdir', '-t', metavar='trash_imgdir', 
                        help='filenames of trash images', required=True)
    parser.add_argument('--original_imgdir', '-o', metavar='original_imgdir', 
                        help='filenames of original images', required=True)
    parser.add_argument('--concat_imgdir', '-c', metavar='concat_imgdir', 
                        help='filenames of concat images', required=True)
    parser.add_argument('--txt_dir', '-x', metavar='txt_dir', 
                        help='filenames of crack_info.txt', required=True)
    parser.add_argument('--crack-threshold', '-th', type=float,
                        help="Minimum crack length threshold",
                        default=10)
    return parser.parse_args()


if __name__ == "__main__":
    args = get_args()
    pic_num=0
    crack_all=[]
    for filename in os.listdir(args.binary_imgdir):
        pic_num+=1
        print(filename)
        threshold = 5
        kk=Image.open(args.binary_imgdir+filename)
        ori=Image.open(args.original_imgdir+filename)
        ori = np.array(ori)
        [j,k,l]=ori.shape
        kk=np.array(kk)
        kk=kk[:,:,0]
        kk=cv2.resize(kk, (k,j), interpolation = cv2.INTER_CUBIC)
        print(kk.shape)
        [w,e]=kk.shape
        for i in range(w):
            for j in range(e):
                if kk[i,j]>0:
                    kk[i,j]=1
        #label_image = measure.label(kk,connectivity=None)
        _,label_image=cv2.connectedComponents(kk)
        label_image=skimage.morphology.closing(label_image,selem=None)
        label_image=skimage.morphology.closing(label_image,selem=None)
        label_image=skimage.morphology.closing(label_image,selem=None)
        lib1=[]
        lib2=[]
        lib3=[]
        num=np.unique(label_image)
        count=num[-1]
        for k in range(count):
            lbimage=np.zeros((w,e))
            lbimage=np.array(lbimage)
            for i in range(w):
                for j in range(e):
                    l=k+1
                    if label_image[i,j]==l:
                        lbimage[i,j]=l

            pixel=count_pixel(lbimage,w,e)
            binary=gray_to_binary(lbimage,w,e)
            skeleton =skimage.morphology.skeletonize(binary)
            io.imsave(args.trash_imgdir+str(k)+'.png',skeleton)
            skeleton1 = Image.open(args.trash_imgdir+str(k)+'.png')
            skeleton2=np.array(skeleton1)
            length=cal_length(skeleton2)
            if length>threshold :
                original_pic = Image.open(args.original_imgdir+filename)
                original_pic =concat_pic(skeleton2,original_pic,w,e)
                io.imsave(args.original_imgdir+filename,original_pic)
                nn=Image.open(args.trash_imgdir+str(k)+'.png')
                nn=np.array(nn)
                ctype=get_direction(nn,w,e)
                W=cal_width(length,pixel)
                if length > 2 * W:
                    lib1.append(W)
                    lib2.append(length)
                    lib3.append(ctype)
        crack_info=[]
        num=len(lib1)
        original_pic = Image.open(args.original_imgdir + filename)
        original_pic=np.array(original_pic)
        io.imsave(args.concat_imgdir+str(pic_num)+'.png',original_pic)
        for i in range(num):
            crack=[pic_num,i+1,lib2[i],lib1[i],lib3[i]]
            crack_info.append(crack)
        crack_all.append(crack_info)
    f1=open(args.txt_dir+'crack_info.txt','r+')
    f1.read()
    for i in crack_all:
        for j in i:
            f1.write(str(j[0])+' '+str(j[1])+' '+str(j[2])+' '+str(j[3])+' '+str(j[4])+' ')
    f1.close()   
    pic_num=0




