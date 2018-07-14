using UnityEngine;
using System.Collections;

public class Simple_turret : MonoBehaviour {


	//Il tempo tra un proiettile e l'altro.
	public float FireTime = 3f;
	//A questa variabile verra' assegnato il prossimo momento in cui la torretta sparera'
	float nextShot = 0f;
	//Il proiettile sparato.
	GameObject Bullet;
	//Il prefab del proiettile che sparera'.
	public GameObject BulletPrefab;
	//La velocita' del proiettile
	public float BulletSpeed = 10f;
	

	// Update is called once per frame
	void Update () {
		//Se il momento attuale e' maggiore del tempo in cui il proiettile dovrebbe essere sparato.
		if (Time.time > nextShot) {
			//Crea un proiettile dove ora e' la torretta.
			Bullet = (GameObject) Instantiate (BulletPrefab, transform.position , transform.rotation);
			//Imposta il momento in cui la torretta sparera' di nuovo.
			nextShot = Time.time + FireTime;
			//Dai una spinta al proiettile.
			Bullet.rigidbody2D.AddForce (-transform.right * BulletSpeed, 0);
		}
	}
}
