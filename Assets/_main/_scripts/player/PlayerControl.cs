using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour 
{
	private Rigidbody _rigidbody;

	private string _horizontalAxisName = "HorizontalPlayer";
	private string _verticaltalAxisName = "VerticalPlayer";

	private float _horizontalInputValue;
	private float _verticalInputValue;

	private float _moveSpeed = 12f;
	private float _turnSpeed = 6f;

	private Vector3 _moveVelocity;



	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void OnEnable ()
	{
		_rigidbody.isKinematic = false;
		_horizontalInputValue = 0f;
		_verticalInputValue = 0f;
	}

	private void OnDisable()
	{
		_rigidbody.isKinematic = true;
	}
		
	void Update () 
	{
		GetAxis ();
	}

	private void Start()
	{
	}

	void FixedUpdate()
	{
		move();
		if(Input.GetAxis("Mouse X") < 0)
			transform.Rotate((Vector3.up) * -_turnSpeed);
		if(Input.GetAxis("Mouse X") > 0)
			transform.Rotate((Vector3.up) * _turnSpeed);
	}

	void GetAxis()
	{
		_horizontalInputValue = Input.GetAxis (_horizontalAxisName);
		_verticalInputValue = Input.GetAxis (_verticaltalAxisName);
	}
		
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	void move()
	{
		Vector3 movementHorizontal = transform.right * _horizontalInputValue * _moveSpeed * Time.deltaTime;
		Vector3 movementVertical = transform.forward * _verticalInputValue * _moveSpeed * Time.deltaTime;

		_rigidbody.MovePosition (_rigidbody.position + movementHorizontal);
		_rigidbody.MovePosition (_rigidbody.position + movementVertical);
	}
}
