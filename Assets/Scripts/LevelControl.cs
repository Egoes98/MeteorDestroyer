using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {

    public Canvas upgradeUI;
    public Canvas gameOverUI;
    public Image life_bar;
    public static float life;
    private bool runTimer;

    public KeyCode launchRocket;
    public int rockets;
    public static bool rocketLaunching;
    public Transform rocket;
    public Transform rSpawnPoint;

    public static int nMeteors = 0;

    // Use this for initialization
    void Start () {
        upgradeUI.GetComponent<Canvas>().enabled = false;
        gameOverUI.GetComponent<Canvas>().enabled = false;
        runTimer = true;
        life_bar.fillAmount = 1;
        life = 1;
        rocketLaunching = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (nMeteors == 0)
        {
            rocketLaunching = false;
        }
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

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(launchRocket) & rockets > 0 & !rocketLaunching){
            rocketLaunching = true;
            UseRocket();
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

        GameObject[] meteor = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject item in meteor)
        {
            Destroy(item);
        }

        upgradeUI.GetComponent<Canvas>().enabled = true;
    }
    public void GameOverScreen()
    {
        Time.timeScale = 0;
        gameOverUI.GetComponent<Canvas>().enabled = true;

    }

    public void UseRocket() //Called when using a nuke TODO ADD THE ANIMATION
    {
        Debug.Log("LAUNHING ROCKET!!!");
        rockets--;
        StartCoroutine(SpawnRocket());
    }

    IEnumerator SpawnRocket()
    {

        GameObject[] meteor = GameObject.FindGameObjectsWithTag("Meteor");
        foreach (GameObject item in meteor)
        {
            Transform rocketInstance = Instantiate(rocket, rSpawnPoint.position, rSpawnPoint.rotation);
            rocketInstance.GetComponent<RocketControl>().Initialise(t: item.transform);
            nMeteors++;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
