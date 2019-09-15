using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour {
	private PlayerInfo playerInfo;
	private PTBGChange bgc;
	private IEnumerator coroutine;

	//hazard
	public GameObject hazard;
	public int hazardCount;
	public float spawnWait;
	public bool hazard1Set;

	public GameObject hazard2;
	public float nextMove;
	public float moveRate;

	public GameObject hazard3;
	public float nextMove3;
	public float moveRate3;

	public GameObject boss;
	private float nextBoss;
	private float bossRate =2;
	public bool bossContol = false;

	public int faze;

	public Vector3 spawnValues;

	public Text scoreText;
	public Text gameOverText;
	public Text HPText;

	public bool gameOver;
	public bool restart; 
	public int score;
	private float slow;

	public int itemWait;

	public GameObject HP;
	public GameObject PW;


	void Start () {
		Screen.SetResolution(1200, 900, true); 

		GameObject playerInfoObject = GameObject.FindWithTag ("PlayerInfo");
		if (playerInfoObject != null) {
			playerInfo = playerInfoObject.GetComponent<PlayerInfo> ();
		}
		if (playerInfo == null) {
			Debug.Log ("Cannot find 'PlayerInfo' script");
		}
		GameObject bgcObject = GameObject.FindWithTag ("BGController");
		if (bgcObject != null) {
			bgc = bgcObject.GetComponent<PTBGChange> ();
		}
		if (bgc == null) {
			Debug.Log ("Cannot find 'BGController' script");
		}

		coroutine = SpawnWaves ();

		gameOver = false;
		restart = false;
		gameOverText.text = "";
		hazard1Set = true;
		bossContol = false;
		faze = 0;
		nextMove3 = 0;
		nextBoss = 0;

		itemWait = 0;
		slow = 1;
		score = 0;
		UpdateScore ();
		UpdateHP ();
	}

	void Update () {
		
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
			}
		}
		if(Input.GetKey(KeyCode.LeftShift)) 	slow = 0.5f;
		if(Input.GetKeyUp(KeyCode.LeftShift))	slow = 1;

		if (bossContol == false && hazard1Set == true) {
			StartCoroutine (coroutine);
			hazard1Set = false;
		}
			

		//hazard2 creat;
		if (score >= 1000 && Time.time > nextMove && gameOver==false && bossContol == false) {
			Vector3 spawnPosition= RandomVetor();
			Quaternion spawnRotation = Quaternion.identity;
			nextMove = Time.time + moveRate + (slow < 1 ? moveRate : 0);

			Instantiate (hazard2, spawnPosition, spawnRotation);
		}

		//hazard3 creat;
		if (score >= 3000 && Time.time > nextMove3 && gameOver == false&& bossContol == false) {
			Vector3 spawnPosition= RandomVetor();
			Quaternion spawnRotation = Quaternion.identity;
			nextMove3 = Time.time + moveRate3 + (slow < 1 ? moveRate3 : 0);

			Instantiate (hazard3, spawnPosition, spawnRotation);
		}
		//Boss creat;
		if (score >= 10000+faze && Time.time > nextBoss && gameOver == false && bossContol == false) {
			bossContol = true;
			StopCoroutine (coroutine);

			Vector3 spawnPosition= RandomVetor();
			Quaternion spawnRotation = Quaternion.identity;
			nextBoss = Time.time+bossRate + (slow < 1 ? bossRate : 0);

			Instantiate (boss, spawnPosition, spawnRotation);
		}

		if (score - itemWait * 1000 >= 1000) {		
			Vector3 spawnPosition = RandomVetor ();
			Quaternion spawnRotation = Quaternion.identity;


			int N = Random.Range (1, 10);
			if (N % 2 == 0)
				Instantiate (HP, spawnPosition, spawnRotation);
			else {
				if (playerInfo.power < 3)
					Instantiate (PW, spawnPosition, spawnRotation);
				else
					Instantiate (HP, spawnPosition, spawnRotation);
			}
			itemWait++;
		}

		if (gameOver) {
			restart = true;
		}
	}

	//harzard1
	IEnumerator SpawnWaves () {
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				Vector3 spawnPosition = RandomVetor ();
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);

				yield return new WaitForSeconds (2.0f);
			}
		}
	}

	public Vector3 RandomVetor(){
		return (new Vector3 (spawnValues.x, spawnValues.y, Random.Range (-spawnValues.z + 6, spawnValues.z)));
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!" ;
		gameOver = true;
	}


	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		bgc.CC ();

	}
	void UpdateScore()
	{
		scoreText.text = " " + score + " ";
	}

	public void UpdateHP(){
		HPText.text = "";
		for (int i = 0; i < playerInfo.HP; i++)
			HPText.text += "♥";
			
	}

	public void BossUpdate(){
		nextBoss = Time.time+bossRate + (slow < 1 ? bossRate : 0);
		faze = score;
		itemWait += 5;

		hazard1Set = true;
		bossContol = false;
	}

}
