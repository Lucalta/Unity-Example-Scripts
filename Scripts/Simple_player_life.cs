using UnityEngine;
using System.Collections;

//Da attaccare alla telecamera.

public class Simple_player_life : MonoBehaviour {

	//Il prefabbricato del personaggio.
	public GameObject PlayerPrefab;
	//Il punto in cui il personaggio torna dopo la morte.
	public Vector3 CheckPoint;
	//Il personaggio (quello presente, che si vede).
	GameObject player;
	
	//Il prefabbricato del messaggio che compare dopo la morte.
	public GameObject DeathMessage;
	//L'oggetto del messaggio (quello presente, che si vede).
	GameObject DMessage;
	//La rotazione di default.
	Quaternion defaultRotation;
	
	bool Respawning;

	// Use this for initialization
	void Start () {
		//Cerca e assegna il giocatore alla variabile "player".
		player = GameObject.FindGameObjectWithTag ("Player");
		//Assegna alla variabile la posizione del giocatore quando inizia il livello.
		CheckPoint = player.transform.position;
		//Assegna alla variabile la rotazione del giocatore quando inizia il livello.
		defaultRotation = player.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		//Se manca il personaggio.
		if (!player)
			//Se non esiste gia il messaggio
			if (!DMessage)
				//Crea il messaggio che compare alla morte.
				DMessage = Instantiate (DeathMessage, Camera.main.transform.position + new Vector3 (0,0,10), defaultRotation) as GameObject;

		
		//Se il personaggio non c'è e viene premuto il pulsante per tornare.
		if (Input.GetButtonDown ("Respawn") && !player) {
			//Crea il personaggio.
			player = Instantiate (PlayerPrefab, CheckPoint, defaultRotation) as GameObject;
			//Distrugge il messaggio.
			Destroy (DMessage);
			//Applica il codice necessario per il reset di tutte le altre cose che lo richiedono.
			Reset();
		}
	}
	
	//Codice per l'eventuale reset di un elemento.
	void Reset(){
	
	}
}
