using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime;
	public GameObject ghost;

    void Start()
    {
        Destroy(gameObject, lifetime);

    }

	void Update(){
		ghost.transform.position += new Vector3 (0, 0, 0.01f);
	}
}
