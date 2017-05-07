using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacter : MonoBehaviour {

    public float moveSpeed;
    public float jumpHeight;
    private Rigidbody2D m_RigidBody2D;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    private bool SwordControl;
    private bool attack;
    public GameObject sword;
    public Transform weapon;
    public GameObject rightFireball;
    public Transform firePos;
    float fireRate = 0.25f;
    float nextFire = 0f;
    private bool m_FacingRight = true;

    // Use this for initialization
    void Start () {

        m_RigidBody2D = GetComponent<Rigidbody2D>();
		
	}

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);


    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            m_RigidBody2D.velocity = new Vector2(m_RigidBody2D.velocity.x, jumpHeight);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!m_FacingRight)
            {
                Flip();
            }
            m_RigidBody2D.velocity = new Vector2(moveSpeed, m_RigidBody2D.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (m_FacingRight)
            {
                Flip();
            }
            m_RigidBody2D.velocity = new Vector2(-moveSpeed, m_RigidBody2D.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {

            Sword();
        }
    }

        private void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if (m_FacingRight)
                Instantiate(rightFireball, firePos.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            if (!m_FacingRight)
                Instantiate(rightFireball, firePos.position, Quaternion.Euler(new Vector3(0, 0, 180)));
        }

    }

    private void Sword()
    {
        Instantiate(sword, weapon.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        SwordControl = false;
    }


    private void Flip()
    {
        m_FacingRight = !m_FacingRight;


        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

