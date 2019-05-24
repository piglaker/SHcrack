import tensorflow as tf
import numpy as np
from PIL import Image
#from keras.preprocessing.image import load_img, img_to_array
import numpy as np
import cv2
import os
img_batch = []
num = 0
dir = "C:\\Users\\zhang\\Desktop\\pycharm\\crack\\deeplab\\data\\images"

os.environ['CUDA_VISIBLE_DEVICES'] = "0"
for filename in os.listdir(dir):
    img = cv2.imread(dir + "\\" + filename)
    img = np.array(img)
    img = np.expand_dims(img, axis=0).astype(np.uint8)
    num+=1
    print(img.shape)
    sess = tf.Session()
    with open("C:\\Users\\zhang\\Desktop\\pycharm\\crack\\deeplab\\frozen_inference_graph.pb", "rb") as f:
        graph_def = tf.GraphDef()
        graph_def.ParseFromString(f.read())
        output = tf.import_graph_def(graph_def, input_map={"ImageTensor:0": img},
                                         return_elements=["SemanticPredictions:0"])

        result = sess.run(output)
        r = result[0]
        kk = np.array(r[0])
        [w,e] = kk.shape
        for i in range(w):
            for j in range(e):
                if kk[i, j] == 1:
                    kk[i, j] = 255
                    im = Image.fromarray(np.uint8(kk))
                    im.save(r"../deeplab/result/" + filename)
        print("done !")
