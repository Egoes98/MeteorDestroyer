using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour {

    public Canvas upgradeUI;
    public Canvas gameOverUI;
    public Image life_bar;
    public static float life;
    public KeyCode launchRocket;
    public static bool rocketLaunching;
    public Transform rocket;
    public static int rockets = 100;
    public static bool useBuy = false;
    public Transform rSpawnPoint;

    public static int nMeteors = 0;

    // Use this for initialization
    void Start () {
        upgradeUI.GetComponent<Canvas>().enabled = false;
        gameOverUI.GetComponent<Canvas>().enabled = false;
        life_bar.fillAmount = 1;
        life = 1;
        rocketLaunching = false;
        useBuy = false;
        InvokeRepeating("UpgradeMenu", 30.0f, 30.0f);
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
            //GameOverScreen();
        }
        if (Time.timeScale == 1)
        {
            upgradeUI.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            return;
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
        upgradeUI.GetComponent<Canvas>().enabled = false;
    }
    public void UpgradeMenu()
    {
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
        useBuy = true;
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

    public void AddRockets() {
        rockets++;
        useBuy = true;
    }
}
