using UnityEngine;
using System.Collections;

public class Simple_Player_Movement : MonoBehaviour {


	//La velocità del movimento.
	public float speed = 5f;

	//L'altezza del salto.
	public float jump = 20f;

	//Usato per il movimento.
	Vector3 move= new Vector3(0,0,0);

	//Il CharacterController attaccato al personaggio.
	CharacterController CharC = new CharacterController();
	
	//Le componenti del moto.
	Vector3 movex;
	Vector3 movez;
	Vector3 movey;
		
	//La forza applicata da un trampolino.
	public float Force = 500f;


	// Use this for initialization
	void Start () {
		//Assegna alla variabile il CharacterController del personaggio.
		CharC = gameObject.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Calcola la componente x del moto.
		movex = Input.GetAxis("Horizontal") * speed * transform.forward;
		//Calcola la componente z del moto.
		movez = Input.GetAxis ("Vertical") * speed * transform.right;

			
		//Se il personaggio è a terra.
		if (CharC.isGrounded) {
			//Azzera la velocità di caduta.
			movey = 0;
			//Se viene premuto il tasto di salto.
			if (Input.GetButtonDown ("Jump")
				//Assegna una velocità verso l'alto al personaggio.
				movey = jump;
		}
		//Altrimenti diminuisci la velocità secondo la gravità
		else movey += Physics.gravity.y*Time.deltaTime;
		
		//Somma le tre componenti della velocità.
		move = movex + movey + movez;
		
		//Muovi il personaggio.
		CharC.Move (move*Time.deltaTime);