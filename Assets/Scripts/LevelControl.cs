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
        InvokeRepeating("UpgradeMenu", 30.0f, 30.0f);
        if (Time.timeScale == 1)
        {
            canvas.GetComponent<Canvas>().enabled = false;
        }
    }

    public void NextRound()
    {
        Debug.Log("Next round");
        MeteorSpawn.fallSpeed += 2;
        Time.timeScale = 1;
        canvas.GetComponent<Canvas>().enabled = false;
    }
    public void UpgradeMenu()
    {
        Time.timeScale = 0;
        canvas.GetComponent<Canvas>().enabled = true;
    }
}
