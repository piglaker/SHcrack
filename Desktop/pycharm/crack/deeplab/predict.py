import tensorflow as tf
import numpy as np
from PIL import Image
#from keras.preprocessing.image import load_img, img_to_array
import numpy as np
import cv2
import os
img_batch=[]
num=0
images = []

for filename in os.listdir("./data/images/"):
    img = cv2.imread("./data/images/" + filename)
    img = np.array(img)
    #img = np.expand_dims(img, axis=0).astype(np.uint8)
    images.append(img)
images = np.array(images)

"""
sess = tf.Session()
with open("frozen_inference_graph.pb", "rb") as f:
    graph_def = tf.GraphDef()
    graph_def.ParseFromString(f.read())
    output = tf.import_graph_def(graph_def, input_map={"ImageTensor:0": img},
                                         return_elements=["SemanticPredictions:0"])

    result = sess.run(output)
    r=result[0]
    kk=np.array(r[0])
    [w,e]=kk.shape
    for i in range(w):
        for j in range(e):
            if kk[i,j]==1:
                kk[i,j]=255
                im=Image.fromarray(np.uint8(kk))
                im.save(r"E:\\zxtdeeplearning\\crack\\deeplab\\result\\"+filename)



"""
#model_path = "E:\\zxtdeeplearning\\crack\\model\\outputs-0.ckpt\\0-81600"
model_path = './model.ckpt-30000'

predicted_label_dict = []
#module_file =  tf.train.latest_checkpoint('E://deeplearning-master/deeplearning-master/tensorflow-program/save/')

with tf.Session(config=tf.ConfigProto(allow_soft_placement=True, log_device_placement=True)) as sess:
    #sess.run(tf.global_variables_initializer())
    #if module_file is not None:
    #    saver.restore(sess, module_file)
    ckpt_path = model_path
    saver = tf.train.import_meta_graph(ckpt_path + '.meta')
    saver.restore(sess, ckpt_path)
    inputs = tf.get_default_graph().get_tensor_by_name('ImageTensor:0')
    classes = tf.get_default_graph().get_tensor_by_name('SemanticPredictions:0')
    for i in range(len(images)):
        image_batch = [cv2.resize(images[i], (224, 224), interpolation=cv2.INTER_CUBIC)]
        predicted_label = sess.run(classes, feed_dict={inputs: image_batch})
        predicted_label_dict.append(predicted_label)


"""
    for o in range(len(output)):
        r=result[o]
        kk=np.array(r[o])
        [w,e]=kk.shape
        for i in range(w):
            for j in range(e):
                if kk[i,j]==1:
                    kk[i,j]=255
                    im=Image.fromarray(np.uint8(kk))
                    im.save(r"./result/" + "crack_" + str(o) + "_.png")

"""
