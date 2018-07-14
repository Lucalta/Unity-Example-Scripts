using UnityEngine;
using System.Collections;

//Da attaccare alla telecamera.

public class Simple_camera_follow : MonoBehaviour {

	//Il giocatore.
	public GameObject player;
	
	// Update is called once per frame
	void Update () {

		//Se non c'è un giocatore assegnato allo script.
		if (!player) {
			//Cerca di trovare ed assegnarli un giocatore.
			try {player = GameObject.FindGameObjectWithTag ("Player");} catch {}
		}


		//Se c'è un giocatore.
		if (player)
			//Posiziona la telecamera nella sua stessa posizione, ma un po' più indietro nell'asse z.
			transform.position = player.transform.position + new Vector3 (0,0,-10);
	}
}
