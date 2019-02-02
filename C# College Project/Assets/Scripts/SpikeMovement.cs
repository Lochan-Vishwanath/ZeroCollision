using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Transform destination1,destination2;
    public float speed=0.07f;
    Transform destination;
    public RectTransform panel;
    void Start()
    {
        destination = destination1;
    }
    void Update()
    {
        //Debug.Log(Time.deltaTime*speed);
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed);
        if (Vector2.Distance(transform.position, destination.position) == 0)
        {
            if (destination.Equals(destination1))
                destination = destination2;
            else
                destination = destination1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyA")
        {
            Destroy(collision.gameObject);
            panel.gameObject.SetActive(true);
            AudioManager.playaudiogameover = true;
        }
    }
}
