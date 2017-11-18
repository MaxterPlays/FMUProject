using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerUI : MonoBehaviour {

	/*
	//Botões de ação
	Button bt_rock;
	Button bt_paper;
	Button bt_scisor;

	//Botões de controle
	Button bt_pause;	

	//Botões de Menu de Pausa
	Button bt_back_2game;
	Button bt_main_menu;
	Button bt_mute;

	//Botões da menu "SAIDA"
	Button bt_exit_yes;
	Button bt_exit_no;

	//Botões do Menu Principal*/


	/*Button bt_play;
	Button bt_exit;
	Button bt_credits;
	Button bt_mute_main;
	Button bt_rate;
	*/

	public mainController main;
	public Text battle_text;
	public bool text_counter_bool =false;
	public float text_counter = 2;

	public mediaControl media;

	void Start () {
		
	}


	public void battleStartText(){
		if (text_counter_bool){
			battle_text.text = ("Preparai-vos");
			text_counter += 30 * Time.deltaTime;
			int f_text_counter = Mathf.RoundToInt (text_counter);
			battle_text.fontSize = 150 - f_text_counter;
			if (text_counter > 50) {
				battle_text.text = ("Atacai !");
				media.playAudio (3,true);
				battle_text.fontSize = 150;
				Invoke ("setBoolOff", 0.5f);
			}
			}
	}

	void setBoolOff(){
		
		battle_text.text = ("");
		text_counter_bool = false;
		main.playable = true;

	}

	//Muda a propriedade status da jogada: bt_rock,bt_paper,bt_scisor
	public void onActionClick(int act){
		Debug.Log("ActionClick: "+act);
	}

	//Pausa o jogo: bt_pause
	public void onPauseClick(){
		Debug.Log("onPause");
	}

	// Chama o main menu a partir do menu de pausa: bt_main_menu
	public void onExit2MainClick(){
		Debug.Log("onExit2MainClick");
	}

	//Confirma a saida para o main menu: bt_exit_yes, bt_exit_no
	public void onExitMainClick(){
		main.btnExitMatch ();
	}

	//Inicia o jogo: bt_play
	public void onBtnGameStartClick(){		
		main.onGameStartClick ();
	}

	public void onBtnMainMenuClick(){
		main.onMainMenuClick ();
	}
	
	//Sai do jogo: bt_exit
	public void onExitClick(){
		Debug.Log("onExitClick");
	}

	//Exibe Créditos: bt_credits
	public void onBtnCreditsClick(){		
		main.onCreditsClick ();
	}

	//Liga/desliga Mudo: bt_mute, bt_mute_main
	public void onMuteClick(){
		Debug.Log("onMuteClick");
	}

	//Rate do jogo: bt_rate
	public void onRateClick(){
		Debug.Log("onRateClick");
	}

	public void exitMatchBtn(){
		main.btnExitMatch ();
	}
}
