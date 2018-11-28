using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {

    public Canvas canvas;

	// Use this for initialization
	void Start () {
        canvas.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("u"))
        {
            if (Time.timeScale == 1)
            {    //si la velocidad es 1
                canvas.GetComponentInChildren<Canvas>().enabled = true;
                Time.timeScale = 0;     //que la velocidad del juego sea 0

            }
            else if (Time.timeScale == 0)
            {   // si la velocidad es 0
                canvas.GetComponentInChildren<Canvas>().enabled = false;
                Time.timeScale = 1;     // que la velocidad del juego regrese a 1
            }
        }
    }
}
