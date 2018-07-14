using UnityEngine;
using System.Collections;

public class Target_Death_General : MonoBehaviour {
	
	//Particelle
	public GameObject Flame;
	//Quanto sono spostate le particelle dall'oggetto.
	public Vector3 sfaso;
	
	// Update is called once per frame
	void Update () {
		//Se l'oggetto è stato colpito.
		if (tag == "hurt"){			
			//Distruggilo dopo un poco.
			Destroy (gameObject, 0.2f);
			//Crea delle particelle.
			Instantiate (Flame, transform.position-sfaso, transform.rotation);
		}
	}
}
