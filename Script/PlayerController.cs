using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {
    private Rigidbody rb;

	public Transform _transform;
    public float speed;
    public float slow = 1;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

	public GameObject Special;
	public Transform SshotSpawn;

    public float fireRate;
    private float nextFire;

	public bool stop;
	public bool skill;
	private float skillRate= 2;
	private float nextSkill;
	private float skillCRate = 15;
	private float nextSkillC;

    void Start() {
        rb = GetComponent<Rigidbody>();
		_transform = this.gameObject.GetComponent<Transform> ();
		stop = false;
		skill = false;
		nextSkill = Time.time + skillRate;
		nextSkillC = 0;

    }

    void Update(){
		if (stop == true) {
			_transform.position = new Vector3 (-13, 0, 0);
		} else {
			if (/*Input.GetButton ("Fire1") && */(Time.time) > nextFire) {
				nextFire = Time.time + fireRate + (slow < 1 ? fireRate: 0);
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			}
			if (Time.time > nextSkillC) {
				if (Input.GetKeyDown (KeyCode.X)) {
					Instantiate (Special, SshotSpawn.position, SshotSpawn.rotation);
					nextSkillC = Time.time + skillCRate;
					skill = true;
				}
			}
			if (Time.time > nextSkill) {
				skill = false;
				nextSkill = Time.time + skillRate;
			}
		}
	}


    void FixedUpdate() {
		if (stop == false) {
	        float moveHorizontal = Input.GetAxis("Horizontal");
	        float moveVertical = Input.GetAxis("Vertical");
	        if (Input.GetKey(KeyCode.LeftShift)) slow = 0.5f;
	        if (Input.GetKeyUp(KeyCode.LeftShift)) slow = 1;
	                Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
	        rb.velocity = movement * speed * slow;

			rb.position = new Vector3 (Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax));
		}
    }
}