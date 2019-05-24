import utils2
import argparse


def get_args():
    parser = argparse.ArgumentParser()
    parser.add_argument('--path', '-p',metavar='INPUT',nargs='+',
                        default='C:\\Users\\zhang\\Desktop\\pycharm\\crack\\deeplab\\data', help='images')
    return parser.parse_args()


if __name__ == '__main__':
    args = get_args()
    #utils2.joint(args.path)
    utils2.joint_()
    utils2.clear('C:\\Users\\zhang\\Desktop\\pycharm\\crack\\tf_proc\\tfrecord\\')
    utils2.clear('C:\\Users\\zhang\\Desktop\\pycharm\\crack\\tf_proc\\Segmentation\\')
    utils2.clear('C:\\Users\\zhang\\Desktop\\pycharm\\crack\\tf_proc\\val\\')


