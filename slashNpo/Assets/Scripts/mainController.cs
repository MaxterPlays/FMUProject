using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainController : MonoBehaviour {

	public character player;
	public character enemy;
	public Image player_energy;
	public Image enemy_energy;
	public Text timer;
	public playerUI ui;	

	int game_status=1;

	//TODO: musica e efeitos sonoros


	void Start () {
		//Primeira fase, config inicial
		player.initialize(1,3);
		enemy.initialize(2,3);		
	}	
	
	void Update () {
		
	}

	public int getGameStatus(){
		return game_status;
	}
}