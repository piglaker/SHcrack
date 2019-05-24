function newimage=mark(I)
tmp=I;
L=bwlabel(tmp,8);
[m,n]=size(tmp);
rank=reshape(L,1,m*n);
rank=sort(unique(rank));

thr=50;
[~,t]=size(rank);
sum1=zeros(1,t);
for i=1:m
    for j=1:n
        if L(i,j)>0
            sum1(L(i,j))=sum1(L(i,j))+1;
        end
    end
end
for i=1:t
    if sum1(i)<thr
        for x=1:m
            for y=1:n
                if L(x,y)==i
                    tmp(x,y)=0;
                end
            end
        end
    end
end
newimage=tmp;



