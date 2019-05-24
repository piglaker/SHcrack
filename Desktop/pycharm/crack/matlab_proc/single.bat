call activate pythontf 
 cd.. 
 cd model 
 python fcnn_predict.py --img_dir=../matlab_proc/single/1.png    
 cd.. 
 python build_voc2012_data.py 
 python vis.py 
 cd model 
 python joint.py 
 cd.. 
  python skeleton.py --binary_imgdir=./python_proc/deeplab/ --trash_imgdir=./python_proc/trash/  --original_imgdir=./matlab_proc/single/      --concat_imgdir=./python_proc/concat/  --txt_dir=./python_proc/txt/

txt/
t/  --txt_dir=./python_proc/txt/
c/txt/
