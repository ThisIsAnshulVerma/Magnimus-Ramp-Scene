using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedObstacleDestroyer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "obstacle")
        { 
            Destroy(collision.gameObject);
        }
    }
}
