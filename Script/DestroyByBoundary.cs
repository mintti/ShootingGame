using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour{
	void OnTriggerExit(Collider Other){
		if (Other.tag == "bg") {
			return;
		}
		Destroy(Other.gameObject);
	}
}