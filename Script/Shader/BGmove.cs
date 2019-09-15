using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGmove : MonoBehaviour {
	public GameObject bg;
	public GameObject bg2;
	public float slow = 1;

	bool c;
	// Use this for initialization
	void Start () {
		c = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift)) 	slow = 0.5f;
		if(Input.GetKeyUp(KeyCode.LeftShift))	slow = 1;

		bg.transform.position += new Vector3 (0.01f* slow, 0, 0);
		bg2.transform.position += new Vector3 (0.01f* slow, 0, 0);
		if (c == false) {
			if (bg.transform.position.x > 11) {
				c = true;
				bg2.transform.position = new Vector3 (-50.0f, -10.0f, 0);
			}
		} else {
			if (bg2.transform.position.x > 11) {
				c = false;
				bg.transform.position = new Vector3 (-50.0f, -10.0f, 0);
			}
		}



	}
}
