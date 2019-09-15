using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {
	private GameController gameController;
	public GameObject PW;

	public int HP;
	public int power;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		}
	}
	void Update(){
		if(Input.GetKeyUp(KeyCode.H)){
			AddHP(1);
		}
		if (HP <= 0)
			gameController.restart = true;
	}


	public void AddHP(int i){
		HP+= i;
		gameController.UpdateHP ();
	}

	public void AddPW(){
		if (power < 3) {
			power++;
			Instantiate (PW, transform.position, transform.rotation);
		}
	}

		
}
