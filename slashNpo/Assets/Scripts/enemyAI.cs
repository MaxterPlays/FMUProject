using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class enemyAI : MonoBehaviour {

	int[,] enemy_attack;	
	int[] enemy_seeds;
	public int current_enemy=0;
	int current_attack=0;
	float timer_attack;
	public mainController main;	

	void Start () {
		enemy_seeds = new int[]{13,14,15,16,17,18};
		enemy_attack = new int[6,10];

		timer_attack=1.0f;
		generateAttackList();
	}
		
	void Update () {
		processCurrentAttack();
		
		
	}

	void generateAttackList(){
		for(int i=0;i<6;++i){
			Random.seed = enemy_seeds[i];
			for(int ii=0;ii<10;++ii){
				int attack=1;
				float val = Random.value;				
				if(val>0.33f && val<0.66f)
					attack=2;
				else if(val>0.66f)
					attack=3;				
				enemy_attack[i,ii] = attack;			
			}
		}
	}

	public int getCurrentAttack(){		
		int a = current_attack;
		a--;
		if(a<0)
			a=0;
		return enemy_attack[current_enemy,a];
	}

	public int getCurrentEnemy(){
		return current_enemy;
	}

	public void setCurrentEnemy(int enemy){
		 current_enemy = enemy;
	}	

	void updateAttack(){
		int attack = current_attack;
		current_attack++;
		if(current_attack>9)
			current_attack=0;
	}

	void processCurrentAttack(){
		if(main.getGameStatus()==1){
			timer_attack -= Time.deltaTime;
			if(timer_attack<0){
				timer_attack = Random.value+0.5f;
				updateAttack();								
				main.setBallon(enemy_attack[current_enemy,current_attack]);				
				//Debug.Log("Debug de ataque:"+enemy_attack[current_enemy,current_attack]+" : "+getCurrentAttack());				
			}			
		}		
	}
}