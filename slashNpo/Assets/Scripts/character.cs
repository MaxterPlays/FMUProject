using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

	//Estados de ação: 0 = idle; 1 = attack; 2 = attack_papel ; 3 attack_tesoura; 4 = Damage; 5 = Parry; 6 = Death;
	private int character_status = 0;

	//Animação: 0 = idle; 1 = attack; 2 = attack_papel ; 3 attack_tesoura; 4 = Damage; 5 = Parry; 6 = Death;
	private int character_current_anim = 0;

	//barra de energia
	public int character_energy = 3;

	//Aparência do personagem
	public int character_skin_id = 1;

	//caso esteja inicializado
	private bool character_active;

	
	void Start () {
		gameObject.SetActive(false);
		character_active = false;		
	}	

	void Update () {
		
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
}