# -*- coding: utf-8 -*-
"""
Created on Mon Mar 18 21:55:15 2019

@author: Xiaoyin
"""

import numpy as np
import random
import math
import cv2
import os
import glob
import shutil


def confidence_(logits):
    confidence = 0
    confidence = -1 * math.log(min(softmax(logits)))
    return confidence 


def confidence(predicted_label_dict, predicted_logits_dict):
    total_confidence = 0
    target = 0
    avg_confidence = 0
    for i in range(len(predicted_label_dict)):
        if predicted_label_dict[i] == 1:
            target += 1
            total_confidence += confidence_(predicted_logits_dict[i][0])
    avg_confidence = total_confidence / target
    return target,avg_confidence


def softmax(array):
    """
    softmax:regression
    """
    s = 0
    array2 = []
    for i in range(len(array)):
        s += math.exp(array[i])
    for j in range(len(array)):
        array2.append(math.exp(array[j]) / s)
    return array2


def make(a, b, image, normal_size=224):
    """
    create a img copy from image form (a,b)
    inputs: a,b, image, the size of copy
    outputs: a copy of image from (a,b) in size    
    """
    img = tensor(normal_size,normal_size,3)
    for i in range(normal_size):
        for j in range(normal_size):
            for u in range(3):
                img[i][j][u] = int(image[a + i][b + j][u])
    return img


def make_t(x1, y1, x2, y2, image):
    """
    use two vector to localize img from iamge
    :param x1:
    :param y1:
    :param x2:
    :param y2:
    :param image:
    :return: img (cut from image)
    """
    img = tensor(abs(x1 - x2), abs(y1 - y2), 3)
    for i in range(x2 - x1):
        for j in range(y2 -y1):
            for u in range(3):
                img[i][j][u] = int(image[x1 + i][y1 + j][u])
    return img


def images_from_map(map_):
    """

    :param map:
    :return:
    """
    images = []
    for i in range(len(map_)):
        x1, y1 = map_[i][0:2]
        x2, y2 = map_[i][2:4]
        images.append(make_t(x1, y1, x2, y2))
    return images


def area_from_map(map_):
    area = []
    for i in range(len(map_)):
        area.append([map[0:5]])
    return area


def copy(x1, y1, x2, y2, image):
    """
    create a img copy from image form (a,b)
    inputs: a,b, image, the size of copy
    outputs: a copy of image from (a,b) in size    
    """
    img = tensor(abs(x1 - x2),abs(y1 - y2),3)
    for i in range(abs(x1 - x2)):
        for j in range(abs(y1 - y2)):
            for u in range(3):
                img[i][j][u] = int(image[x1 + i][y1 + j][u])
    return img


def tensor(a, b, c):
    """
    return a tensor of 3-D(a,b,c)    
    """
    img = np.zeros((b,c))
    image = []
    for i in range(a):
        image.append(img)
    image = np.asarray(image)
    return image
# creat a tensor (a,b,c)


def pic_cut(image, n, normal_size = 224):
    """
    cut image into n     
    """
    a, b = 0, 0
    launch = n * normal_size
    cuted_img = []
    image = cv2.resize(image, (launch,launch), interpolation=cv2.INTER_CUBIC)
    for i in range(n):    
        for j in range(n):    
            img = make(a, b, image, normal_size)
            cuted_img.append(img)
            b = b + normal_size
        a = a + normal_size
        b = 0
    return cuted_img


def tune(img):
    normal_size = 224
    #print(len(img))
    m, n = int(len(img) / 224) , int(len(img[0]) / 224)
    img = cv2.resize(img, (n * normal_size, m * normal_size), interpolation=cv2.INTER_CUBIC)
    #print(len(img))
    return img


def simple_cut(image, normal_size = 224):
    """
    cut image into n
    """
    a, b = 0, 0
    m, n= int(len(image) / 224), int(len(image[0]) / 224)
    cuted_img = []
    print(m, n)
    for i in range(m):
        for j in range(n):
            img = make(a, b, image, normal_size)
            cuted_img.append(img)
            b = b + normal_size
        a = a + normal_size
        b = 0
    return cuted_img


