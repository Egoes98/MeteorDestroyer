using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour {

    private float spawnX = 0;
    private float spawnY = 10;
    private Vector2 spawnPosition;
    private Quaternion rotation = new Quaternion(0,0,1,1);

    public float spawnRate = 1;
    public float timeToSpawn = 0;

    public Transform meteorPrefab;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update () {
        spawnX = Random.Range(-19,19);
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
