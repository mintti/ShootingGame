
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrace : MonoBehaviour {
	private PlayerController playerController;
	private GameController gameController;

	private Transform _transform;
	private Transform playerTransform;
	public Vector3 dir;

	public float speed;
	private float slow = 1;
	public float stopMove;


	void Start()
	{
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null) {
			playerController = playerControllerObject.GetComponent<PlayerController> ();
		}
		if (playerController == null) {
			Debug.Log ("Cannot find 'Player' script");
		}
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}

		_transform = this.gameObject.GetComponent<Transform> ();
		stopMove += Time.time;
	}


	void Update()
	{
		if (gameController.gameOver == true || playerController.stop == true)
			Destroy (gameObject);
		
		if (Input.GetKey(KeyCode.LeftShift)) slow = 0.5f;
		if (Input.GetKeyUp(KeyCode.LeftShift)) slow = 1;

		if (Time.time < stopMove) {
			playerTransform = playerController._transform;

			dir = playerTransform.position - _transform.position; 
			dir.Normalize ();
		}
		_transform.position += dir * speed * Time.deltaTime *slow;
	}
}

