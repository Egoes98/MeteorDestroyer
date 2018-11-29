using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {

    public Canvas upgradeUI;
    public Canvas gameOverUI;
    public Image life_bar;
    public static float life;
    public bool runTimer;

	// Use this for initialization
	void Start () {
        upgradeUI.GetComponent<Canvas>().enabled = false;
        gameOverUI.GetComponent<Canvas>().enabled = false;
        runTimer = true;
        life_bar.fillAmount = 1;
        life = 1;
	}
	
	// Update is called once per frame
	void Update () {
        life_bar.fillAmount = life;
        if(life <= 0)
        {
            GameOverScreen();
        }
        if (Time.timeScale == 1)
        {
            upgradeUI.GetComponent<Canvas>().enabled = false;
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
        upgradeUI.GetComponent<Canvas>().enabled = false;
    }
    public IEnumerator UpgradeMenu()
    {
        runTimer = false;
        yield return new WaitForSeconds(30);
        Time.timeScale = 0;
        upgradeUI.GetComponent<Canvas>().enabled = true;
    }
    public void GameOverScreen()
    {
        Time.timeScale = 0;
        gameOverUI.GetComponent<Canvas>().enabled = true;

    }
}
