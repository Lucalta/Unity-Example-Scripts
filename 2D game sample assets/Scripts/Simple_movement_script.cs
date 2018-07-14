using UnityEngine;
using System.Collections;

//Da attaccare al personaggio.
//Componenti richieste: Rigidbody2D, Collider2D (set as trigger), Collider2D (set as normal collider)

public class Simple_movement_script : MonoBehaviour {

	//La velocità orizzontale.
	public float xVelocity = 4f;
	//La velocità verticale (di salto).
	public float yVelocity = 8f;
	
	//La velocità massima di caduta. Quando il giocatore cade più veloce viene rallentato fino a cadere a questa velocità.
	public float MaxFallVelocity = 8f;
	
	//Usato dallo script per controllare se il giocatore può saltare o no. Quando il personaggio torna è sempre possibile saltare.
	bool hasJump = true;
	
	//Quanto dura il salto.
	public float JumpTimer = 0.5f;
	//Usato dallo script per contare il tempo di salto rimanente.
	float _jumpTimer;


	//Start viene chiamato quando l'oggetto viene creato.
	void Start () {

	}

	//Update viene chiamato ogni frame.
	void Update () {
		//Se il giocatore sta cadendo troppo veloce.
		if (rigidbody2D.velocity.y < - MaxFallVelocity)
			//Ferma la velocità al massimo consentito.
			rigidbody2D.AddForce(new Vector2 (0, - (MaxFallVelocity + rigidbody2D.velocity.y)/Time.deltaTime));
		
		//Controlla se il giocatore sta premendo un pulsante direzionale (sx, dx).
		//Se sta premendo il tasto per andare a destra.
		if (Input.GetAxis("Horizontal") > 0)
			//Imposta la velocità verso destra.
			rigidbody2D.AddForce(new Vector2 ((xVelocity - rigidbody2D.velocity.x)/Time.deltaTime, 0));
		//Se sta premendo il tasto per andare a sinistra.
		if (Input.GetAxis("Horizontal") < 0)
			//Imposta la velocità verso sinistra.
			rigidbody2D.AddForce(new Vector2 (-(xVelocity + rigidbody2D.velocity.x)/Time.deltaTime, 0));
			
		//Controlla se il giocatore ha premuto il pulsante per il salto in questo stesso frame.
		if (Input.GetButtonDown ("Jump"))
			//Controlla se il giocatore può ancora saltare.
			if (hasJump){
				//Comincia a saltare.
				_jumpTimer = JumpTimer;
				//Impedisci altri salti.
				hasJump = false;
				
			}
			
		//Controlla se il giocatore ha ancora tempo di salto.
		if (_jumpTimer > 0){
			//Imposta la velocità verticale.
			rigidbody2D.AddForce(new Vector2 (0, (yVelocity - rigidbody2D.velocity.y)/Time.deltaTime));
			//Diminuisce il timer.
			_jumpTimer -= Time.deltaTime;
		}			
	}

	void OnTriggerStay2D(){
			hasJump = true;
		}
}
