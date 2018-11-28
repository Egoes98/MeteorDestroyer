using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {

    public Canvas canvas;
    private float time;
    public float interpolationPeriod = 30;

	// Use this for initialization
	void Start () {
        canvas.GetComponent<Canvas>().enabled = false;
        time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 1)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            return;
        }

        if (Time.time > time)
        {
            canvas.GetComponent<Canvas>().enabled = true;
            Time.timeScale = 0;
            time += interpolationPeriod;
        }
    }

    public void NextRound()
    {
        Debug.Log("Next round");
        MeteorSpawn.fallSpeed += 2;
        Time.timeScale = 1;
        canvas.GetComponent<Canvas>().enabled = false;
    }
}
