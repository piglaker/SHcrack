import skimage
from PIL import Image
a=Image.open('C://Users//zhang//Desktop//pycharm//crack//python_proc//trash//987.png')
skimage.morphology.erosion(a,selem=None,out=None,shift_x=None,shift_y=None)
io.imsave('C://Users//zhang//Desktop//qwe.png',a)