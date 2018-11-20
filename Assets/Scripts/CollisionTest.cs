using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        Destroy(collision.gameObject,0);
    }
}
