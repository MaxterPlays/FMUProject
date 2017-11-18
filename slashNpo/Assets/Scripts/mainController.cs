using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainController : MonoBehaviour {
	//personagens
	public character player;
	public character enemy;

	public enemyAI enemy_AI;

	public Transform player_energy;
	public Transform enemy_energy;

	public Text timer;
	public Text fight_text;
	public Image ballon;
	public GameObject ballon_go;

	public bool playable;
	public GameObject panel;
	public Text panel_text;
	public GameObject rock;
	public GameObject paper;
	public GameObject scisor;
	public GameObject characters;
	public int start_player_energy;
	public int current_player_energy;
	public int start_enemy_energy;
	public int current_enemy_energy;
	public GameObject main_menu;
	public GameObject game_screen;
	public GameObject credits;

	public int attack_result;
	public int match_result;

	public playerUI playerUI;
	public int lvl;

	public mediaControl media;

	public bool inGame;
	int game_status=1;
	float time = 60f;

	//TODO: musica e efeitos sonoros


	void Start () {
		//Primeira fase, config inicial
		playerUI.text_counter_bool = true;
		playable = false;
	}	
	
	void Update () {
		if (inGame) {
			processaTempo ();
			if (playerUI.text_counter_bool) {
				panel.SetActive (false);
				playable = false;
				playerUI.battleStartText ();
				start_player_energy = player.character_energy;
				current_player_energy = start_player_energy;
				start_enemy_energy = enemy.character_energy;
				current_enemy_energy = start_enemy_energy;
				player.initialize (1, 3);
				enemy.initialize (2, 3);
				characters.SetActive (true);
				ballon_go.SetActive (true);
			}
		}
	}
	public void reset(){
		playerUI.text_counter_bool = true;
		panel.SetActive (false);
		time = 60;
		playable = false;
		inGame = false;
	}

	void startSequence(){
	
	}

	public void win(){
		panel.SetActive (true);
		panel_text.text = ("Ganhai-vos");
		inGame = false;
		time = 60;
		characters.SetActive (false);
	}

	public void loss(){
		panel.SetActive (true);
		media.playAudio (3,true);
		panel_text.text = ("Perdeste");
		inGame = false;
		time = 60;
		characters.SetActive (false);
	}

	public int getGameStatus(){
		return game_status;
	}

	public void playerAttack(int a){	
		if (playable) {	
			media.playAudio (4,true);
			player.attack (a);
			int e = enemy_AI.getCurrentAttack ();	
			media.playAudio (5,true);
			enemy.attack (e);
			attackResult (a, e);
			playable = false;
			Invoke ("rePlayable", 1.5f);
			media.playAudio (2,true);
		}
	}

	void rePlayable(){
		playable = true;
	}

	//1-Pedra 2-Papel 3-Tesoura
	public void attackResult(int a, int e){
		if (a == 1 && e == 1) {
			attack_result = 2;
		} else if (a == 1 && e == 2) {
			attack_result = 3;
			current_player_energy--;
		} else if (a == 1 && e == 3) {
			attack_result = 1;
			current_enemy_energy--;
		}
		if (a == 2 && e == 2) {
			attack_result = 2;
		} else if (a == 2 && e == 3) {
			attack_result = 3;
			current_player_energy--;
		} else if (a == 2 && e == 1) {
			attack_result = 1;
			current_enemy_energy--;
		}
		if (a == 3 && e == 3) {
			attack_result = 2;
		} else if (a == 3 && e == 1) {
			attack_result = 3;
			current_player_energy--;
		} else if (a == 3 && e == 2) {
			attack_result = 1;
			current_enemy_energy--;
		}

		Vector3 pos_p = player_energy.position;
		Vector3 pos_e = enemy_energy.position;
		pos_p.x = (0.33f * current_player_energy)*-1;
		pos_e.x = (0.33f * current_enemy_energy);
		player_energy.position = pos_p;
		enemy_energy.position = pos_e;


		if (current_player_energy == 0) {
			loss ();
		}
		else if (current_enemy_energy == 0) {

			win ();
		}
	}

	public void pauseGame(){
		Debug.Log("Pause");
	}

	public void setBallon(int b){
		rock.SetActive(false);
		paper.SetActive(false);
		scisor.SetActive(false);
		if(b==1)
			rock.SetActive(true);
		else if(b==2)
			paper.SetActive(true);
		else if(b==3)
			scisor.SetActive(true);
	}


	void processaTempo(){
		time -= Time.deltaTime*1;
		float t = Mathf.Floor(time);		
		if(t<0)
			t=0;
		timer.text = ""+t;

	}

	public void onGameStartClick (){
		media.playAudio (0,false);
		media.playAudio (1,true);
		game_screen.SetActive (true);
		main_menu.SetActive (false);
		inGame = true;
	}

	public void btnExitMatch(){
		reset ();
		game_screen.SetActive (false);
		main_menu.SetActive (true);
		media.playAudio (1,false);
		media.playAudio (0,true);
	}

	public void onMainMenuClick(){
		
		credits.SetActive (false);
		main_menu.SetActive (true);
	}

	public void onCreditsClick(){
		main_menu.SetActive (false);
		credits.SetActive (true);
	}

}
