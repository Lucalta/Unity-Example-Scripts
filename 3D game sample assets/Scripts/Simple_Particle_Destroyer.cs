using UnityEngine;
using System.Collections;

public class Simple_Particle_Destroyer : MonoBehaviour {
	
	public float Death_Timer = 2f;
	
	void Start () {
		Destroy (gameObject, Death_Timer);
	}
}
