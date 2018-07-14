using UnityEngine;
using System.Collections;

public class Simple_Player_Shoot_Hitscan : MonoBehaviour {

	//La retta.
	Ray Bullet_Hitscan;
	
	//Oggetto che contiene le informazioni su che cosa è stato colpito.
	RaycastHit HitInfo;

	// Update is called once per frame
	void Update () {		
		//Se il giocatore preme il pulsante per sparare.
		if (Input.GetButtonDown ("Fire1")) {
				//Crea un raggio che va dritto davanti al giocatore.
				Bullet_Hitscan = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
				//Se il raggio colpisce qualcosa.
				if (Physics.Raycast (Bullet_Hitscan, out HitInfo))
					//Se quel qualcosa è un nemico.
					if (HitInfo.transform.tag == "enemy")
						//Fallo diventare colpito.
						HitInfo.transform.tag = "hurt";
		}				
	}
}
