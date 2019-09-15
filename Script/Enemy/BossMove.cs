using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour {
	Transform _transform;
	private GameController gameController;
	private PlayerController playerController;

	private float N, M;
	public float speed;
	private int stage;
	private float position;

	private float slow = 1;
	private float HP;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}

		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null) {
			playerController = playerControllerObject.GetComponent<PlayerController> ();
		}
		if (playerController == null) {
			Debug.Log ("Cannot find 'Player' script");
		}

		_transform =this.gameObject.GetComponent<Transform> (); 
		this.gameObject.GetComponent<CircleBoltTime> ().enabled = false;
		this.gameObject.GetComponent<CircleBolt> ().enabled = false;
		this.gameObject.GetComponent<BossShot> ().enabled = false;
		this.gameObject.GetComponent<CircleBoltTime> ().oneShoting =30;

		N = Random.Range (6.5f, 9.5f);
		stage = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftShift))
			slow = 0.5f;
		if (Input.GetKeyUp (KeyCode.LeftShift))
			slow = 1;
		HP = this.gameObject.GetComponent<DestroyByContact> ().HP;

		//stage 0 : 입장
		if (stage == 0) {
			if (_transform.position.x >= N) {
				_transform.position -= (new Vector3 (speed * slow, 0, 0));
			} else {
				stage = 1;
				this.gameObject.GetComponent<DestroyByContact> ().AddHP (-1);
				N = Random.Range (4.5f, 9.5f);
				M = Random.Range (-1.2f, 7f);
			}
		}

		//stage 1공격과 이동
		if (playerController.stop == false) {
			if (stage == 1) {
				if (HP < 200 && HP >= 150) {
					this.gameObject.GetComponent<BossShot> ().enabled = true;
				} else if (HP < 150 && HP >= 100) {
					this.gameObject.GetComponent<BossShot> ().enabled = false;
					this.gameObject.GetComponent<CircleBolt> ().enabled = true;
				} else if (HP < 100 && HP >= 50) {
					this.gameObject.GetComponent<CircleBolt> ().enabled = false;
					this.gameObject.GetComponent<CircleBoltTime> ().enabled = true;
				} else if (HP < 50) {
					this.gameObject.GetComponent<CircleBoltTime> ().oneShoting =10;
					this.gameObject.GetComponent<BossShot> ().enabled = true;
				}
				
				if (_transform.position.x >= N) {
					_transform.position -= (new Vector3 ((speed * slow * 0.5f), 0, 0));
					if (_transform.position.x < N)
						N = Random.Range (-1.0f, 11f);
				} else {
					_transform.position += (new Vector3 ((speed * slow * 0.5f), 0, 0));
					if (_transform.position.x > N)
						N = Random.Range (-1.0f, 11f);
				}	
				
				if (_transform.position.z >= M) {
					_transform.position -= (new Vector3 (0, 0, (speed * slow * 0.5f)));
					if (_transform.position.z < M)
						M = Random.Range (-1.2f, 7.0f);
				} else {
					_transform.position += (new Vector3 (0, 0, (speed * slow * 0.5f)));
					if (_transform.position.z > M)
						M = Random.Range (-1.2f, 7.0f);
				}
			}
		} else {
			this.gameObject.GetComponent<CircleBoltTime> ().enabled = false;
			this.gameObject.GetComponent<CircleBolt> ().enabled = false;
			this.gameObject.GetComponent<BossShot> ().enabled = false;
		}
	}
}
