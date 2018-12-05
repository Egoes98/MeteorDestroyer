using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour {

    private Transform target;
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(target == null)
        {
            return;
        }

        GameObject[] rocket = GameObject.FindGameObjectsWithTag("Rocket");
        foreach (GameObject item in rocket)
        {
            Physics2D.IgnoreCollision(item.GetComponent<Collider2D>(),transform.GetComponent<Collider2D>());
        }

        //Calculos de el angulo de rotacion
        Vector3 difference = target.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ - 90);

        //El movimiento hacia el meteorito
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}

    public void Initialise(Transform t)
    {
        Debug.Log("Cargarmos el target");
        this.target = t;
        Debug.Log(this.target.name);
    }

}
