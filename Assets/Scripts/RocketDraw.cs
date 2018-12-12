using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDraw : MonoBehaviour {
    public GameObject rocket;
    public GameObject liveText;
    int offset = 0;

    private void Start()
    {
        Draw();
    }

    private void Update()
    {
        if (LevelControl.useBuy)
        {
            Draw();
        }
        LevelControl.useBuy = false;
        Debug.Log("Cohetes:"+LevelControl.rockets);
    }

    public void Draw()
    {

        GameObject[] copys = GameObject.FindGameObjectsWithTag("RA");
        foreach (GameObject item in copys)
        {
            Destroy(item);
        }

        for (int n = 0; n <LevelControl.rockets; n++)
        {
            GameObject copy = Instantiate(rocket) as GameObject;
            copy.transform.SetParent(transform,true);
            copy.transform.position = new Vector3(liveText.transform.position.x + offset, liveText.transform.position.y-15, liveText.transform.position.z);
            offset += 15;
        }
        offset = 0;
    }
}
