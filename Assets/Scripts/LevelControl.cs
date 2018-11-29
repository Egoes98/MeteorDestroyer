using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour {

    public Canvas canvas;
    public bool runTimer;

	// Use this for initialization
	void Start () {
        canvas.GetComponent<Canvas>().enabled = false;
        runTimer = true;
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
        if (runTimer)
        {
            StartCoroutine("UpgradeMenu");
        }
    }

    public void NextRound()
    {
        Debug.Log("Next round");
        MeteorSpawn.fallSpeed += 2;
        Time.timeScale = 1;
        runTimer = true;
        canvas.GetComponent<Canvas>().enabled = false;
    }
    public IEnumerator UpgradeMenu()
    {
        runTimer = false;
        yield return new WaitForSeconds(30);
        Time.timeScale = 0;
        canvas.GetComponent<Canvas>().enabled = true;
    }
}
