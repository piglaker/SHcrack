package JRBM;

public class Track {
    double x;
    double y;
    double w;
    Player player;
    double L=Math.sqrt(Math.pow(player.getPx()-x, 2)+Math.pow(player.getPy()-y, 2));
	double r=w*L;
    double k=(y-player.getPy())/(x-player.getPx());
	double xu=(player.getPx()+x)/2;
	double yu=(player.getPy()+y)/2;
	//y=-(1/k)(x-xu)+yu;
	//(x-x1)(x-x2)+(y-y1)(y-y2)=0;
	//(x-x1)^2+(y-y1)^2=r^2   (x-x2)^2+(y-y2)^2=r^2;
    
    
	
    
    public double getX(){
    	return x;
    }
    public double getY(){
    	return y;
    }
    public double getK(){
    	return k;
    }
    public void setX(double x){
    	this.x=x;
    }
    public void setY(double y){
    	this.y=y;
    }
    public void setK(double k){
    	this.k=k;
    }
    
    
    
	
	//��������õ������ߣ���Ϊ�˶��켣:no
    //kΪ�����߶��㵽��������ߴ�������������ı�ֵ��no

    
    
    
    
    
    
    
	
	public Track() {
		// TODO Auto-generated constructor stub
	}

}
