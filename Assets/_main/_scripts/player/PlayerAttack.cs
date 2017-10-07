using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	float timer;
	Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if(timer >= timeBetweenAttacks && Input.GetMouseButtonDown (0))
		{
			Attack ();
		}
	}

	void Attack(){
		timer = 0f;
		Debug.Log ("Attack");
		animator.SetTrigger ("Attack");
	}
}
