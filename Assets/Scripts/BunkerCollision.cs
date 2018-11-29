﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunkerCollision : MonoBehaviour {

    public float resistance = 100;
    public float nearlyDestroyed;
    public float destroyed;

    public Sprite state0;
    public Sprite state1;
    public Sprite state2;
    public SpriteRenderer bunker;

    public AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update () {
        if (resistance <= nearlyDestroyed && resistance > destroyed)
        {
            //Change to the second state sprite
            bunker.sprite = state1;
        }
        else if (resistance <= destroyed)
        {
            //Change to the destroyed state
            bunker.sprite = state2;
        }
        else
        {
            bunker.sprite = state0;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.volume = SoundManagement.soundLevel;
        source.Play();
        resistance -= 10;
        LevelControl.life -= 0.1f;
        Destroy(collision.gameObject,0);
        //TODO Send message to GM to that it was hit
    }

    public void RepairAll()
    {
        LevelControl.life = 1;
        resistance = 100;
    }
}