def save_txt(graph, output_dir):
    f = open(output_dir + "/area.txt", 'w')
    for i in range(len(graph)):
        for j in range(len(graph[i])):
            f.write(str(graph[i][j]))
            f.write(' ')
        f.write('\n')
    f.close()
    print("area.txt (map) has been saved to " + output_dir)


def make_graph(ans, m, n):
    graph = []
    array = []
    count = 0
    for i in range(len(ans)):
        array.append(ans[i])
        count += 1
        if count % n == 0:
            graph.append(array)
            array = []
    return graph


def mkpackage(output_dir, ans, images_, image):
    """

    :param output_dir:
    :param ans:
    :param images_:
    :param image:
    :return:
    """
    size = 321

    m, n = int(len(image) / 224), int(len(image[0]) / 224)

    graph = make_graph(ans, m, n)

    print(graph)

    save_txt(graph, output_dir)

    dir = "../deeplab/result"

    save_txt(graph, dir)

    for o in range(len(images_)):
        pic_name = output_dir + '/images/crack_' + str(o) + '_.png'
        images_[o] = cv2.resize(images_[o], (size, size), interpolation=cv2.INTER_CUBIC)
        cv2.imwrite(pic_name, images_[o])
    cv2.imwrite(output_dir + '/prediction.jpg', image)

    print("successfully save!")


def tfrecord_txt(dir, images):
    f = open("C:\\Users\\zhang\\Desktop\pycharm\\crack\\tf_proc\\Segmentation\\val.txt", 'w')
    for i in range(len(images)):
        f.write(str(i+1))
        f.write('\n')
    f.close()


def tfrecord_pic(dir, images_):
    size = 321
    dir = "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\tf_proc\\JPEGImages"
    for o in range(len(images_)):
        pic_name = dir + '/' + str(o+1) + '.png'
        images_[o] = cv2.resize(images_[o], (size, size), interpolation=cv2.INTER_CUBIC)
        cv2.imwrite(pic_name, images_[o])


def random_cut_(image, normal_size = 224):
    """
    return a images from image (random)
    """
    r1 = int(random.random() * (len(image) - normal_size))
    r2 = int(random.random() * (len(image[0]) - normal_size))
    img = make(r1, r2, image, normal_size)
    return img, r1, r2


def random_cut(image, n, normal_size = 224):
    """
    get a random images of image
    """
    images = []
    for i in range(n):
        r1 = int(random.random() * (len(image) - normal_size))
        r2 = int(random.random() * (len(image[0]) - normal_size))
        img = make(r1, r2, image, normal_size)
        images.append(img)
    return images
    

def enhance(gray_image):
    image = gray_image
    for i in range(len(image)):
        for j  in range(len(image[i])):
            image[i][j] = (image[i][j] / 255) * (image[i][j] / 255)*255
    # image=image
    return image

        
def gradient(image): 
    """
    gradient   
    """
    row, column = image.shape
    moon_f = np.copy(image)
    moon_f = moon_f.astype("float")
    gradient = np.zeros((row, column))
    for x in range(row - 1):
        for y in range(column - 1):
            gx = abs(moon_f[x + 1, y] - moon_f[x, y])
            gy = abs(moon_f[x, y + 1] - moon_f[x, y])
            gradient[x, y] = gx + gy            
    # gradient = gradient.astype("uint8")
    return gradient


def pack_images_up(images, photo = 'raw'):
    """
    pack images up into a list of images or gradient images
    """
    packed_images = []
    if photo == 'gradient':
        for i in range(len(images)):
            img = np.array(images[i])
            img = img.astype(np.uint8)
            img = cv2.cvtColor(img, cv2.COLOR_RGB2GRAY)#  注意：灰度图要求输入为np.ndarray dtype=uint8
            packed_images.append(gradient(cv2.resize(img, (224, 224), interpolation=cv2.INTER_CUBIC)))#  梯度图，注意梯度要去inputs为灰度图，
        return packed_images
    # gray -resize
    if photo == 'gray':
        for i in range(len(images)):
            img = np.array(images[i])
            img = img.astype(np.uint8)
            img = cv2.cvtColor(img, cv2.COLOR_RGB2GRAY)#  注意：灰度图要求输入为np.ndarray dtype=uint8
            packed_images.append(cv2.resize(img, (224, 224), interpolation=cv2.INTER_CUBIC))#
        return packed_images
    if photo =='enhance':
        for i in range(len(images)):
            img = np.array(images[i])
            img = img.astype(np.uint8)
            img = cv2.cvtColor(img, cv2.COLOR_RGB2GRAY)#  注意：灰度图要求输入为np.ndarray dtype=uint8
            packed_images.append(cv2.resize(enhance(img), (224, 224),interpolation=cv2.INTER_CUBIC))#
        return packed_images
    else:
        for i in range(len(images)):
            img = np.array(images[i])
            img = img.astype(np.uint8)
            packed_images.append(cv2.resize(img, (224, 224)))
        return packed_images


