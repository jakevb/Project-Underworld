using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    public float delay;

	// Use this for initialization
	void Awake ()
    {
        Destroy(gameObject, delay);
	}
	
}
