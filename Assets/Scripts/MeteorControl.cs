using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour
{

    public float life = 20;
    public Rigidbody2D rb;

    public float m_MovementSmoothing = 0.5f;
    private Vector3 m_Velocity = Vector3.zero;

    public Transform mDestroy;

    // Use this for initialization
    void Start()
    {
        rb = rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            SpawnEffect();
            Destroy(gameObject, 0);
        }
        if (LevelControl.rocketLaunching)
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            return;
        }
        Vector2 targetVelocity = new Vector2(rb.velocity.x, 1 * -MeteorSpawn.fallSpeed);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
    }

    public void takeDamage(float damage)
    {
        life -= damage;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            Scoring.score += 10;
            Destroy(collision.gameObject,0);
            takeDamage(20);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rocket(Clone)")
        {
            LevelControl.nMeteors--;
            Destroy(collision.gameObject);
            takeDamage(life);

        }
    }
    public void SpawnEffect()
    {
        Transform copy = Instantiate(mDestroy, this.transform.position, this.transform.rotation);
        Destroy(copy.gameObject, 0.7333f);
    }
}
