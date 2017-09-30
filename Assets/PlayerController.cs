using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	private float moveSpeed;

	private bool left;
	private bool right;
	private bool up;
	private bool down;

	private Vector3 offset;

	// Use this for initialization
	void Start () {

		transform.LookAt(
			transform.position + Camera.main.transform.rotation * Vector3.forward,
			Camera.main.transform.rotation * Vector3.up
		);

		rb = GetComponent<Rigidbody> ();
		moveSpeed = 17.0f;

		left = false;
		right = false;
		up = false;
		down = false;

		offset = Camera.main.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		left = Input.GetKey (KeyCode.A);
		right = Input.GetKey (KeyCode.D);
		up = Input.GetKey (KeyCode.W);
		down = Input.GetKey (KeyCode.S);

		int x = 0;
		int y = 0;

		if (left) {
			x--;
		}
		if (right) {
			x++;
		}
		if (up) {
			y++;
		}
		if (down) {
			y--;
		}

		Vector3 movement = new Vector3 (x, rb.velocity.y, y);
		movement.Normalize ();

		rb.velocity = movement * moveSpeed;
	}

	void FixedUpdate() {
		Camera.main.transform.position = Vector3.Lerp (Camera.main.transform.position, transform.position + offset, 0.5f);

	}
}
