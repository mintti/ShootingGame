using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByEBolt : MonoBehaviour
{
    private GameController gameController;
	private PlayerInfo playerInfo;
	private PlayerController playerController;

	public GameObject playerExplosion;
	public GameObject boltExplosion;
    void Start()
    {
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
		GameObject playerControllerObject = GameObject.FindWithTag ("Player");
		if (playerControllerObject != null) {
			playerController = playerControllerObject.GetComponent<PlayerController> ();
		}
		if (playerInfo == null) {
			Debug.Log ("Cannot find 'Player' script");
		}

    }

	void Update(){
		if (playerInfo.HP > 0 &&playerController.skill == true)
			Destroy (gameObject);
	
	}

    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Boundary") return;
		if (other.tag == "Skill") {
			Instantiate (boltExplosion, transform.position, transform.rotation);
			Destroy (gameObject);
		}

		if (other.tag == "Enemy") 	return;
		if (other.tag == "Boss") 	return;
        if (other.tag == "playerbolt") 	return;
		if (other.tag == "Skill") {
			Instantiate (boltExplosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}


		if (other.tag == "Player") {
			Instantiate (boltExplosion, transform.position, transform.rotation);
			playerInfo.AddHP (-1);
			gameController.UpdateHP ();
			Destroy(gameObject);

			if (playerInfo.HP > 0)
				return;
			Instantiate (playerExplosion, transform.position, transform.rotation);
			gameController.GameOver ();
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			other.gameObject.GetComponent<PlayerController> ().stop = true;

		}
    }
}