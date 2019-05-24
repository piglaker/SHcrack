files = dir(fullfile('E:\zxtdeeplearning\crack\matlab_proc\start\','*.png'));
lengthFiles = length(files);
for i = 1:lengthFiles
    pic_num=i;
     I = imread(['E:\zxtdeeplearning\crack\matlab_proc\start\',num2str(i),'.png']);%文件所在路径
    C=I;
    imwrite(C,['E:\zxtdeeplearning\crack\matlab_proc\start_new\',num2str(i),'.png']);
    zhang_suen(['E:\zxtdeeplearning\crack\matlab_proc\start_new\',num2str(i),'.png'],['E:\zxtdeeplearning\crack\matlab_proc\skeleton_pic\',num2str(i),'.png']);
    S=imread(['E:\zxtdeeplearning\crack\matlab_proc\skeleton_pic\',num2str(i),'.png']);
    o=imread(['E:\zxtdeeplearning\crack\matlab_proc\single\',num2str(i),'.png']);
    [len,wid,l]=size(o);
    S=imresize(S,[len,wid],'nearest');
    t=o+S;
    t(t>255)=255;
    g=t(:,:,2);
    g(g==255)=0;
    b=t(:,:,3);
    b(b==255)=0;
    r=t(:,:,1);
    new(:,:,1)=r;
    new(:,:,2)=g;
    new(:,:,3)=b;
    imwrite(new,['E:\zxtdeeplearning\crack\matlab_proc\skeleton_pic\',num2str(i),'.png'])
    pixel_resolution=0.0229;
   A=I;
tt=graythresh(I);
I=im2bw(I,tt);
Label_Image=bwlabel(I,8);

Num=unique(Label_Image);
    Num=Num(2:end);
    Pic_Num=zeros(length(Num),1);
    Pic_Num(Pic_Num==0)=i;
    Crack_Length=zeros(length(Num),1);
    Crack_Width=zeros(length(Num),1);
    Crack_Type=zeros(length(Num),1);
    area=zeros(length(Num),1);
    none=zeros(length(Num),1);
    for p=1:length(Num)
    D=Label_Image;
    D(D~=p)=0;
    image(:,:,1)=D;
    image(:,:,2)=D;
    image(:,:,3)=D;
    imwrite(image,['E:\zxtdeeplearning\crack\matlab_proc\raw\',num2str(p),'.png']);
    zhang_suen(['E:\zxtdeeplearning\crack\matlab_proc\raw\',num2str(p),'.png'],['E:\zxtdeeplearning\crack\matlab_proc\end\',num2str(p),'.png']);
    B=imread(['E:\zxtdeeplearning\crack\matlab_proc\end\',num2str(p),'.png']);
    %B=B(:,:,1);
    if isempty(find(B~=0))==1
        continue;
    end
    B(B~=0)=p;
    disp('start to label in the CrackDetectionImage...');
    disp('Finish labeling in the CrackDetectionImage.');
    disp('Start to collect the Crack Information...');
    [Crack_Length(p),Crack_Type(p)]=LengthCounting(B,p);
    %disp(Crack_Length(i));
    if Crack_Length(p)~=0
    [Crack_Width(p),area(p)]=WidthCounting(D,Crack_Length(p),p,'Area');
    else
        none(p)=1;
    end
    disp([num2str(100/length(Num)*p),'% percent finished...']);
    end
    Crack_Type(find(none==1))=[];
    area(find(none==1))=[];
    Crack_Length(find(none==1))=[];
    Crack_Width(find(none==1))=[];
    Pic_Num(find(none==1))=[];
    Crack_Info=[Pic_Num';Num';Crack_Length';Crack_Type';Crack_Width'];
    locate=find(Crack_Info(3,:)==0);
    Crack_Info(:,locate)=[];
    if isempty(Crack_Info)==1
        Crack_Info=[i;1;0;0;0];
    end
    num= size(Crack_Info,2);
    for k=1:num
         Crack_Info(2,k)=k;
    end
    fp=fopen('E:\zxtdeeplearning\crack\matlab_proc\A.txt','a');%'A.txt'为文件名；'a'为打开方式：在打开的文件末端添加数据，若文件不存在则创建。
    fprintf(fp,'%f ',Crack_Info);%fp为文件句柄，指定要写入数据的文件。注意：%d后有空格。
    fclose(fp);%关闭文件。
    disp('Finish aclculating the Crack Information...');
 
    delete(['E:\zxtdeeplearning\crack\matlab_proc\start_new\',num2str(i),'.png']);
    delete(['E:\zxtdeeplearning\crack\matlab_proc\start\',num2str(i),'.png']);
    clear all;
end                                                                    


