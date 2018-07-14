using UnityEngine;
using System.Collections;

//Da attaccare al personaggio.
//Componenti richieste: Rigidbody2D, Collider2D (set as trigger), Collider2D (set as normal collider), Animator (con tre booleani: isJumping, isWalking, isFalling).

public class Simple_movement_and_animator_script : MonoBehaviour {

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
	
	//Vi sarà assegnato l'animatore del personaggio.
	Animator animator;
	
	//Dice se il personaggio è girato a destra.
	bool isLeft = false;


	//Start viene chiamato quando l'oggetto viene creato.
	void Start () {
		animator = GetComponent<Animator> ();
	}

	//Update viene chiamato ogni frame.
	void Update () {
		//Se il giocatore sta cadendo troppo veloce.
		if (rigidbody2D.velocity.y < - MaxFallVelocity)
			//Ferma la velocità al massimo consentito.
			rigidbody2D.AddForce(new Vector2 (0, - (MaxFallVelocity + rigidbody2D.velocity.y)/Time.deltaTime));
		
		//Controlla se il giocatore sta premendo un pulsante direzionale (sx, dx).
		//Se sta premendo il tasto per andare a destra.
		if (Input.GetAxis("Horizontal") > 0){
			//Imposta la velocità verso destra.
			rigidbody2D.AddForce(new Vector2 ((xVelocity - rigidbody2D.velocity.x)/Time.deltaTime, 0));
			//Dice all'animatore che sta camminando.
			animator.SetBool ("isWalking", true);
			//Se il personaggio non è girato a destra.
			if (isLeft){
				//Dì che è girato a destra.
				isLeft = false;
				//Giralo a destra.
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}	
		}
		//Altrimenti se sta premendo il tasto per andare a sinistra.
		else if (Input.GetAxis("Horizontal") < 0){
			//Imposta la velocità verso sinistra.
			rigidbody2D.AddForce(new Vector2 (-(xVelocity + rigidbody2D.velocity.x)/Time.deltaTime, 0));
			//Dice all'animatore che sta camminando.
			animator.SetBool ("isWalking", true);
			//Se il personaggio non è girato a sinistra.
			if (!isLeft){
				//Dì che è girato a sinistra.
				isLeft = true;
				//Giralo a sinistra.
				transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
			}	
		}
		//Altrimenti se non sta premendo alcun bottone dice all'animatore che non sta più camminando.
		else animator.SetBool ("isWalking", false);
			
		//Controlla se il giocatore ha premuto il pulsante per il salto in questo stesso frame.
		if (Input.GetButtonDown ("Jump"))
			//Controlla se il giocatore può ancora saltare.
			if (hasJump){
				//Comincia a saltare.
				_jumpTimer = JumpTimer;
				//Impedisci altri salti.
				hasJump = false;
				//Dì all'animatore che sta saltando.
				animator.SetBool ("isJumping", true);
			}
			
		//Controlla se il giocatore ha ancora tempo di salto.
		if (_jumpTimer > 0) {
			//Imposta la velocità verticale.
			rigidbody2D.AddForce (new Vector2 (0, (yVelocity - rigidbody2D.velocity.y) / Time.deltaTime));
			//Diminuisce il timer.
			_jumpTimer -= Time.deltaTime;
		}
		//Altrimenti dice all'animatore che non sta più saltando.
		else {
			animator.SetBool ("isJumping", false);
		}
	}
	
	//Chiamato ogni frame in cui il collider tocca un oggetto.
	void OnTriggerStay2D(){
			//Rende possibile il salto.
			hasJump = true;
			//Dice all'animatore che non sta più cadendo.
			animator.SetBool ("isFalling", false);
		}
		
	//Chiamato ogni frame in cui il collider non tocca un oggetto.
	void OnTriggerExit2D(){
	animator.SetBool ("isFalling", true);
	}
}
