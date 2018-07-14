using UnityEngine;
using System.Collections;

//Da attaccare ai checkpoint
//Componenti richieste: SpriteRenderer, Collider2D (set as trigger).

public class Simple_checkpoint : MonoBehaviour {
	
	//Script attaccato alla telecamera.
	PlayerLife plife;
	
	//Due sprite, quello verde e quello rosso.
	public Sprite Activated;
	public Sprite Deactivated;
	
	//Lo sprite renderer dei due checkpoint:
	//Quello del checkpoint appena toccato.
	SpriteRenderer SpriRen;
	//Quello di quello vecchio.	
	SpriteRenderer OldSpriRen;
	//Il checkpoint vecchio.
	GameObject OldOne;
	
	// Use this for initialization
	void Start () {
		//Trova lo script attaccato alla telecamera principale.
		plife = Camera.main.GetComponent<PlayerLife> ();
		//Lo SpriteRenderer di questo checkpoint.
		SpriRen = GetComponent<SpriteRenderer> ();				                                              
	}
	
	//Viene chiamato quando qualcosa tocca il checkpoint.
	void OnTriggerStay2D (Collider2D other){
		//Se il checkpoint è disattivato (non ha la tag "Activated").
		if (tag == "Deactivated")
			//Se a toccarlo è il personaggio.
		if (other.transform.tag == "Player"){
			//Cambia lo sprite in quello verde.
			SpriRen.sprite = Activated;
			//Cerca di trovare un checkpoint già attivato (con la tag "Activated").
			OldOne = GameObject.FindGameObjectWithTag ("Activated");
			//Se esiste un checkpoint già attivato.
			if (OldOne){
				//Cambia la sua tag
				OldOne.tag = "Deactivated";
				//Cambia il suo sprite in quello rosso.
				OldOne.GetComponent<SpriteRenderer>().sprite = Deactivated;
			}
			//Imposta il punto di ritorno dell'altro script nel punto in cui e' il checkpoint nuovo.
			plife.CheckPoint = transform.position;
			//Cambia la tag del checkpoint nuovo.
			tag = "Activated";
			//Salva tutto cio` che deve essere salvato.
			Save();
		}
	}

	//Qui ci va tutto cio` che deve essere salvato quando si attiva un checkpoint
	//Per esempio puo` essere usato per salvare la posizione delle piattaforme e la loro direzione, oppure che cosa e` stato attivato.
	void Save(){

	}
}
