using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			
			Attack ();
				
		}
	}

	void Attack(){
		Debug.Log ("Attack");
		animator.SetTrigger ("Attack");
	}
}
