using UnityEngine;
using System.Collections;

public class Simple_Player_View : MonoBehaviour {
	
	//La sensibilità.
	public float sensitivity = 5f;
	//Quanto è inclinata la visuale.
	float VerticalRotation;
	
	//Quanto si deve muovere la visuale orizzontale.
	float HorLook;
	
	//Quanto si deve muovere la visuale verticale.
	float VerLook;
	
	// Use this for initialization
	void Start () {
		//Blocca il puntatore.
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		//Se il giocatore clicca sullo schermo e il puntatore non è bloccato.
		if (Screen.lockCursor == false && Input.GetKeyDown ("Mouse1"))
			//Blocca il puntatore.
			Screen.lockCursor = true;
			
		//Calcola quanto si deve muovere la visuale orizzontale.
		HorLook = Input.GetAxis ("Mouse X") * Time.deltaTime * sensitivity;
		
		//Ruota il personaggio.
		transform.Rotate (0,HorLook, 0);
		
		//Calcola di quanto si deve muovere la visuale verticale.
		float VerLook = - Input.GetAxis ("Mouse Y") * Time.deltaTime * sensitivity;
		
		//Calcola quale sarebbe l'inclinazione della telecamera.
		VerticalRotation += VerLook;
		//Blocca l'inclinazione della telecamera ad un max e ad un min.
		VerticalRotation = Mathf.Clamp (VerticalRotation, -75f, 75f);
		
		//Ruota verticalmente la telecamera.
		Camera.main.transform.localRotation = Quaternion.Euler(VerticalRotation,0,0); 
	}
}
