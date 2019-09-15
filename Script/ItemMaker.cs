using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMaker : MonoBehaviour {
	int N;
	private GameController gameController;

	public GameObject HPtext;
	public GameObject PWtext;
	public Transform textSpawn;

	public GameObject HP;
	public GameObject PW;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}

		Vector3 spawnPosition= gameController.RandomVetor();
		Quaternion spawnRotation = Quaternion.identity;

		N = Random.Range (1, 10);
		if (N % 2 == 0) {
			Instantiate (HP, spawnPosition, spawnRotation);
			Instantiate (HPtext, textSpawn.position, textSpawn.rotation);
		} else {
			Instantiate (HP, spawnPosition, spawnRotation);
			Instantiate (PWtext, textSpawn.position, textSpawn.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
