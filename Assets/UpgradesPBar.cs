using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesPBar : MonoBehaviour {

    public Image fireRateBar;
    public float price = 30;

	// Use this for initialization
	void Start () {
        fireRateBar.fillAmount = 0;
	}

    public void FireRate()
    {
        if(fireRateBar.fillAmount == 1 | Scoring.score < 30)
        {
            return;
        }
        else
        {
            Scoring.score -= 30;
            fireRateBar.fillAmount += 0.25f;
        }
    }
}

