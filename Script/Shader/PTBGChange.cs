using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PTBGChange : MonoBehaviour {

	public GameObject bgpt1;
	public GameObject bgpt2;
	public GameObject bgptC1;
	public GameObject bgptC2;
	public GameObject bg;
	public GameObject bgC;
	public GameObject under;
	public GameObject underC;

	// Use this for initialization
	void Start () {
		bgpt1.GetComponent<SpriteRenderer> ().enabled = true;
		bgpt2.GetComponent<SpriteRenderer> ().enabled = true;
		bg.GetComponent<SpriteRenderer> ().enabled = true;
		under.GetComponent<SpriteRenderer> ().enabled = true;
		bgptC1.GetComponent<SpriteRenderer> ().enabled = true;
		bgptC2.GetComponent<SpriteRenderer> ().enabled = true;
		bgC.GetComponent<SpriteRenderer> ().enabled = true;
		underC.GetComponent<SpriteRenderer> ().enabled = true;

		bgptC1.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
		bgptC2.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
		bgC.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);
		underC.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0);

	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CC(){
		StartCoroutine ("ColorON");
		StartCoroutine ("ColorOFF");

	}

	public IEnumerator ColorON(){
		for (float i = 0; i <= 1; i += 0.1f) {
			bgpt1.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i );
			bgpt2.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);
			bg.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);
			under.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);

			bgptC1.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);
			bgptC2.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);
			bgC.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);
			underC.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);
			yield return new WaitForSeconds(0.1f);
		}

	}
	public IEnumerator ColorOFF(){
		yield return new WaitForSeconds(1f); 
		for (float i = 0; i <= 1; i += 0.1f) {

			bgpt1.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i );
			bgpt2.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);
			bg.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);
			under.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, i);

			bgptC1.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);
			bgptC2.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);
			bgC.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);
			underC.GetComponent<SpriteRenderer> ().color += new Color(1f, 1f, 1f, -i);
			yield return new WaitForSeconds (0.1f); 
		}
	}
}
