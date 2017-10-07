using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

	public Rigidbody _keyboard;            
	public Transform _fireTransform;    
	public Slider _powerSlider; 

	public float _minLaunchForce = 15f; 
	public float _maxLaunchForce = 30f; 
	public float _maxChargeTime = 0.75f;

	public float _timeBetweenAttacks = 0.5f;
	float _timer;
	Animator _animator;

	private string _cireButton;         
	private float _currentLaunchForce;  
	private float _chargeSpeed;         
	private bool _fired;              

	private void OnEnable()
	{
		_currentLaunchForce = _minLaunchForce;
		_powerSlider.value = _minLaunchForce;
	}
	// Use this for initialization
	private void Start () 
	{
		_animator = GetComponent<Animator> ();	

		_chargeSpeed = (_maxLaunchForce - _minLaunchForce) / _maxChargeTime;
	}
	
	// Update is called once per frame
	private void Update ()
	{
		_timer += Time.deltaTime;

		if (_timer >= _timeBetweenAttacks && Input.GetMouseButtonDown (0)) {
			Attack ();
		}

			tryToFire ();
	}

	private void Attack()
	{
		_timer = 0f;
		Debug.Log ("Attack");
		_animator.SetTrigger ("Attack");
	}
		
	private void tryToFire()
	{
		_powerSlider.value = _minLaunchForce;

		if (_currentLaunchForce >= _maxLaunchForce && !_fired)
		{
			_currentLaunchForce = _maxLaunchForce;
			Fire ();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			_fired = false;
			_currentLaunchForce = _minLaunchForce;
		}
		else if (Input.GetMouseButton (1) && !_fired)
		{
			_currentLaunchForce += _chargeSpeed * Time.deltaTime;
			_powerSlider.value = _currentLaunchForce;
		}
		else if (Input.GetMouseButtonUp (1) && !_fired)
		{
			Fire ();
		}
	}
	private void Fire()
	{
		// Instantiate and launch the shell.

		Debug.Log ("Fire");
		_fired = true;

		Rigidbody shellInstance = Instantiate (_keyboard, _fireTransform.position, _fireTransform.rotation) as Rigidbody;
		Debug.Log (shellInstance.transform.position);
		shellInstance.velocity = _currentLaunchForce * _fireTransform.forward;
	
		_currentLaunchForce = _minLaunchForce;
	}

}
