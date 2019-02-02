using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Transform destination1,destination2;
    public float speed;
    Transform destination;
    void Start()
    {
        destination = destination1;
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, destination.position) == 0)
        {
            if (destination.Equals(destination1))
                destination = destination2;
            else
                destination = destination1;
        }
        transform.position = Vector3.MoveTowards(transform.position, destination.position,Time.deltaTime * speed);
    }
}