def pack_image_up_(image, photo):
    """
    pack images up into a list of images or gradient images
    """
    packed_image=0
    if photo == 'gradient':
        img = np.array(image)
        img = img.astype(np.uint8)
        img = cv2.cvtColor(img, cv2.COLOR_RGB2GRAY)#注意：灰度图要求输入为np.ndarray dtype=uint8
        packed_image = gradient(cv2.resize(img, (224, 224), interpolation=cv2.INTER_CUBIC))#梯度图，注意梯度要去inputs为灰度图，
    #gray -resize

    if photo == 'gray':
        img = np.array(image)
        img = img.astype(np.uint8)
        img = cv2.cvtColor(img, cv2.COLOR_RGB2GRAY)#注意：灰度图要求输入为np.ndarray dtype=uint8
        packed_image = cv2.resize(img, (224, 224), interpolation=cv2.INTER_CUBIC)

    else:
        img = np.array(image)
        packed_image = img.astype(np.uint8)
    return packed_image      


def new_txt():	
    b = os.getcwd() + '\\test_txt\\'	
    print("Created directory："+ "test_txt")	
    print("The created TXT files:")	
    if not os.path.exists(b):		
        os.makedirs(b)	

    for file in range(1,20):
        print(str(file) + '.txt')
        open(b + str(file) + '.txt', "w")


def record(k, area, packed_images, image, output_dir, red = 255, green = 255, blue = 255, ns = 224):
    """
    write the singel image
    """
    normal_size = ns
    images = packed_images
    count = 0
    graph = []
    array = []
    n = int(math.sqrt(len(area)))
    if os.path.exists(output_dir + '/' + str(k)):
        shutil.rmtree(output_dir + '/' + str(k))
    os.makedirs(output_dir + '/' + str(k))
    if os.path.exists(output_dir + '/' + str(k) + '/images'):
        shutil.rmtree(output_dir + '/' + str(k) + '/images')
    os.makedirs(output_dir + '/' + str(k) + '/images')
    output_dir = output_dir + '/' + str(k)
    for i in range(len(area)):    
            array.append(area[i])
            count += 1
            if count % n == 0:
                graph.append(array)
                array = []
    count = 0
    if os.path.exists(output_dir + '/area.txt'):
        os.remove(output_dir + '/area.txt')
    f = open(output_dir + '/area.txt', 'x')
    for i in range(len(graph)):
        print(graph[i]) 
        for j in range(len(graph[i])):
            f.write(str(graph[i][j]))
            f.write(' ')
        f.write('\n')
    f.close()
    area = np.loadtxt(output_dir + '/area.txt')
    image_ = tensor(len(area) * normal_size,len(area) * normal_size, 3)
    images_= []
    for i in range(len(area)):
        for j in range(len(area)):
            if area[i][j] == 1:
                images_.append(images[len(area) * i + j])
    for i in range(len(area)):
        for j in range(len(area[i])):
            if area[i][j] == 1:
                #cv2.imwrite(output_dir+'/fuck'+str(count)+'.jpg',images[count])
                cv2.imwrite(output_dir + '/images/' + str(count) + '.jpg', images_[count])
                images_[count] = cv2.cvtColor(images_[count], cv2.COLOR_RGB2GRAY)
                image = draw_map(i * normal_size,j * normal_size, image, gradient(images_[count]), red,0,0)
                image_= draw_map(i * normal_size,j * normal_size, image_, gradient(images_[count]), red,green,blue)
                count += 1
    cv2.imwrite(output_dir + '/draw_image' + str(k) + '.jpg', image)
    cv2.imwrite(output_dir + '/draw_image_' + str(k) + '.jpg', image_)


