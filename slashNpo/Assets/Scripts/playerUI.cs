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

	//Botões do Menu Principal
	Button bt_play;
	Button bt_exit;
	Button bt_credits;
	Button bt_mute_main;
	Button bt_rate;
	*/

	
	void Start () {
		
	}
		
	void Update () {
		
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
	public bool onExitMainChoiceClick(bool choice){

		return true;
	}

	//Inicia o jogo: bt_play
	public void onGameStartClick(){
		Debug.Log("onGameStartClick");
	}
	
	//Sai do jogo: bt_exit
	public void onExitClick(){
		Debug.Log("onExitClick");
	}

	//Exibe Créditos: bt_credits
	public void onCreditsClick(){		
		Debug.Log("onCreditsClick");
	}

	//Liga/desliga Mudo: bt_mute, bt_mute_main
	public void onMuteClick(){
		Debug.Log("onMuteClick");
	}

	//Rate do jogo: bt_rate
	public void onRateClick(){
		Debug.Log("onRateClick");
	}
}
