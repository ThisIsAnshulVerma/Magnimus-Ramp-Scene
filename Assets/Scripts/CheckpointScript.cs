using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerMovementScript.lastCheckpointPos = new Vector3(
                transform.position.x,
                transform.position.y + 3,
                transform.position.z
            );
            Debug.Log(transform.position);
        }
    }
}
