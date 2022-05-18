using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnScript : MonoBehaviour
{
    public float respawnTime;
    public GameObject respawnPrefab;
    public float xOffsetRange;  // Later make fix

    private Vector3 respawnPrefabPosition;

    void Start()
    {
        respawnPrefabPosition = respawnPrefab.transform.position;
        StartCoroutine(obstacleWave());
    }

    void spawnObstacle()
    {
        GameObject newSpawnObject = Instantiate(respawnPrefab) as GameObject;

        newSpawnObject.transform.position = new Vector3(
            respawnPrefabPosition.x + Random.Range(-xOffsetRange, xOffsetRange),
            respawnPrefabPosition.y,
            respawnPrefabPosition.z
        );
    }

    IEnumerator obstacleWave ()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObstacle();
        }
    }
}
