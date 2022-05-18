using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBeltScript : MonoBehaviour
{
    public float speed;
    Rigidbody rBody;

    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = rBody.position;
        rBody.position += Vector3.forward * speed * Time.fixedDeltaTime;
        rBody.MovePosition(pos);
    }
}
