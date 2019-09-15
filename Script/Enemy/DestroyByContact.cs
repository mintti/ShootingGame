using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public int scoreValue;
	private GameController gameController;
	private PlayerInfo playerInfo;
	private PlayerController playerController;

	public GameObject explosion;
	public GameObject Colexplosion;
	public GameObject playerExplosion;
	public GameObject boltExplosion;


	float attRate;
	float nextAtt;
	bool skillC;
	private float skillRate= 2;
	private float nextSkill;

	public int enemyNum;
	public float HP;
	private bool c= false;
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
		attRate = 1;
		nextAtt = Time.time +attRate;
		skillC = true;
	}

	void Update(){
		if (playerInfo.HP > 0) {
			if (skillC == true && playerController.skill == true) {
				HP -= 10;
				skillC = false;
				nextSkill = Time.time + skillRate;
			} else {
				if (Time.time > nextSkill)
					skillC = true;
			}
		}
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary") return;



		if (other.tag == "Enemy") return ;
		if (other.tag == "Boss") return ;
		if (other.tag == "bg")  return;




		if (other.tag == "power") {
			AddHP (-0.2f);
			Destroy (other.gameObject);
			Instantiate (boltExplosion, transform.position, transform.rotation);
		}

		if (other.tag == "playerbolt") {
			AddHP (-1);
			Destroy (other.gameObject);
			Instantiate (boltExplosion, transform.position, transform.rotation);
		}

		if (other.tag == "Player") {
			playerInfo.AddHP (-1);
			gameController.UpdateHP ();

			if (enemyNum <3)
				Instantiate (explosion, transform.position, transform.rotation);
			else if (enemyNum ==3) 
				Instantiate (Colexplosion, transform.position, transform.rotation);

			if(enemyNum <4)
				Destroy (gameObject);
			c = true;

			if (playerInfo.HP > 0)
				return;
			Instantiate(playerExplosion, transform.position, transform.rotation);
			other.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
			other.gameObject.GetComponent<PlayerController> ().stop = true;
			gameController.GameOver ();

		}

		if (HP <= 0 && c == false) {
			Instantiate (explosion, transform.position, transform.rotation);
			gameController.AddScore (scoreValue);
			if(enemyNum == 4)
				gameController.BossUpdate ();
			Destroy (gameObject);
		}

	}

	public void AddHP(float i){
		HP+= i;
	}
}
