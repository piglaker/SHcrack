package JRBM;
import java.math.*;
import javax.swing.*;
import java.awt.GridLayout;

import java.awt.*;
import java.awt.event.*;
import javax.swing.JOptionPane;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.io.Reader;
import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;


public class Player {
  
	private String Name="Kobe";//球员名称
	private int Number=0;//球员号码
	private  Player Counter=null;//对位
	private  boolean Ball=false;//持球
	public  double Direction=0;//方向，0-360，
	private String AttackMethod;//攻击打算
	private double Hinder=0;//阻尼
	private boolean Attacking=false;
	private boolean Defending=false;
	private boolean Tactics=true;
	private  boolean VIP=false;
	protected static final double T = 0;
	public  double[] Position=new double[2];                      //x y 坐标
	//T=1;
	//------------------------------------------------
	//以下均为0~100
	private double StraightAttackDesire;//上篮（直接进攻）欲望
	private double StraightAttackAccuracy;//上篮（直接进攻）准确度
	//--------------------------------------------------
	private double MiddleDistanceShootDesire;//球员中距离出手欲望
	private double ShoutDistanceShootDesire;//	球员短距离出手欲望
	private double LongDistanceShootDesire;//球员长距离出手欲望
	
	private double MiddleDistanceShootAccuracy;//中距离准度
	private double ShoutDistanceShootAccuracy;//近距离准度
	private double LongDistanceShootAccuracy;//长距离准度
	
	//---------------------------------------------
	private double PassDesire;//传球欲望
	private double PassAccuracy;//传球精准度
	//------------------------------------------
	private double TacticsDesire;//战术执行力
	private double TacticsEfficiency;//战术执行效率
	private double CoverEfficiency;//挡拆效果
	//-------------------------------------------

    //-----------------------------------------------
	private double MoveSpeed;//进攻空手移速开根号得到 m/s
    private double AttackMoveSpeed;//持球移速
    private double AttackSpeed;
    private double AttackReflection;//进攻球员进攻机会捕捉
    //---------------------------------------------
    private double Energy;//体力
    private double Mood;//心情
    private double Zone;//手感
    //-----------------------------------------------
    private double DefenseEfficiency;//防守战术执行效率
	private double DefenseMoveSpeed;//防守速度
    private double DefenseIntension;//防守强度
    private double DefenseReflection;//防守反射（灵性）
    private double DefenseDesire;//防守欲望
  //private int BlockDesire;//
  //private int StealDesire;//   
  //private int FoulDesire;//  
    //----------------------------------------------
    private double StaticSensedDefense;//静态防守强度
    private double DynamicSensedDefense;//动态防守强度
    private double ChancePoint;//空位分数
    
//--------------------------------------------------------------------------------------------    
	public Player() {// TODO Auto-generated constructor stub
	}

//-------------------------------	------------------------------------------------------------
	public boolean ifAttacking(){
		return Attacking;
	} 
	public double getHinder(){
		return Hinder;
	}
	public double getDirection(){
		return Direction;
	}
	public double getSAD(){
		return StraightAttackDesire;
	}
	public double getSAA(){
		return StraightAttackAccuracy;
	}
	public double getMDSD(){
		return MiddleDistanceShootDesire;
	}
	public double getSDSD(){
		return ShoutDistanceShootDesire;
	}
	public double getLDSD(){
		return LongDistanceShootDesire;
	}
	public double getMDSA(){
		return MiddleDistanceShootAccuracy;
	}
	public double getLDSA(){
		return LongDistanceShootAccuracy;
	}
	public double getSDSA(){
		return ShoutDistanceShootAccuracy;
	}
	public double getPD(){
		return PassDesire;
	}
	public double getPA(){
		return PassDesire;
	}
    public double getTD(){
    	return TacticsDesire;
    }
	public double getTE(){
		return TacticsEfficiency;
	}
	public double getCE(){
		return CoverEfficiency;
	}
	public double getMS(){
		return MoveSpeed;
	}
	public double getAMS(){
	      return AttackMoveSpeed;	
	}
	public double getAS(){
		return AttackSpeed;
	}
	public double getAR(){
		return AttackReflection;
	}
	public double getE(){
		return Energy;
	}
	public double getM(){
		return Mood;
	}
	public double getZ(){
		return Zone;
	}
	public double getDE(){
		return DefenseEfficiency;
	}
	public double getDMS(){
		return DefenseMoveSpeed;
	}
	public double getDI(){
		return DefenseIntension;
	}
	public double getDR(){
		return DefenseReflection;
	}
	public double getDD(){
		return DefenseDesire;
	}
	public double getSSD(){
		return StaticSensedDefense;
	}
	public double getDSD(){
		return DynamicSensedDefense;
	}
	public double getPx(){
		return Position[0];
	}
	public double getPy(){
		return Position[1];
	}
	public String getAM(){
		return AttackMethod;
	}
	public double getCP(){
		return ChancePoint;
	}
	public boolean ifVIP(){
		return VIP;
	}
	public boolean ifBall(){
		return Ball;
	}
	public boolean ifDefending(){
		return Defending;
	}
	public Player getCounter(){
		return Counter;
	}
	public int getNumber(){
		return Number;
	}
	public String getName(){
		return Name;
	}
	
