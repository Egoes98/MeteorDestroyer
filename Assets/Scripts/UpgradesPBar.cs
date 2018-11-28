using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesPBar : MonoBehaviour {

    public Image fireRateBar;
    public Image firePowerBar;
    public float price = 30;

	// Use this for initialization
	void Start () {
        fireRateBar.fillAmount = 0;
        firePowerBar.fillAmount = 0;
    }

    public void FirePower()
    {
        if (firePowerBar.fillAmount == 1 | Scoring.score < 100)
        {
            return;
        }
        else
        {
            Scoring.score -= 100;
            BulletMovement.bulletSpeed += 10;
            firePowerBar.fillAmount += 0.25f;
        }
    }

    public void FireRate()
    {
        if(fireRateBar.fillAmount == 1 | Scoring.score < 100)
        {
            return;
        }
        else
        {
            Scoring.score -= 100;
            ShootCannon.fireRate += 0.5f;
            fireRateBar.fillAmount += 0.25f;
        }
    }
}

