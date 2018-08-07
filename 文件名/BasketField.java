package JRBM;

public class BasketField {
	public BasketField() {
		// TODO Auto-generated constructor stub
	}
	

	public static void main(String[] args){
		Tactics tactics=new Tactics();
			
		double T=0.05;	
		int k=0;
		
		Player[] player=new Player[5];
		Player[] defender=new Player[5];
		for(int i=0;i<player.length;i++){player[i]=new Player();tactics.setPlayer(player[i]);}
		for(int i=0;i<player.length;i++){defender[i]=new Player();tactics.setPlayer(defender[i]);}

		   player[0].setPx(-6.5);player[0].setPy(7);
		   player[1].setPx(-4);player[1].setPy(10.5);
		   player[2].setPx(7);player[2].setPy(14);
		   player[3].setPx(-4);player[3].setPy(10);
		   player[4].setPx(3.5);player[4].setPy(7);
		   
		   
		   defender[0].setPosition(-6, 7);
		   defender[1].setPosition(-5.5, 10.5);
		   defender[2].setPosition(7.5, 14.5);
		   defender[3].setPosition(-5, 9);
		   defender[4].setPosition(3.5,6.8);
		
		   player[0].setName("张啸天");
		   player[1].setName("wang qixiang");
		   player[2].setName("zhang zongyi");
		   player[3].setName("qian ziyang");
		   player[4].setName("ding ning");
		 
		   
		   defender[0].setName("James");
		   defender[1].setName("Kobe");
		   defender[2].setName("Jordan");
		   defender[3].setName("Curry");
		   defender[4].setName("Durant");
		   
		   for(int i=0;i<defender.length;i++){defender[i].setCounter(player[i]);}
		   
		   
		   
		   
		   tactics.ReportStatement(player, defender);

		   
		       System.out.println("start!-------------------------------");
			   double t1=0;
			   while(!tactics.inthePosition(player[1], 0, 7)&&k==0)	//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		       {    tactics.MoveTo(player[1], T, 0, 7);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
				    tactics.MoveTo(player[3], T, -5.8, 14);//@@@@@@@@@@@@@@@@@@@@@@@@@@
				    k=tactics.AI(player,defender);//@@@@@@@@@@@@@@@@@@@@
				    t1=t1+T;//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
				    tactics.DefenseMove(player, defender, T);
		       }   
			   System.out.println("after "+t1+"-----------------");
			   tactics.ReportStatement(player, defender);
			   tactics.ReportPosition(defender);
			   System.out.println("钱子洋和王qixiang跑位 ");
		if(k!=0){
			System.out.println("it is over!");
		if(k==1){System.out.println("get it!");}
		        else{System.out.println("Bad shoot");}
              System.exit(0);}
			   
			   //	   System.out.println(k);
			   
			   
		//	tactics.ReportStatement(player, defender);
			   
			
		System.out.println("the first tactics");
		       tactics.passTo(player[0],player[1]);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		       k=tactics.AI(player,defender);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		       System.out.println("张啸天传球给王qixiang");
		       
		       
		   	if(k!=0){
				System.out.println("it is over!");
			if(k==1){System.out.println("get it!");}
			        else{System.out.println("Bad shoot");}
	              System.exit(0);}
		       
		     
		
		       double t2=t1;
		       while(k==0&&!tactics.inthePosition(player[4], -3, 7.1)){//@@@@@@@@@@@@@@@@@@@@@@@@@@@
		     	  tactics.MoveTo(player[4], T, -3.1, 7.1);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		     	  k=tactics.AI(player,defender);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2	    	  
		          t2=t2+T;
		          tactics.DefenseMove(player, defender, T);}  
		       
		       
		       
		     System.out.println("after"+t2+"----------------------------------------------");
		     tactics.ReportStatement(player, defender);
		     System.out.println("丁宁过来挡拆");
		 	if(k!=0){
				System.out.println("it is over!");
			if(k==1){System.out.println("get it!");}
			        else{System.out.println("Bad shoot");}
	              System.exit(0);}
		       
		       
		       
		       double t3=t2;
		       while(k==0&&!tactics.inthePosition(player[1], 3.5, 7.1)){//@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		     	  tactics.Hinder(player[4], defender);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		     	  tactics.MoveTo(player[1], T, 3.5, 7);//@@@@@@@@@@@@@@@@@@@@@@@@@@2
		     	  k=tactics.AI(player,defender);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		          t3=t3+T;
		          tactics.DefenseMove(player, defender, T);
		       }//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

		       System.out.println("after"+t3+"--------------------------------------------------");
		       tactics.ReportStatement(player, defender);
		       tactics.ReportPosition(defender);
		       System.out.println("钱子洋移动");
		   	if(k!=0){
				System.out.println("it is over!");
			if(k==1){System.out.println("get it!");}
			        else{System.out.println("Bad shoot");}
	              System.exit(0);} 
		       
		       
		       
		       
	/*	       double t4=t3;
		       while(k==0&&!tactics.inthePosition(player[1], 3.5, 7)){//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		     	  tactics.MoveTo(player[1], T, 3.5, 7);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		     	  k=tactics.AI(player,defender);//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		       t4=t4+T;
		       tactics.DefenseMove(player, defender, T);
		       }	
		       System.out.println("after"+t4+"-----------------------------");
		      
		   	if(k!=0){
				System.out.println("it is over!");
			if(k==1){System.out.println("get it!");}
			        else{System.out.println("Bad shoot");}
	              System.exit(0);}
		       
		   	
		       tactics.ReportStatement(player, defender);      
		 tactics.ReportPosition(defender);
		    */
		    
		    
		    if(tactics.AttackCatch(player,defender)){k=1;}//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		       else{k=-1;}//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@2
		       
		        if(k==1){System.out.println("get it!");}//@@@@@@@@@@@@@@@@@@@
		        else{System.out.println("Bad shoot");}//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
		
		
		
		
		
		
		
		
	}

	
	
}
