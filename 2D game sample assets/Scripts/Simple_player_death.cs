using UnityEngine;
using System.Collections;

//Da attaccare al personaggio.
//Componenti richieste: Collider2D (set as normal collider)

public class Simple_player_death : MonoBehaviour {
	//Chiamato quando tocca un collider.
	void OnCollisionEnter2D (Collision2D other){
		//Se il l'oggetto del collider toccato ha la tag "Death".
		if (other.transform.tag == "Death")
			//Distruggi l'oggetto.
			Destroy (gameObject);
	}	
	
	//Chiamato quando sta toccando un collider.
	void OnCollisionStay2D (Collision2D other){
		//Se il l'oggetto del collider toccato ha la tag "Death".
		if (other.transform.tag == "Death")
			//Distruggi l'oggetto.
			Destroy (gameObject);
	}	
}
