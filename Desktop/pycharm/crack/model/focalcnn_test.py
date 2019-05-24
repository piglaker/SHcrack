# -*- coding: utf-8 -*-


import cv2
import focal_cnn
import utils
import tensorflow as tf
'''

弃用！！！
out of time！！！

'''


model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-0.ckpt\\0-81600"
#model_path="E:\\zxtdeeplearning\\crack\\model\\outputs-2.ckpt\\1-3550"

n=5
         
def main(_):
    #img_path = input('Input the path (you hava to put the test_pic in a file):')
    img_path="E:\\zxtdeeplearning\\crack\\model\\2.jpg"
    img=cv2.imread(img_path)
    stop=0  
    ans,image,logits_dict,images_,stop=focal_cnn.detection(img,model_path,precision=6,normal_size=224,focal_degree=0,method='quick',rewiew=False,photo='gradient')  
    print(ans)
    graph=[]
    array=[]
    count=0
    for i in range(len(ans)):    
        array.append(ans[i])
        count+=1
        if count%n ==0:          
            graph.append(array)
            array=[]
    for i in range(len(graph)):
        print(graph[i])
        
    for i in range(len(images_)):
        #print(images_[i])
        pic_name='./predictions/crack_'+str(i)+'_'+str(int(utils.confidence_(logits_dict[i][0])))+'.jpg'
        #print(semantic_cnn.confidence(logits_dict[i][0]))
        cv2.imwrite(pic_name,images_[i])
    cv2.imshow('0',image)
    cv2.imwrite('./predictions/prediction.jpg',image)
    cv2.waitKey(0)
    cv2.destroyAllWindows()
    #except:
     #   print("NO crack in the picture!")
        
        
if __name__ == '__main__':
    tf.app.run()