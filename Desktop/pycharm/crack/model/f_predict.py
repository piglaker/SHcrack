import os
import shutil
import cv2
import focal_cnn
import utils2
import argparse


# nargs='+',
def get_args():
    parser = argparse.ArgumentParser()
    parser.add_argument('--img_dir', '-d', metavar='INPUT',
                        default='../matlab_proc/single/1.png', help='dir of img')
    parser.add_argument('--output_dir', '-o',
                        default='../deeplab/data', help='output_dir of result')
    parser.add_argument('--model_path', '-m', default='./outputs-0.ckpt/0-81600',
                        help='batch size')
    parser.add_argument('--precision', '-p', default=5,
                        help='precision')
    parser.add_argument('--normal_size', '-s',
                        default=224, help='normal_size')
    parser.add_argument('--focal_degree', '-f',
                        default=0, help='focal_degree:2~20')
    parser.add_argument('--method', '-t',
                        default='quick', help='method:quick or deep')
    parser.add_argument('--review', '-r',
                        default=False, help='method:quick or deep')
    parser.add_argument('--photo', '-i',
                        default='raw', help='output of photo:gray,raw,gradient')
    parser.add_argument('--admin', '-a',
                        default=True, help='administer')
    parser.add_argument('--free', '-fr',
                        default=False, help='free')
    parser.add_argument('--unet', '-u',
                        default=True, help='unet')

    # (options, args) = parser.parse_args()
    return parser.parse_args()


if __name__ == '__main__':
    args = get_args()
    n = args.precision
    path = args.img_dir
    normal_size = 224
    size = 321
    print(path)
    img = cv2.imread(path)
    img = utils2.tune(img)
    output_dir = args.output_dir

    ans, image, logits_dict, images_, stop = focal_cnn.detect(img, args.model_path, args.precision)

    if os.path.exists(output_dir + '/images'):
        shutil.rmtree(output_dir + '/images')
    os.makedirs(output_dir + '/images')

    cv2.imwrite(output_dir + '/origin.png', img)
    cv2.imwrite("../python_proc/original" + '/1.png', img)

    utils2.mkpackage(output_dir, ans, images_, image)
    utils2.mkpackage("../tf_proc", ans, images_, image)
    utils2.tfrecord_pic("../tf_proc/JPEGImages", images_)
    utils2.tfrecord_txt("../tf_proc/Segmentation", images_)
