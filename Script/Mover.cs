using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
	private Rigidbody rb;

	public float speed;
	private float slow = 1;

	// Use this for initialization

	void Start () {

		rb = GetComponent<Rigidbody> ();


	}
	void FixedUpdate ()
	{
		rb.velocity = transform.right * speed * slow;

		if(Input.GetKey(KeyCode.LeftShift)) 	slow = 0.5f;
		if(Input.GetKeyUp(KeyCode.LeftShift))	slow = 1;
	}

}