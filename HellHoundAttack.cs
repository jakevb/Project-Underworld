using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellHoundAttack : MonoBehaviour {

    private Transform target;
    public Transform us;
    public float speed;
    private float direction;

    void start()

    {

        target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    void FixedUpdate()
    {

        float moveHorizontal = -1;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);

        if (target.position.x > us.position.x)
        {

            direction = 1;

        }

        if (target.position.x < us.position.x)
        {

            direction = -1;

        }
    }

}
