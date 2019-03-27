using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_randomMovement : MonoBehaviour
{
    public Transform prefab;
    Transform destination;
    public float speed = 0.8f;
    Vector3 RandPosition;
    int randnum;


    void Start()
    {
        Spawnobj();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

        if (Vector2.Distance(destination.position, transform.position) == 0)
        {
            Destroy(destination.gameObject);
            Spawnobj();
        }
    }

    // void Spawnobj()
    // {
    //     RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.86f), Random.Range(0.14f, 0.82f), Camera.main.farClipPlane / 2));
    //     destination = Instantiate(prefab, RandPosition, Quaternion.identity).GetComponent<Transform>();
    // }
    void Spawnobj()
    {

        randnum = Random.Range(1, 4);
        switch (randnum)
        {
            case 1:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, Random.Range(0.14f, 0.82f), Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(30, Random.Range(90, Screen.height - 90), Camera.main.farClipPlane / 2));
                break;
            case 2:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(0.86f, Random.Range(0.14f, 0.82f), Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - 30, Random.Range(90, Screen.height - 90), Camera.main.farClipPlane / 2));
                break;
            case 3:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.86f), 0.14f, Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(30, Screen.width - 30), Screen.height - 90, Camera.main.farClipPlane / 2));
                break;
            case 4:
                RandPosition = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.1f, 0.86f), 0.82f, Camera.main.farClipPlane / 2));
                //RandPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(30, Screen.width - 30), 90, Camera.main.farClipPlane / 2));
                break;
        }

        destination = Instantiate(prefab, RandPosition, Quaternion.identity).GetComponent<Transform>();
    }

}
