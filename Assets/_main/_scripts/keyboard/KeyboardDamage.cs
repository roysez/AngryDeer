using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardDamage : MonoBehaviour {

	// Use this for initialization
	public LayerMask _enemyMask;
	public ParticleSystem _damageParticles;

	public float _damage = 50f;
	public float _maxLifeTime = 2f;

	public float _thrust = 1;

	void Start () 
	{
		Destroy(gameObject, _maxLifeTime);
	}

	// Update is called once per frame
	void OnTriggerEnter (Collider other) 
	{
		Collider[] colliders = Physics.OverlapBox (transform.position, transform.lossyScale / 2, transform.rotation, _enemyMask);

		for (int i = 0; i < colliders.Length; ++i) 
		{
			Vector3 force = colliders [i].transform.position - transform.position;

			Rigidbody targetRigitbody = colliders [i].GetComponent<Rigidbody> ();
			if (!targetRigitbody) 
			{
				continue;
			}
			targetRigitbody.AddForce (force * _thrust);

			//EnemyHealth targetHeath = targetRigitbody.GetComponent<EnemyHealth> ();



		}
		Destroy (gameObject);
	}
	Vector3 getForce(Vector3 from , Vector3 to)
	{
		return to - from;
	}
}