def resort(area, packed_images, predicted_label_dict, predicted_logits_dict, image,normal_size = 224):
    logits_dict = []
    images_1 = []
    images_0 = []
    m, n = int(len(image) / 224), int(len(image[0]) / 224)
    for i in range(len(packed_images)):                  
            if predicted_label_dict[i] == 1:
                area[i] = 1;
                images_1.append(packed_images[i])
                logits_dict.append(predicted_logits_dict[i])
                y = normal_size * (int((i) / n))
                x = normal_size * ((i) % m)
                cv2.rectangle(image, (x, y), (x + normal_size, y + normal_size), (0, 255, 0), 3)
            else:
                images_0.append(packed_images[i])
    return area, image, logits_dict, images_1

           
def gradient_function(max_target, max_avg_score, target, avg_score, preference):
    """
    the loss function (target to optimizer ) of 'quick' method in focal
    """
    if preference == 'amount':
        if max_target * 0.7 + max_avg_score * 0.3 > target * 0.7 + max_avg_score * 0.3:
            return True
    if preference == 'accuracy':
        if max_target * 0.4 + max_avg_score * 0.7 > target * 0.4 + max_avg_score * 0.7:
            return True
    return False


def max_function(max_target, max_avg_score, target, avg_score, preference):
    """
    the loss function (target to optimizer ) of 'quick' method in focal 
    """
    if preference == 'amount':
        if max_target * 0.7 + max_avg_score * 0.3 < target * 0.7 + max_avg_score * 0.3:
            return True
    if preference == 'accuracy':
        if max_target * 0.4 + max_avg_score * 0.7 < target * 0.4 + max_avg_score * 0.7:
            return True
    return False            

           
def get_batch(images, a, b):
    """
    get the batch
    """
    image_batch = images[a : b + 1]
    return image_batch


def clear(path):
    """
    clear the file
    """
    for i in os.listdir(path):
        path_file = os.path.join(path, i)
        if os.path.isfile(path_file):
            os.remove(path_file)
        else:
            for f in os.listdir(path_file):
                path_file2 = os.path.join(path_file, f)
                if os.path.isfile(path_file2):
                    os.remove(path_file2)


def draw_map(a, b, image, images, red=255, green=0, blue=0, ns = 224):
    """
    draw the image from (a ,b) to ...  with color (red,green,blue)
    """
    normal_size = ns
    for i in range(a, a + normal_size, 1):
        for j in range(b, b + normal_size, 1):
            # print(a,b,i,j)
            if images[i - a][j - b] > 0:
                # print(i,j)
                image[i][j][0] = blue
                image[i][j][1] = green
                image[i][j][2] = red
    return image


def draw_map_t(x1, y1, x2, y2, image, images, red = 255, green = 0, blue = 0):

    for i in range(x1, x2, 1):
        for j in range(y1, y2, 1):
            # print(a,b,i,j)
            if images[i - x1][j - y1] > 0:
                # print(i,j)
                image[i][j][0] = blue
                image[i][j][1] = green
                image[i][j][2] = red
    return image


def joint(path, Gradient = False, red = 255, green = 255, blue = 255, ns = 224):
    """
    up to data
    """
    images_path = path + '/images'
    area_path = path + '/area.txt'
    normal_size = ns
    area = np.loadtxt(area_path)
    images_ = []
    n = len(area)
    m = len(area[0])
    print(n, m)
    image = tensor(n * normal_size, m * normal_size, 3)
    images_path = os.path.join(images_path, '*.png')
    name = []
    for image_file in glob.glob(images_path):
        img = cv2.imread(image_file, 0)
        images_.append(img)      
        label = int(image_file.split('_')[-2].split('_')[-1])
        name.append(label)  
    images = []
    count = 0

    for i in range(len(name)):
        for j in range(len(name)):
            if name[j] == i:
                images_[j] = cv2.resize(images_[j], (normal_size, normal_size), interpolation=cv2.INTER_CUBIC)
                images.append(images_[j])

    for i in range(n):
        for j in range(m):
            if area[i][j] == 1:
                if Gradient:
                    image = draw_map(i * normal_size, j * normal_size, image, gradient(images[count]), red, green, blue)
                else:
                    print(i * normal_size, j * normal_size)
                    image = draw_map(i * normal_size, j * normal_size, image, images[count], red, green, blue)
                count += 1
    cv2.imwrite('../python_proc/deeplab' + '/1.png', image)
    clear(path)


