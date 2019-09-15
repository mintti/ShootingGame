using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour {
	public GameObject shot;
	public GameObject shot2;
	public GameObject shotSpawn;

	float nextFire;
	public float fireRate;

	float nextFire2;
	public float fireRate2;

	float slow;
	// Use this for initialization
	void Start () {

		nextFire = Time.time + fireRate;
		nextFire2 = Time.time + fireRate2;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) slow = 0.5f;
		if (Input.GetKeyUp(KeyCode.LeftShift)) slow = 1;

		if (nextFire < Time.time) {
			Instantiate (shot, transform.position, transform.rotation);
			nextFire = Time.time + fireRate +(slow < 1 ? fireRate : 0);
		}
		if (nextFire2 < Time.time) {
			Instantiate (shot2, transform.position, transform.rotation);
			nextFire2 = Time.time + fireRate2 + (slow < 1 ? fireRate : 0);
		}
	}
}
