using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

    private float spawnX = 0;
    private float spawnY = 10;
    private Vector2 spawnPosition;
    private Quaternion rotation = new Quaternion(0,0,1,1);

    public static float spawnRate = 1;
    public static float timeToSpawn = 0;
    public static float fallSpeed = 5;

    public Transform meteorPrefab;

    public Camera cam;
    private Vector3 camP;
    private Vector3 camPMin;

    private void Start()
    {
        spawnRate = 1;
        timeToSpawn = 0;
        fallSpeed = 5;
}

    // Update is called once per frame
    void Update () {
        camP = cam.ViewportToWorldPoint(new Vector3(1,1,cam.nearClipPlane));
        Debug.Log(camP.x + " " + camP.y);

        spawnX = Random.Range((-camP.x + 0.8f),(camP.x - 0.8f));
        spawnY = camP.y + 0.8f;
        SpawnMeteor();
        
	}

    void SpawnMeteor()
    {
        spawnPosition = new Vector2(spawnX, spawnY);
        if (Time.time > timeToSpawn)
        {
            timeToSpawn = Time.time + 1 / spawnRate;
            Instantiate(meteorPrefab,spawnPosition,rotation);
        }
    }
}
