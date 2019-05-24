function [CrackLength,Type]=LengthCounting(Label_Image,Label)
[row,~]=size(Label_Image);
Points=find(Label_Image==Label);
Points_Y=mod(Points,row);
for i=1:length(Points_Y)
    if Points_Y(i)==0
        Points_Y(i)=row;
    end
end
Points_X=ceil(Points/row);
Center_X_Coor=sum(Points_X)/length(Points_X);
Center_Y_Coor=sum(Points_Y)/length(Points_Y);

[Sort_X,index]=sort(Points_X);
count=floor(length(Sort_X)/10);
Left_X=Sort_X(1:count);
Index_X_Left=index(1:count);
Left_Y=Points_Y(Index_X_Left);
Left_X_Coor=sum(Left_X)/length(Left_X);
Left_Y_Coor=sum(Left_Y)/length(Left_Y);

Right_X=Sort_X(end-count:end);
Index_X_Right=index(end-count:end);
Right_Y=Points_Y(Index_X_Right);
Right_X_Coor=sum(Right_X)/length(Right_X);
Right_Y_Coor=sum(Right_Y)/length(Right_Y);

Left_Angle=atan((Center_Y_Coor-Left_Y_Coor)/(Center_X_Coor-Left_X_Coor));
Left_Angle=Left_Angle*180/pi;
Right_Angle=atan((Right_Y_Coor-Center_Y_Coor)/(Right_X_Coor-Center_X_Coor));
Right_Angle=Right_Angle*180/pi;
Type=TypeCounting(Left_Angle,Right_Angle);

%calculate length
if (Type==1||Type==3||Type==4)
    pt_X=min(Points_X):max(Points_X);
    pt_Y=zeros(length(Points_X),1);
    for pt=min(Points_X):max(Points_X)
        pt_Y(pt-min(Points_X)+1)=sum(Points_Y(Points_X==pt))/length(find(Points_X==pt));
    end
    CrackLength=0;
    for i=1:length(pt_X)-1
        pt_length=sqrt((pt_Y(i+1)-pt_Y(i))^2+(pt_X(i+1)-pt_X(i))^2);
        CrackLength=CrackLength+pt_length;
    end
else
    pt_Y=min(Points_Y):max(Points_Y);
    pt_X=zeros(length(Points_Y),1);
    for pt=min(Points_Y):max(Points_Y)
        pt_X(pt-min(Points_Y)+1)=sum(Points_X(Points_Y==pt))/length(find(Points_Y==pt));
    end
    CrackLength=0;
    for i=1:length(pt_Y)-1
        pt_length=sqrt((pt_Y(i+1)-pt_Y(i))^2+(pt_X(i+1)-pt_X(i))^2);
        CrackLength=CrackLength+pt_length;
    end
end


