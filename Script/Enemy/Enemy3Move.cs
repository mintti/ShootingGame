using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Enemy3Move : MonoBehaviour {
	private Transform _transform;
	public GameObject animation;

    public float speed;
    private float slow = 1;

	public float nextFire;
	public float fireRate;

    private float x;
    // Use this for initialization
    void Start () {
		_transform = this.gameObject.GetComponent<Transform> ();

        x = Random.Range(-4, 9);
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)) slow = 0.5f;
		if (Input.GetKeyUp(KeyCode.LeftShift)) slow = 1;

		if(_transform.position.x > x )
			_transform.position -=(new Vector3(speed * slow,0,0));
		else{
			if (Time.time > nextFire) {
				fireRate = Time.time + fireRate + (slow < 1 ? fireRate : 0);
				gameObject.GetComponent<CircleBoltTime> ().enabled = true;
				animation.GetComponent<Animator> ().enabled = false;
				gameObject.GetComponent<AudioSource> ().enabled = false;
			}
		}

    }
}