	//-----------------------------------
	public void setCounter(Player player){
		this.Counter=player;
	}	
	public  void setPosition(double x,double y){
		this.Position[0]=x;
		this.Position[1]=y;
	}
	public void setPx(double x){
		this.Position[0]=x;
	}
	public void setPy(double y){
		this.Position[1]=y;
	}

	public void setAttacking(){
		this.Attacking=true;
	}
	public void setH(double Hinder){
		this.Hinder=Hinder;
	}
	public void setSAD(int StraightAttackDesire){
		this.StraightAttackDesire=StraightAttackDesire;
	}
	public void setSAA(int StraightAttackAccuracy){
		this.StraightAttackAccuracy=StraightAttackAccuracy;
	}
	public void setMDSD(int MiddleDistanceShootDesire){
		this.MiddleDistanceShootDesire=MiddleDistanceShootDesire;
	}
	public void setSDSD( int ShoutDistanceShootDesire){
		this.ShoutDistanceShootDesire=ShoutDistanceShootDesire;
	}
	public void setLDSD(int LongDistanceShootDesire){
		this.LongDistanceShootDesire=LongDistanceShootDesire;
	}
	public void setMDSA(int MiddleDistanceShootAccuracy){
		this.MiddleDistanceShootAccuracy=MiddleDistanceShootAccuracy;
	}
	public void setLDSA(int LongDistanceShootAccuracy){
		this.LongDistanceShootAccuracy=LongDistanceShootAccuracy;
	}
	public void setSDSA(int ShoutDistanceShootAccuracy){
		this.ShoutDistanceShootAccuracy=ShoutDistanceShootAccuracy;
	}
	public void setPD(int PassDesire){
		this.PassDesire=PassDesire;
	}
	public void setPA(int PassAccuracy){
		this.PassAccuracy=PassAccuracy;
	}
    public void setTD(int TacticsDesire){
    	this.TacticsDesire=TacticsDesire;
    }
	public void setTE(int TacticsEfficiency){
		this.TacticsEfficiency=TacticsEfficiency;
	}
	public void setCE(int CoverEfficiency){
		this.CoverEfficiency=CoverEfficiency;
	}
	public void setMS(int MoveSpeed){
		this.MoveSpeed=MoveSpeed;
	}
	public void setAMS(int AttackMoveSpeed){
	      this.AttackMoveSpeed=AttackMoveSpeed;	
	}
	public void setAS(int AttackSpeed){
		this.AttackSpeed=AttackSpeed;
	}
	public void setAR(int AttackReflection){
		this.AttackReflection=AttackReflection;
	}
	public void setE(double d){
		this.Energy=d;
	}
	public void setM(double Mood){
		this.Mood=Mood;
	}
	public void setZ(double Zone){
		this.Zone=Zone;
	}
	public void setDE(int DefenseEfficiency){
		this.DefenseEfficiency=DefenseEfficiency;
	}
	public void setDMS(int DefenseMoveSpeed){
		this.DefenseMoveSpeed=DefenseMoveSpeed;
	}
	public void setDI(int DefenseIntension){
		this.DefenseIntension=DefenseIntension;
	}
	public void setDR(int DefenseReflection){
		this.DefenseReflection=DefenseReflection;
	}
	public void setDD(int DefenseDesire){
		this.DefenseDesire=DefenseDesire;
	}
	public void setSSD(double StaticSensedDefense){
		this.StaticSensedDefense=StaticSensedDefense;
	}
	public void setDSD(double DynamicSensedDefense){
		this.DynamicSensedDefense=DynamicSensedDefense;
	}
	public void setDirection(double Direction){
		this.Direction=Direction;
	}
	public void setAM(String AttackMethod){
		this.AttackMethod=AttackMethod;
	}
	public void LoseBall(){
		this.Ball=false;
	}
	public void GetBall(){
		this.Ball=true;
	}
	public void stopTactics(){
		this.Tactics=false;
	}
	public void setCP(double point){
		this.ChancePoint=point;
	}
	public void goodchance(){
		this.VIP=true;
	}
	public void setVIP(){
		this.VIP=true;
	}
	public void getDefending(){
		this.Defending=true;
	}
	public void loseDefending(){
		this.Defending=false;
	}
	public void setName(String name){
		this.Name=name;
	}
	public void setNumber(int number){
		this.Number=number;
	}
	
//------------------------------------------------------	
/*	public  final  void bubbleSort(double[] t) {

	        for(int i =0;i<t.length-1;i++) {
	            for(int j=0;j<t.length-i-1;j++) {//-1为了防止溢出
	                if(t[j]>t[j+1]) {
	                    double temp = t[j];  
	                    t[j]=t[j+1];
	                    t[j+1]=temp;
	            }
	            }    
	        }
	    }//冒泡排序（从小到大）<
//-----------------------------------------------
	public boolean inthePosition(Player player,double x,double y){
		boolean index=false;
		if(distanceToP(player,x,y)<0.2){
			index=true;
		}	
		return index;
	}
//-----------------------------------------------------------------------
	public double ChanceJudge(Player player){//进攻机会估值函数
		double point;
		
		point=player.getSSD()+player.getSDSD();
		
		return point;//没写传球安全性以及对应球员能力值
	}
//---------------------------------------------------------------	
	public void ReportPosition(Player player){
		String s1=player.getPx()+" ";
		String s2=player.getPy()+" ";
		System.out.println(s1+s2);
	}
//------------------------------------------------
	public void ChancePointCalculate(Player player[],Player[] defender){//计算每个人的进攻机会并找出VIP
		double[] point=new double[5];
		double[] ssd=new double[5];
	    double[] dsd=new double[5];
		for(int i=0;i<player.length;i++){
			SensingStaticDefense(player[i],defender);
			SensingDynamicDefense(player[i],defender);
			ssd[i]=player[i].getSSD();
			dsd[i]=player[i].getDSD();
		}

		for(int j=0;j<player.length;j++){
	             point[j]=ssd[j]+dsd[j];
	             player[j].setCP(ssd[j]+dsd[j]);	 
		}			
		bubbleSort(point);
		for(int i=0;i<player.length;i++){
			if(player[i].ChancePoint==point[0]){player[i].goodchance();}
		}
		
		
	}//算出每个人的空位程度并设置vip
	public Player TheVIP(Player[] player){		//进攻方机会最好的人
		int k=0;
		for(int i=0;i<player.length;i++){
			if(player[i].VIP){
				k=i;
			}		
		}	
		return player[k];
	}
	public  Player TheManWithBall(Player[] player ){//进攻方拿球的人

		  int k=0;
		  for(int i=0;i<player.length;i++){
			  if(player[i].Ball){k=i;}
		  }
		  return player[k];
	  }
	
//---------------------------------------------------------	  
	   public void SetPlayer(Player player)throws Exception{//从mat钟读取球员能力值
		      FileReader f=new FileReader("C:/A/player.text");      
	    	  BufferedReader dis=new BufferedReader(f);
	    	  String line=null;    	  
	    	  @SuppressWarnings("unused")
			float[] array = new float[40]; // 
		        @SuppressWarnings("unused")
				int ind = 0; 
		        String[] sp; 
		        float[] arr=new float[40]; 
		       try{  while((line=dis.readLine())!=null){ 
		        sp = line.split("	"); //将mat文件复制到txt后数据间默认是一个tab的距离
		        arr = new float[sp.length]; 
		        for(int j=0,l=sp.length;j<l;++j){ 
		          arr[j] = Float.parseFloat(sp[j]); 
		          
		        }}
	    	 
	    	  while((line=dis.readLine())!=null){
	    		  player.setAMS((int)arr[0]);
	    		  player.setAR((int)arr[1]);
	    		  player.setAS((int)arr[2]);
	    		  player.setCE((int)arr[3]);
	    		  player.setDD((int)arr[4]);
	    		  player.setDE((int)arr[5]);
	    		  player.setDI((int)arr[6]);
	    		  player.setDMS((int)arr[7]);
	    		  player.setDR((int)arr[8]);
	    		  player.setE((int)arr[9]);
	    		  player.setLDSA((int)arr[10]);
	    		  player.setLDSD((int)arr[11]);
	    		  player.setM((int)arr[12]);
	    		  player.setMDSA((int)arr[13]);
	    		  player.setMDSD((int)arr[14]);
	    		  player.setMS((int)arr[15]);
	    		  player.setPA((int)arr[16]);
	    		  player.setPD((int)arr[17]);
	    		  player.setSAA((int)arr[18]);
	    		  player.setSAD((int)arr[19]);
	    		  player.setSDSA((int)arr[20]);
	    		  player.setSDSD((int)arr[21]);
	    		  player.setSDSA((int)arr[22]);
	    		  player.setSDSD((int)arr[23]);
	    		  player.setSSD((int)arr[24]);
	    		  player.setTD((int)arr[25]);
	    		  player.setTE((int)arr[26]);
	    		  player.setZ((int)arr[27]);	    		  
	    	  }dis.close();
	    	  
	      }catch(IOException e){
	    	  e.printStackTrace();
	      }
	   
	   }
	   public void setPlayer(Player player){   
	       String[] Array = new String[50];    
	       try {
	            //   System.out.println(System.in);
	               FileReader fileReader = new FileReader("C:\\A\\player.txt");
	               @SuppressWarnings("resource")
				BufferedReader buf = new BufferedReader(fileReader);
	               int i = 0;
	               @SuppressWarnings("unused")
				String bufToString = "";
	               String readLine = "";
	                
	               while((readLine = buf.readLine()) != null){
	                   Array[i] = readLine;
	                   i++;
	               }
	          }
	           catch (Exception e) {
	               e.printStackTrace();
	           }
	       String[] arr2=Array[0].split(" ");
	       int[] arr=new int[50];
	       for(int i=0;i<arr2.length-1;i++){
	        	arr[i]=Integer.parseInt(arr2[i]);
	        }    
	  //     for(int j=0;j<arr2.length;j++){
	  //      	System.out.println(arr[j]);
	  //      }
	       				player.setAMS(arr[0]);
	       				player.setAR(arr[1]);
	       				player.setAS(arr[2]);
	       				player.setCE(arr[3]);
	       				player.setDD(arr[4]);
	       				player.setDE(arr[5]);
	       				player.setDI(arr[6]);
	       				player.setDMS(arr[7]);
	       				player.setDR(arr[8]);
	       				player.setE(arr[9]);
	       				player.setLDSA((int)arr[10]);
	       				player.setLDSD((int)arr[11]);
	       				player.setM((int)arr[12]);
	       				player.setMDSA((int)arr[13]);
	       				player.setMDSD((int)arr[14]);
	       				player.setMS((int)arr[15]);
	       				player.setPA((int)arr[16]);
	       				player.setPD((int)arr[17]);
	       				player.setSAA((int)arr[18]);
	       				player.setSAD((int)arr[19]);
	       				player.setSDSA((int)arr[20]);
	       				player.setSDSD((int)arr[21]);
	       				player.setSDSA((int)arr[22]);
	       				player.setSDSD((int)arr[23]);
	       				player.setSSD((int)arr[24]);
	       				player.setTD((int)arr[25]);
	       				player.setTE((int)arr[26]);
	       				player.setZ((int)arr[27]);	
	       }
	   
//---------------------------------------------------------
    public double DistanceBetween(Player playerA,Player playerB){//两个球员兼距离
	double distance = Math.sqrt(Math.pow(playerA.getPx()-playerB.getPx(),2)+Math.pow(playerA.getPy()-playerB.getPy(), 2));
	return distance;
}
    public double distanceToO(double x,double y){//某点到篮筐距离
		double distance=Math.sqrt(Math.pow(x,2)+Math.pow(y-14, 2));
		return distance;
	}
	public double distanceToO(Player player){//player到篮筐距离
		double distance=Math.sqrt(Math.pow((player.getPx()),2)+Math.pow(player.getPy()-14,2));
		return distance;
	}
	public double distanceToP(Player player,double x,double y){//player到某位置的距离
		double distance=Math.sqrt(Math.pow(player.getPy()-y,2)+Math.pow(player.getPx()-x, 2));
		return distance;
	}
	public double distanceToBlock(Player player){//防守者到进攻球员与篮筐连线的距离
		double distance;
		double k=TheAngleToO(player.Counter.getPx(), player.Counter.getPy());
		distance=(k*player.getPx()-player.getPy()+14)/(Math.sqrt(1+k*k));
		return distance;
	}
		//-------------------------------------------------
	public void AttackChoose(Player player){//攻击方式选择
		if(player.StraightAttackDesire-100*distanceToO(player)-player.getSSD()-player.getDSD()*0.5>=60){
			player.setAM("StraightAttack");
		}
		else
		{
			if(distanceToO(player)>=0.5){
				player.setAM("LongDistanceShoot");
			}
			else{
				if(distanceToO(player)>=0.2){
					player.setAM("MiddleDistanceShoot");
				}
				else{
					player.setAM("ShortDistanceShoot");
				}
			}
		}
	}
    public double AttackingPossiblity(Player player){//计算攻击成功率
		double p=0.0;//possiblity
	        if(player.getAM()=="StraightAttack"){
	        	p=player.getSAA()+player.getM()-player.getDSD();
                 player.setE(player.getE()-20*distanceToO(player));
	        }
	        else{
	        	if(player.getAM()=="LongDistanceShoot"){
	        	p=player.getSDSA()+player.getM()-player.getSSD();
	        	player.setE(player.getE()-3);
	        	}
	        	else{
	        		if(player.getAM()=="MiddleDistanceShoot"){
	        			p=player.getMDSA()+player.getM()-player.getSSD();
	        			player.setE(player.getE()-2);
	        		}
	        		else{
	        			p=player.getSDSA()+player.getM()-player.getSSD();
	        			player.setE(player.getE()-1);	        			
	        		}
	        	}     	
	        }
			return p;
	}
    public boolean Attack(Player player){//选择一种进攻方式，计算and返回成功or失败
		boolean result=false;		
		AttackChoose(player);
        double p=AttackingPossiblity(player);
            if(Math.random()<p){
            	result=true;
            }
		return result;
	}//选择进攻方式，进行进攻，返回成功||失败；
//----------------------------------------------------------
    public  void BeHinderedby(Player playerA,Player playerB){//减速
    	playerA.setH(playerA.getHinder()+playerB.getCE()/100);
    }
    public void Hinder(Player player,Player[] defender){//周围范围设置减速力场（修该movespeed）
    	for(int j=0;j<defender.length;j++){
    		if(DistanceBetween(defender[j], player)<1){
    			BeHinderedby(defender[j], player);}
  		  	}
    	}
    public void StopHinder(Player player,Player[] defender){//停止掩护，给被掩护的地方还原速度（+）
    	for(int j=0;j<defender.length;j++){
    		if(DistanceBetween(defender[j], player)<1){
    			defender[j].setH(defender[j].getHinder()-player.getCE()/100);}
  		  	}
    	}
    public double TheAngleTo(double x1,double y1,double x2,double y2){//两点间角度

		double Direction=Math.atan((y2-y1)/(x2-x1));
		return Direction;
	}
    public double TheAngleToO(double x,double y){//x,y与篮筐角度
		double Direction=Math.atan((14-y)/(0-x));
		return Direction;
	}
 //---------------------------------------------------------------------
	public void Move(Player player,double t){//player沿着自己朝向走
		double x=player.getMS()*Math.cos(player.getDirection())*t*(1-player.getHinder());
		double y=player.getMS()*Math.sin(player.getDirection())*t*(1-player.getHinder());	
		player.Position[0]=player.getPx()+x;
		player.Position[1]=player.getPy()+y;	
		//-----------------------------------
		player.setE(player.getE()-Math.sqrt(x*x+y*y));
		
	}
	public void MoveTurn(Player player,double t,double direction){//player转向direction方向，再走t的位移
        player.setDirection(direction);		
		double x=player.getMS()*Math.cos(player.getDirection())*t;
		double y=player.getMS()*Math.sin(player.getDirection())*t;	
		player.Position[0]=player.getPx()+x;
		player.Position[1]=player.getPy()+y;	
		//-----------------------------------
		player.setE(player.getE()-Math.sqrt(x*x+y*y));
	}
	public void MoveTo(Player player,double t,double x,double y){//player向着点（x，y）移动t的位移；
		double Direction=TheAngleTo(player.getPx(),player.getPy(),x,y);
         player.setDirection(Direction);
		double x0=Math.sqrt(player.getMS())*Math.cos(player.getDirection())*t;
		double y0=Math.sqrt(player.getMS())*Math.sin(player.getDirection())*t;	
		player.Position[0]=player.getPx()+x0;
		player.Position[1]=player.getPy()+y0;	
		//-----------------------------------
		player.setE(player.getE()-Math.sqrt(x0*x0+y0*y0));
	}
//-------------------------------------------------------
	public void passTo(Player playerA,Player playerB){//战术传球
	playerA.LoseBall();	
	double t=(playerA.getSSD()+playerB.getDSD())/100;
	double o=Math.random();
	if(o>t){
		playerB.GetBall();
	}
	//----------------------------------------
	playerA.setE(playerA.getE()-1);
	playerB.setE(playerB.getE()-1);
	}
    public void AttackpassTo(Player playerA,Player playerB){//A传给B并且让B进攻
		playerA.LoseBall();;
		double t=(playerA.getSSD()+playerB.getDSD())/100;
		double o=Math.random();
		if(o>t){
			playerB.Ball=true;
			playerB.setAttacking();//攻击指令
		}
		//----------------------------------------
		playerA.setE(playerA.getE()-1);
		playerB.setE(playerB.getE()-1);
	}
	public void Pass(Player[] player,Player[] defender){//传给VIP并且让其投篮来终止此次进攻（用于AI）
    	AttackpassTo(TheManWithBall(player),TheVIP(player));  
    	}
//------------------------------------------------------------	
   
//--------------------------------------------------
    public  void SensingStaticDefense(Player player,Player[] defender){//感受静态防守强度
	double[] distance=new double[5];
	for(int i=0;i<defender.length;i++){
		distance[i]=DistanceBetween(player,defender[i]);}
	double defense=0;
	for(int j=0;j<defender.length;j++){
		defense=defense+(1/(14*distance[j]))*defender[j].getDI();//数学建模啊兄弟
	}
	player.setSSD(defense);
}	
    public void SensingDynamicDefense(Player player,Player[] defender){//感受动态防守强度
	double[] distance=new double[5];
	for(int i=0;i<defender.length;i++){
		distance[i]=distanceToO(defender[i]);}
	double defense=0;
	for(int j=0;j<defender.length;j++){
		defense=defense+(1/(14*distance[j]+1))*defender[j].getDI();//数学建模啊兄弟
	}
	player.setSSD(defense);
	
	
}	
//--------------------------------------------  
	public boolean AttackCatch(Player[] player,Player[] defender){//如果持球者是VIP，那就进攻，如果不是，就传给VIP
		boolean index=false;
		if(TheManWithBall(player)==TheVIP(player)){
			if(Attack(TheVIP(player))){return true;}
			else{return false;}
		}
		else{
			Pass(player,defender);
		}
		
		return index;
	}
//--------------------------------------------------------
    public boolean TacticsThinking(Player[] player, Player[] defender){//决定是是否终止战术
	  boolean choice=false;
	  ChancePointCalculate(player,defender);
	  if(TheVIP(player).getCP()>TheManWithBall(player).getPD()/100){
		  choice=true;
	  }  
	  return choice;
  }
//----------------------------------------------   
    
    public  int AI(Player[] player, Player[] defender){
	 int result=0;//0继续战术，非0 终止战术 1 成功 -1 失败
	 ChancePointCalculate(player,defender);
	 if(TacticsThinking(player,defender)){if(AttackCatch(player,defender)){return 1;}else{return -1;}		  }	 
	 return result;
 }
	
//------------------------------------------------------------	          
	public void DefenderSearch(Player[] player,Player[] defender){//判断每个防守球员是否在合理的防守位置
		for(int i=0;i<defender.length;i++){
			if(defender[i].DistanceBetween(defender[i],defender[i].Counter)<1&&defender[i].distanceToBlock(defender[i])<0.2){
				defender[i].Defending=true;
			}
			else{
				defender[i].Defending=false;
			}
		}
	}
	public Player TheDefensingTargetOf(Player defender){//某人应该防守的人
		return defender.Counter;
	}
	public void DefenseMoveChoose1(Player[] player,Player defender,double t){//沿着对位者和篮筐连线的垂线移动		
			defender.setDirection(Math.atan(-1/((1-TheDefensingTargetOf(defender).getPy())/(0-TheDefensingTargetOf(defender).getPx()))));
			Move(defender, t);	
	}
	public void DefenseMoveChoose2(Player[] player,Player defender,double t){ //向着对位者移动				
			    player[0].MoveTo(Counter, t, Counter.getPx(), Counter.getPy());               		
	}
	public void DefenseMove(Player[] player,Player[] defender,double t){//检测防守状况，移动
		DefenderSearch(player, defender);
		for(int i=0;i<defender.length;i++){
			if(defender[i].Defending){}
			else{
				DefenseMoveChoose1(player,defender[i],t);
				DefenseMoveChoose2(player,defender[i],t);}
		}
			
	}
	


	*/
	
	
	
	
	
	
}
