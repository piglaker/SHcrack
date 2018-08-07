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
  
	private String Name="Kobe";//��Ա����
	private int Number=0;//��Ա����
	private  Player Counter=null;//��λ
	private  boolean Ball=false;//����
	public  double Direction=0;//����0-360��
	private String AttackMethod;//��������
	private double Hinder=0;//����
	private boolean Attacking=false;
	private boolean Defending=false;
	private boolean Tactics=true;
	private  boolean VIP=false;
	protected static final double T = 0;
	public  double[] Position=new double[2];                      //x y ����
	//T=1;
	//------------------------------------------------
	//���¾�Ϊ0~100
	private double StraightAttackDesire;//������ֱ�ӽ���������
	private double StraightAttackAccuracy;//������ֱ�ӽ�����׼ȷ��
	//--------------------------------------------------
	private double MiddleDistanceShootDesire;//��Ա�о����������
	private double ShoutDistanceShootDesire;//	��Ա�̾����������
	private double LongDistanceShootDesire;//��Ա�������������
	
	private double MiddleDistanceShootAccuracy;//�о���׼��
	private double ShoutDistanceShootAccuracy;//������׼��
	private double LongDistanceShootAccuracy;//������׼��
	
	//---------------------------------------------
	private double PassDesire;//��������
	private double PassAccuracy;//����׼��
	//------------------------------------------
	private double TacticsDesire;//ս��ִ����
	private double TacticsEfficiency;//ս��ִ��Ч��
	private double CoverEfficiency;//����Ч��
	//-------------------------------------------

    //-----------------------------------------------
	private double MoveSpeed;//�����������ٿ����ŵõ� m/s
    private double AttackMoveSpeed;//��������
    private double AttackSpeed;
    private double AttackReflection;//������Ա�������Ჶ׽
    //---------------------------------------------
    private double Energy;//����
    private double Mood;//����
    private double Zone;//�ָ�
    //-----------------------------------------------
    private double DefenseEfficiency;//����ս��ִ��Ч��
	private double DefenseMoveSpeed;//�����ٶ�
    private double DefenseIntension;//����ǿ��
    private double DefenseReflection;//���ط��䣨���ԣ�
    private double DefenseDesire;//��������
  //private int BlockDesire;//
  //private int StealDesire;//   
  //private int FoulDesire;//  
    //----------------------------------------------
    private double StaticSensedDefense;//��̬����ǿ��
    private double DynamicSensedDefense;//��̬����ǿ��
    private double ChancePoint;//��λ����
    
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
	            for(int j=0;j<t.length-i-1;j++) {//-1Ϊ�˷�ֹ���
	                if(t[j]>t[j+1]) {
	                    double temp = t[j];  
	                    t[j]=t[j+1];
	                    t[j+1]=temp;
	            }
	            }    
	        }
	    }//ð�����򣨴�С����<
//-----------------------------------------------
	public boolean inthePosition(Player player,double x,double y){
		boolean index=false;
		if(distanceToP(player,x,y)<0.2){
			index=true;
		}	
		return index;
	}
//-----------------------------------------------------------------------
	public double ChanceJudge(Player player){//���������ֵ����
		double point;
		
		point=player.getSSD()+player.getSDSD();
		
		return point;//ûд����ȫ���Լ���Ӧ��Ա����ֵ
	}
//---------------------------------------------------------------	
	public void ReportPosition(Player player){
		String s1=player.getPx()+" ";
		String s2=player.getPy()+" ";
		System.out.println(s1+s2);
	}
//------------------------------------------------
	public void ChancePointCalculate(Player player[],Player[] defender){//����ÿ���˵Ľ������Ტ�ҳ�VIP
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
		
		
	}//���ÿ���˵Ŀ�λ�̶Ȳ�����vip
	public Player TheVIP(Player[] player){		//������������õ���
		int k=0;
		for(int i=0;i<player.length;i++){
			if(player[i].VIP){
				k=i;
			}		
		}	
		return player[k];
	}
	public  Player TheManWithBall(Player[] player ){//�������������

		  int k=0;
		  for(int i=0;i<player.length;i++){
			  if(player[i].Ball){k=i;}
		  }
		  return player[k];
	  }
	
