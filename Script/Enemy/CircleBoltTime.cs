using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoltTime : MonoBehaviour {
	public GameObject shot;
	public Transform shotSpawn;
	public int oneShoting;
	public float speed;

	public float moveRate;
	private float nextMove;

	float slow;
	// Use this for initialization
	void Start() {
		slow = 1;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)) 	slow = 0.5f;
		if(Input.GetKeyUp(KeyCode.LeftShift))	slow = 1;
	}

	void FixedUpdate() {
		if (Time.time > nextMove) {
			nextMove = Time.time + moveRate + (slow<1 ? moveRate: 0);
			StartCoroutine(SpellStart ());
		}
	}

	public IEnumerator SpellStart() 
	{ 
		for(int i =0;i<oneShoting;i++) 
		{
			GameObject obj; 
			obj=(GameObject)Instantiate(shot, shotSpawn.position, shotSpawn.rotation); 
			obj.GetComponent<Rigidbody>().AddForce(new Vector3(speed*Mathf.Cos(Mathf.PI*2*i/oneShoting)*slow,
				0,
				speed*Mathf.Sin(Mathf.PI*i*2/oneShoting)*slow));
			obj.transform.Rotate(new Vector3(0f,(360*i/oneShoting),0f));
			yield return new WaitForSeconds(0.02f); 
		} 
	} 
}
