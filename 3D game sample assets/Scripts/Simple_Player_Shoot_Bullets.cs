using UnityEngine;
using System.Collections;

public class Simple_Player_Shoot_Bullets : MonoBehaviour {
	
	//Il prefab del proiettile.
	public GameObject Bullet_Prefab;
	//Il proiettile sparato.
	GameObject Bullet;
	//La spinta data al proiettile.
	public float impulse;
	//Il punto dal quale escono i colpi.
	public GameObject Barrel;
	
	// Update is called once per frame
	void Update () {		
		//Se il giocatore preme il pulsante per sparare.
		if (Input.GetButtonDown ("Fire1")) {
			//Crea un proiettile.
			Bullet = Instantiate (Bullet_Prefab, Barrel.transform.position, Barrel.transform.rotation) as GameObject;
			//Spingi il proiettile davanti al giocatore.
			Bullet.rigidbody.AddForce (impulse * -Bullet.transform.right);
		}
	}
}