def joint_(images_path = "../tf_proc/val/segmentation_results", area_path = "../tf_proc/area.txt", Gradient = False, red = 255, green = 255, blue = 255, ns = 224):
    normal_size = ns

    area = np.loadtxt(area_path)

    images_ = []

    n = len(area)

    m = len(area[0])

    print(n, m)

    image = tensor(n * normal_size, m * normal_size, 3)

    images_path = os.path.join(images_path, '*.png')

    name = []

    arg = 0

    for image_file in glob.glob(images_path):
        #print(image_file.split('_')[-1].split('.')[-2])

        t = image_file.split('_')[-1].split('.')[-2][0]

        if t == 'p':
            print("get!")
            img = cv2.imread(image_file, 0)
            images_.append(img)
            label = arg
            name.append(label)
            arg += 1
    images = []
    count = 0

    for i in range(len(name)):
        for j in range(len(name)):
            if name[j] == i:
                images_[j] = cv2.resize(images_[j], (normal_size, normal_size), interpolation=cv2.INTER_CUBIC)
                images.append(images_[j])
    for i in range(n):
        for j in range(m):
            if area[i][j] == 1:
                if Gradient:
                    image = draw_map(i * normal_size, j * normal_size, image, gradient(images[count]), red, green, blue)
                else:
                    print(i * normal_size, j * normal_size)
                    image = draw_map(i * normal_size, j * normal_size, image, images[count], red, green, blue)
                count += 1
    cv2.imwrite('../python_proc/deeplab' + '/1.png', image)
    #clear(path)


def joint_t(images_path = "../tf_proc/val/segmentation_results", map_path = "../tf_proc/area.txt", image_path = "", Gradient = False, red = 255, green = 255, blue = 255):
    """

    :param images_path:
    :param map_path:
    :param image_path:
    :param Gradient:
    :param red:
    :param green:
    :param blue:
    :return:
    """
    area = np.loadtxt(map_path)

    images_ = []

    image = cv2.imread(image_path)

    images_path = os.path.join(images_path, '*.png')

    name = []

    arg = 0

    for image_file in glob.glob(images_path):

        img = cv2.imread(image_file, 0)

        images_.append(img)

        label = arg

        name.append(label)

        arg += 1

    images = []

    count = 0

    for i in range(len(images_)):
        images_[i] = cv2.resize(images_[i], (area[i][2] - area[i][0], area[i][3] - area[i][1]), interpolation=cv2.INTER_CUBIC)
        images.append(images_[i])

    for i in range(n):
        for j in range(m):
            if area[i][j] == 1:
                if Gradient:
                    image = draw_map(i * normal_size, j * normal_size, image, gradient(images[count]), red, green, blue)
                else:
                    print(i * normal_size, j * normal_size)
                    image = draw_map(i * normal_size, j * normal_size, image, images[count], red, green, blue)
                count += 1
    cv2.imwrite('../python_proc /deeplab' + '/1.png', image)


def paint(path, red = 255, green = 0, blue = 0, ns = 224):
    """
    up to data
    """
    images_path = path + '/images/'
    area_path = path + '/area.txt'
    print(area_path)
    normal_size = ns
    area = np.loadtxt(area_path)
    images_ = []
    # n=len(area)
    # image=tensor(n*normal_size,n*normal_size,3)
    image = cv2.imread(path + '/prediction.jpg')
    images_path = os.path.join(images_path, '*.jpg')
    name = []
    for image_file in glob.glob(images_path):
        img = cv2.imread(image_file, 0)
        images_.append(img)      
        label = int(image_file.split('_')[-2].split('_')[-1])
        name.append(label)  
    images = []
    count = 0
    for i in range(len(name)):
        for j in range(len(name)):
            if name[j] == i:
                images.append(images_[j])
    for i in range(len(area)):
        for j in range(len(area[i])):
            if area[i][j] == 1:
                image = draw_map(i * normal_size, j * normal_size, image, gradient(images[count]), red, green, blue)
                count += 1
    cv2.imwrite(path + '/beauty.jpg', image)

