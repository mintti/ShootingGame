using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BoundaryE
{
	public float xMin, xMax, zMin, zMax;
}

public class RandomRotator : MonoBehaviour 
{
	private Rigidbody rb;
	public float speed;
	public float slow = 1;
	public BoundaryE boundary;

	public float moveRate;
	private float nextMove;


	void Start ()
	{
		rb = GetComponent<Rigidbody>();

	}

	void FixedUpdate ()
	{
		float N = -0.5f;
		int M = Random.Range( -1,2);
		if (rb.position.z <= boundary.zMin || rb.position.z >= boundary.zMax)
			M = 0;
		
		if (Time.time > nextMove) {
			nextMove = Time.time + moveRate + (slow<1 ? 0.2f: 0);

		}
		transform.Translate(new Vector3(N* speed* slow, 0.0f,M* speed* slow) * Time.deltaTime);

		if(Input.GetKey(KeyCode.LeftShift)) 	slow = 0.5f;
		if(Input.GetKeyUp(KeyCode.LeftShift))	slow = 1;
		
	}

}