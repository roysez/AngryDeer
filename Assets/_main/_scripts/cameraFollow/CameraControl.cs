using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public GameObject _playerGameObject;
	// Use this for initialization
	private float _turnSpeed = 6f;

	void Start () 
	{
		transform.position = _playerGameObject.transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.position = _playerGameObject.transform.position;
		float yRot = _playerGameObject.transform.rotation.y;
		float wRot = _playerGameObject.transform.rotation.w;
		transform.rotation = new Quaternion (0, yRot, 0, wRot);

		if (Input.GetAxis ("Mouse Y") < 0) 
		{
			transform.Rotate ((Vector3.right) * -_turnSpeed);
		}
		if(Input.GetAxis("Mouse Y") > 0)
		{
			transform.Rotate ((Vector3.right) * -_turnSpeed);
		}
		Debug.Log ("X: " + Input.GetAxis ("Mouse Y"));

	}
}
