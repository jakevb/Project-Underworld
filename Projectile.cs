using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start()
    { 
        if (transform.localRotation.z > 0)
            speed = -speed;
    }

    // Update is called once per frame
    void Update ()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
            Destroy(gameObject);
    } 
}
