using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour {

    public static int life = 20;
    public float fallSpeed = 10;
    public Rigidbody2D rb;

    public float m_MovementSmoothing = 0.5f;
    private Vector3 m_Velocity = Vector3.zero;

    // Use this for initialization
    void Start () {
		rb = rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 targetVelocity = new Vector2(rb.velocity.x, 1 * -fallSpeed);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public static void takeDamage()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Yes");
    }
}
