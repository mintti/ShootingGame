using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByItem : MonoBehaviour {
	private GameController gameController;
	private PlayerInfo playerInfo;

	public int itemNum;

	public GameObject text;
	public Transform textSpawn;

	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}

		GameObject playerInfoObject = GameObject.FindWithTag ("PlayerInfo");
		if (playerInfoObject != null) {
			playerInfo = playerInfoObject.GetComponent<PlayerInfo> ();
		}
		if (playerInfo == null) {
			Debug.Log ("Cannot find 'PlayerInfo' script");
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		

		if (other.tag == "Player") {
			if (itemNum == 1) 
				playerInfo.AddHP (1);
			else if (itemNum == 2) 
				playerInfo.AddPW ();
			Instantiate (text, textSpawn.position, textSpawn.rotation);
			Destroy (gameObject);

		}

	}
}
