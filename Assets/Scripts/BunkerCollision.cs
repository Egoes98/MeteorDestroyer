using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerCollision : MonoBehaviour {

    public float damage;
    public float resistance;
    public float nearlyDestroyed;
    public float destroyed;

    public Sprite state1;
    public Sprite state2;
    public SpriteRenderer bunker;

    // Update is called once per frame
    void Update () {
        if (resistance == nearlyDestroyed)
        {
            //Change to the second state sprite
            bunker.sprite = state1;
        }
        if (resistance == destroyed)
        {
            //Change to the destroyed state
            bunker.sprite = state2;
            //Send message to GM to show that the building is detroyed
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        resistance -= damage;
        Destroy(collision.gameObject,0);
    }
}
