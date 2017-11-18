using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mediaControl : MonoBehaviour {

	AudioSource[] media; 

	/*
	 * Lista de IDs
	 * 0 - musica menu
	 * 1 - multidão
	 * 2 - metal bang
	 * 3 - grito
	 * 4 - slash A
	 * 5 - slash B
	 */


	void Start () {
		media = GetComponents<AudioSource> ();
	}

	public void playAudio(int id,bool status){
		if (id < media.Length) {
			if (status)
				media [id].Play ();
			else
				media [id].Stop ();
		}
			
	}
}
