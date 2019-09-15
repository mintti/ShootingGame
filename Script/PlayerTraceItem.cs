using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTraceItem : MonoBehaviour {

	private PlayerController playerController;
	private PlayerInfo playerInfo;
	private GameController gameController;

	private Transform _transform;
	private Transform playerTransform;
	private Vector3 dir;
	private Vector3 set;
	public float speed;
	public float slow = 1;


	void Start()
	{
		GameObject playerInfoObject = GameObject.FindWithTag ("PlayerInfo");
		if (playerInfoObject != null) {
			playerInfo = playerInfoObject.GetComponent<PlayerInfo> ();
		}
		if (playerInfo == null) {
			Debug.Log ("Cannot find 'PlayerInfo' script");
		}
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

		if (playerInfo.power == 1)
			set = new Vector3 (0, 0, 1);
		else if(playerInfo.power == 2)
			set = new Vector3 (0, 0, -1);
		else if(playerInfo.power == 3)
			set = new Vector3 (-1, 0, 0);
		else 
			set = new Vector3 (0, 0, 0);
	}

	void Update()
	{
		if (gameController.gameOver == true || playerController.stop ==true)
			Destroy (gameObject);
		
		if (Input.GetKey(KeyCode.LeftShift)) slow = 0.5f;
		if (Input.GetKeyUp(KeyCode.LeftShift)) slow = 1;

		playerTransform = playerController._transform;

		dir = playerTransform.position - _transform.position + set;
		dir.Normalize(); // 방향백터 :  값 / 거리 = 방향백터 
		_transform.position += dir * speed * Time.deltaTime *slow;
	}
}