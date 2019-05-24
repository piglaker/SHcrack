# -*- coding: utf-8 -*-
"""
Created on Mon Dec 17 21:23:58 2018

@author: Meng
"""
from sklearn.model_selection import train_test_split  
from sklearn.preprocessing import StandardScaler
from sklearn.neural_network import MLPClassifier

from sklearn import svm
import numpy as np
dataset_1=np.loadtxt(r"C:\Users\Acer\Desktop\svm_train_data\dataset1.txt")
dataset_0=np.loadtxt(r"C:\Users\Acer\Desktop\svm_train_data\dataset_0.txt")
x=np.linspace(0,1898,950)
y=np.linspace(1,1899,950)
data1=[]

data11=[]

for i in x:
    i=int(i)
    data1.append(dataset_1[i])
    data1.append(dataset_0[i])
for i in y:
    i=int(i)
    data11.append(dataset_1[i])
    data11.append(dataset_0[i])
y0=[]   
dataset=np.c_[data1,data11]
for i in range(950):
    y0.append(-1)
y1=np.ones(950)
y=np.hstack((y1,y0))
dataset= StandardScaler().fit_transform(dataset)  

from sklearn.cross_validation import  train_test_split
data_train, data_test, target_train, target_test = train_test_split(dataset, y)
from sklearn.metrics import confusion_matrix,classification_report

svc = svm.SVC(C=1.0, kernel='rbf', degree=3, gamma='auto', coef0=0.0, shrinking=True, probability=False,
tol=0.001, cache_size=1000, class_weight=None, verbose=False, max_iter=-1, decision_function_shape=None,random_state=None)
  # 生成svm的分类模型
model=svc.fit(data_train, target_train)  # 利用训练数据建立模型
pred = model.predict(data_test)  # 预报测试集
error=pred-target_test
print(target_test)
print(error)
print(classification_report(target_test,pred))



from sklearn.externals import joblib

from sklearn.svm import SVC
from sklearn import datasets



# 保存成sklearn自带的文件格式
joblib.dump(svc, r'C:\Users\Acer\Desktop\save\svc.pkl')

'''
from svmutil import *

y, x = svm_read_problem(r'C:\\Users\\Acer\\Desktop\\dataset.txt')

yt, xt = svm_read_problem(r'C:\\Users\\Acer\\Desktop\\test.txt')

parameter = '-c 2048.0 -g 0.0078125'

model = svm_train(y, x, parameter)

 

p_label, p_acc, p_val = svm_predict(yt[0:], xt[0:], model)

'''
 