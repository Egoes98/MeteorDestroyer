using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public int bulletSpeed = 100;
    public int bulletDamage = 10;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * bulletSpeed);
        Destroy(gameObject,30);
	}
}
