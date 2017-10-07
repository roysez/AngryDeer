using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float _forceJumpConst = 1f;
	public float _walkSpeed = 2;
	public float _runSpeed = 6;

	public float _turnSmoothTime = 0.2f;
	float _turnSmoothVelocity;

	public float _speedSmoothTime = 0.1f;
	float _speedSmoothVelocity;
	float _currentSpeed;
	float _groundDistance = 0.1f;

	Animator _animator;
	Transform _cameraT;

	private Rigidbody _rigidbody;
	private GameObject _raycastPoint;

	private bool _canJump;

	Vector2 _axis;
	bool _running;

	void Start ()
	{
		_raycastPoint = GameObject.Find("RaycastPoint");
		_canJump = false;
		_running = false;
		_animator = GetComponent<Animator> ();
		_cameraT = Camera.main.transform;
		_rigidbody = GetComponent<Rigidbody>();
	}

	void Update () 
	{
		GetAllInput();
		tryToJump ();
	}

	void FixedUpdate()
	{
		move ();
	}

	void GetAllInput()
	{
		_axis = new Vector2 (Input.GetAxisRaw ("HorizontalPlayer"), Input.GetAxisRaw ("VerticalPlayer"));		
		_running = Input.GetKey (KeyCode.LeftShift);
		if(Input.GetKeyUp(KeyCode.Space))
		{
			_canJump = true;
		}
	}
	void tryToJump()
	{
		if(_canJump && IsGrounded())
		{
			Debug.Log ("Jump");

			_canJump = false;
			_rigidbody.AddForce(0f, _forceJumpConst, 0f, ForceMode.Impulse);
			// _animator.SetTrigger ("Jump");
		}
	}
	bool IsGrounded ()
	{
		RaycastHit hit;
		Ray landingRay = new Ray (_raycastPoint.transform.position, Vector3.down);

		if (Physics.Raycast (landingRay, out hit, _groundDistance + 0.3f)) 
		{
			{
				return true;
			}
		}
		return false;
	}
		
	private void move()
	{
		Vector2 inputDir = _axis.normalized;
		_canJump = Input.GetKey (KeyCode.Space);

		if (inputDir != Vector2.zero) 
		{
			float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + _cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref _turnSmoothVelocity, _turnSmoothTime);
		}

		float targetSpeed = ((_running) ? _runSpeed : _walkSpeed) * inputDir.magnitude;
		_currentSpeed = Mathf.SmoothDamp (_currentSpeed, targetSpeed, ref _speedSmoothVelocity, _speedSmoothTime);

		transform.Translate (transform.forward * _currentSpeed * Time.deltaTime, Space.World);

		float animationSpeedPercent = ((_running) ? 1 : .5f) * inputDir.magnitude;
		_animator.SetFloat ("speedPercent", animationSpeedPercent, _speedSmoothTime, Time.deltaTime);
	}



}