//---------------------------------------------------------	  
	   public void SetPlayer(Player player)throws Exception{//��mat�Ӷ�ȡ��Ա����ֵ
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
		        sp = line.split("	"); //��mat�ļ����Ƶ�txt�����ݼ�Ĭ����һ��tab�ľ���
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
    public double DistanceBetween(Player playerA,Player playerB){//������Ա�����
	double distance = Math.sqrt(Math.pow(playerA.getPx()-playerB.getPx(),2)+Math.pow(playerA.getPy()-playerB.getPy(), 2));
	return distance;
}
    public double distanceToO(double x,double y){//ĳ�㵽�������
		double distance=Math.sqrt(Math.pow(x,2)+Math.pow(y-14, 2));
		return distance;
	}
	public double distanceToO(Player player){//player���������
		double distance=Math.sqrt(Math.pow((player.getPx()),2)+Math.pow(player.getPy()-14,2));
		return distance;
	}
	public double distanceToP(Player player,double x,double y){//player��ĳλ�õľ���
		double distance=Math.sqrt(Math.pow(player.getPy()-y,2)+Math.pow(player.getPx()-x, 2));
		return distance;
	}
	public double distanceToBlock(Player player){//�����ߵ�������Ա���������ߵľ���
		double distance;
		double k=TheAngleToO(player.Counter.getPx(), player.Counter.getPy());
		distance=(k*player.getPx()-player.getPy()+14)/(Math.sqrt(1+k*k));
		return distance;
	}
		//-------------------------------------------------
	public void AttackChoose(Player player){//������ʽѡ��
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
    public double AttackingPossiblity(Player player){//���㹥���ɹ���
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
    public boolean Attack(Player player){//ѡ��һ�ֽ�����ʽ������and���سɹ�orʧ��
		boolean result=false;		
		AttackChoose(player);
        double p=AttackingPossiblity(player);
            if(Math.random()<p){
            	result=true;
            }
		return result;
	}//ѡ�������ʽ�����н��������سɹ�||ʧ�ܣ�
//----------------------------------------------------------
    public  void BeHinderedby(Player playerA,Player playerB){//����
    	playerA.setH(playerA.getHinder()+playerB.getCE()/100);
    }
    public void Hinder(Player player,Player[] defender){//��Χ��Χ���ü����������޸�movespeed��
    	for(int j=0;j<defender.length;j++){
    		if(DistanceBetween(defender[j], player)<1){
    			BeHinderedby(defender[j], player);}
  		  	}
    	}
    public void StopHinder(Player player,Player[] defender){//ֹͣ�ڻ��������ڻ��ĵط���ԭ�ٶȣ�+��
    	for(int j=0;j<defender.length;j++){
    		if(DistanceBetween(defender[j], player)<1){
    			defender[j].setH(defender[j].getHinder()-player.getCE()/100);}
  		  	}
    	}
    public double TheAngleTo(double x1,double y1,double x2,double y2){//�����Ƕ�

		double Direction=Math.atan((y2-y1)/(x2-x1));
		return Direction;
	}
    public double TheAngleToO(double x,double y){//x,y������Ƕ�
		double Direction=Math.atan((14-y)/(0-x));
		return Direction;
	}
 //---------------------------------------------------------------------
	public void Move(Player player,double t){//player�����Լ�������
		double x=player.getMS()*Math.cos(player.getDirection())*t*(1-player.getHinder());
		double y=player.getMS()*Math.sin(player.getDirection())*t*(1-player.getHinder());	
		player.Position[0]=player.getPx()+x;
		player.Position[1]=player.getPy()+y;	
		//-----------------------------------
		player.setE(player.getE()-Math.sqrt(x*x+y*y));
		
	}
	public void MoveTurn(Player player,double t,double direction){//playerת��direction��������t��λ��
        player.setDirection(direction);		
		double x=player.getMS()*Math.cos(player.getDirection())*t;
		double y=player.getMS()*Math.sin(player.getDirection())*t;	
		player.Position[0]=player.getPx()+x;
		player.Position[1]=player.getPy()+y;	
		//-----------------------------------
		player.setE(player.getE()-Math.sqrt(x*x+y*y));
	}
	public void MoveTo(Player player,double t,double x,double y){//player���ŵ㣨x��y���ƶ�t��λ�ƣ�
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
	public void passTo(Player playerA,Player playerB){//ս������
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
    public void AttackpassTo(Player playerA,Player playerB){//A����B������B����
		playerA.LoseBall();;
		double t=(playerA.getSSD()+playerB.getDSD())/100;
		double o=Math.random();
		if(o>t){
			playerB.Ball=true;
			playerB.setAttacking();//����ָ��
		}
		//----------------------------------------
		playerA.setE(playerA.getE()-1);
		playerB.setE(playerB.getE()-1);
	}
	public void Pass(Player[] player,Player[] defender){//����VIP��������Ͷ������ֹ�˴ν���������AI��
    	AttackpassTo(TheManWithBall(player),TheVIP(player));  
    	}
//------------------------------------------------------------	
   
//--------------------------------------------------
    public  void SensingStaticDefense(Player player,Player[] defender){//���ܾ�̬����ǿ��
	double[] distance=new double[5];
	for(int i=0;i<defender.length;i++){
		distance[i]=DistanceBetween(player,defender[i]);}
	double defense=0;
	for(int j=0;j<defender.length;j++){
		defense=defense+(1/(14*distance[j]))*defender[j].getDI();//��ѧ��ģ���ֵ�
	}
	player.setSSD(defense);
}	
    public void SensingDynamicDefense(Player player,Player[] defender){//���ܶ�̬����ǿ��
	double[] distance=new double[5];
	for(int i=0;i<defender.length;i++){
		distance[i]=distanceToO(defender[i]);}
	double defense=0;
	for(int j=0;j<defender.length;j++){
		defense=defense+(1/(14*distance[j]+1))*defender[j].getDI();//��ѧ��ģ���ֵ�
	}
	player.setSSD(defense);
	
	
}	
//--------------------------------------------  
	public boolean AttackCatch(Player[] player,Player[] defender){//�����������VIP���Ǿͽ�����������ǣ��ʹ���VIP
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
    public boolean TacticsThinking(Player[] player, Player[] defender){//�������Ƿ���ֹս��
	  boolean choice=false;
	  ChancePointCalculate(player,defender);
	  if(TheVIP(player).getCP()>TheManWithBall(player).getPD()/100){
		  choice=true;
	  }  
	  return choice;
  }
//----------------------------------------------   
    
    public  int AI(Player[] player, Player[] defender){
	 int result=0;//0����ս������0 ��ֹս�� 1 �ɹ� -1 ʧ��
	 ChancePointCalculate(player,defender);
	 if(TacticsThinking(player,defender)){if(AttackCatch(player,defender)){return 1;}else{return -1;}		  }	 
	 return result;
 }
	
//------------------------------------------------------------	          
	public void DefenderSearch(Player[] player,Player[] defender){//�ж�ÿ��������Ա�Ƿ��ں���ķ���λ��
		for(int i=0;i<defender.length;i++){
			if(defender[i].DistanceBetween(defender[i],defender[i].Counter)<1&&defender[i].distanceToBlock(defender[i])<0.2){
				defender[i].Defending=true;
			}
			else{
				defender[i].Defending=false;
			}
		}
	}
	public Player TheDefensingTargetOf(Player defender){//ĳ��Ӧ�÷��ص���
		return defender.Counter;
	}
	public void DefenseMoveChoose1(Player[] player,Player defender,double t){//���Ŷ�λ�ߺ��������ߵĴ����ƶ�		
			defender.setDirection(Math.atan(-1/((1-TheDefensingTargetOf(defender).getPy())/(0-TheDefensingTargetOf(defender).getPx()))));
			Move(defender, t);	
	}
	public void DefenseMoveChoose2(Player[] player,Player defender,double t){ //���Ŷ�λ���ƶ�				
			    player[0].MoveTo(Counter, t, Counter.getPx(), Counter.getPy());               		
	}
	public void DefenseMove(Player[] player,Player[] defender,double t){//������״�����ƶ�
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
