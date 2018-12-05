using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour {

    public static Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void SetTarget(Transform t)
    {
        target = t;
    }

    public void SetDestination()
    {

    }
}
