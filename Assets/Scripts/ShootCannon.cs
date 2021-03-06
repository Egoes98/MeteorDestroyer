﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour {

    public static float fireRate = 0;
    public static float damage = 10;
    public LayerMask wahtToHit;

    public Transform bulletPrefab;

    private float timeToFire = 0;
    private Transform firePoint;

    private float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;

	// Use this for initialization
	void Start () {
        fireRate = 0;
        damage = 10;
        firePoint = transform.Find("FirePoint");
        if (firePoint == null)
        {
            Debug.Log("Theres no Firepoint!!");
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.timeScale == 0 || LevelControl.rocketLaunching)
        {
            return;
        }

        if (fireRate == 0 & Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        else
        {
            if (Input.GetButton("Fire1") & Time.time > timeToFire)
            {
                timeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }
	}

    public void Shoot()
    {
        if(Time.time > timeToSpawnEffect)
        {
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;
            SpawnEffect();
        }
    }

    void SpawnEffect()
    {
        Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
    }
}
