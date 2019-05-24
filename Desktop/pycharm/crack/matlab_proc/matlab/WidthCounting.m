function [width,area]=WidthCounting(Label_Image,Crack_Length,i,type,pixel_resolution)
if nargin<5
    pixel_resolution=0.0229;
end
if type=="Area"
    [rows,~]=find(Label_Image==i);
    area=sum(rows);
    width=area/Crack_Length*pixel_resolution;
else
    % the other type which is called maxwidth is omitted here.
end