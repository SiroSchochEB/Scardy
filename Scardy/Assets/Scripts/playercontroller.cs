using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class playercontroller : MonoBehaviour {
	
	public float moveSpeed;
	private Rigidbody myRigidbody;

	private Vector3 moveInput;
	private Vector3 moveVelocity;

	private Camera mainCamera;

	private Vector2 move;


	public void OnMove(InputAction.CallbackContext context)
	{
		move = context.ReadValue<Vector2>();
	}
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody> ();
		mainCamera = FindObjectOfType<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		//moveInput = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f, Input.GetAxisRaw ("Vertical")); //movment
		//moveVelocity = moveInput * moveSpeed;
		movePlayer();
	}

	public void movePlayer() {

		Vector3 movment = new Vector3 (move.x, 0f, move.y); //movment

		//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movment), 0.15f);

		transform.Translate(movment * moveSpeed * Time.deltaTime, Space.World);
	}

	void FixedUpdate () {
		myRigidbody.velocity = moveVelocity;
	}
}

