using UnityEngine;
using System.Collections;


public class EnemyController : MonoBehaviour
{
    public float slow = 1;
    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    void Start()
    {
    }

    void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift)) slow = 0.5f;
		if (Input.GetKeyUp(KeyCode.LeftShift)) slow = 1;

		if (/*Input.GetButton ("Fire1") && */(Time.time) > nextFire) {
			nextFire = Time.time + fireRate + (slow < 1 ? 0.2f : 0);
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
		}
	}
  
}