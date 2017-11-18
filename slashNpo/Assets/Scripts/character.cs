﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	//Estados de ação: 0 = idle; 1 = attack rock; 2 = attack_papel ; 3 attack_tesoura; 4 = Damage; 5 = Parry; 6 = Death;
	private int character_status = 0;

	//Animação: 0 = idle; 1 = attack rock; 2 = attack_papel ; 3 attack_tesoura; 4 = Damage; 5 = Parry; 6 = Death;
	private int character_current_anim = 0;

	//barra de energia
	public int character_energy = 3;

	//Aparência do personagem
	public int character_skin_id = 1;

	//caso esteja inicializado
	private bool character_active;

	private float anim_timer;
	public float attack_timer=1f;

	public bool invert_attack=false;

	private Vector3 initial_pos;
	private Vector3 attack_pos;

	public GameObject ballon;

	public mainController main;
	

	Animator anims;

	
	void Start () {
		gameObject.SetActive(false);
		character_active = false;		
		anims = GetComponent<Animator>();
		anim_timer = attack_timer;
		initial_pos = transform.position;
		attack_pos = initial_pos;
		attack_pos.x+=(!invert_attack)?20f:-20f;
	}	

	void Update () {
		processAnims();	
		changeEnergy (character_energy);
	}

	//inicializa o personagem com as características imputadas
	public void initialize(int skin, int energy){		
		changeSkin(skin);
		changeEnergy(energy);		
		gameObject.SetActive(true);
		character_active = true;
	}

	//muda o estado da ação 
	void changeStatus(int status){
		character_status = status;
	}

	//muda o estado da animação
	void changeAnim(int anim){
		character_current_anim = anim;
	}
		


	//muda o estado da energia
	void changeEnergy(int energy){
		character_energy = energy;
	}

	//muda a skin
	void changeSkin(int skin){
		character_skin_id = skin;
	}

	bool isActive(){
		return character_active;
	}

	void processAnims(){		
		if(character_current_anim!=0){
			anim_timer -= Time.deltaTime;			
			transform.position = Vector3.Lerp(initial_pos,attack_pos,0.25f);	
			if(anim_timer<attack_timer/2)
				changeAnim("none");
			if(anim_timer<0){
				anim_timer = attack_timer;
				character_current_anim=0;				
				transform.position = initial_pos;
				ballon.SetActive(true);
			}			
		}
	}

	void changeAnim(string animation){
		anims.SetBool("rock",false);
		anims.SetBool("paper",false);
		anims.SetBool("scisor",false);
		anims.SetBool("dead",false);
		if(animation!="none")
			anims.SetBool(animation,true);
	}


	public void attack(int a){			
		if(character_current_anim==0){
			character_current_anim = a;
			ballon.SetActive(false);
			if(a==1)
				changeAnim("rock");
			else if(a==2)
				changeAnim("paper");
			else if(a==3)
				changeAnim("scisor");
			else if(a==4)
				changeAnim("dead");			
		}
	}
}
