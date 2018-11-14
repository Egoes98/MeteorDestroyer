using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRotation : MonoBehaviour {

    public int rotationOffset = 0;
    private float previousRotZ;
	
	// Update is called once per frame
	void Update () {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (rotZ < 0 || rotZ > 180)
        {
            return;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
	}
}
