﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour
{
    public Transform destination1,destination2;
    public float speed=0.07f;
    Transform destination;
    //public 
    RectTransform panel;
    GameObject[] objs;
    public GameObject ParticleEffectOBJ;
    ScreenShake ss;
    void Start()
    {
        ss = Camera.main.GetComponent<ScreenShake>();
        panel = GameObject.Find("Main/Canvas/Game-Over Menu").GetComponent<RectTransform>();
        objs = GameObject.FindGameObjectsWithTag("EnemyA");
        destination1.GetComponent<SpriteRenderer>().color=new Color(destination1.GetComponent<SpriteRenderer>().color.r,destination1.GetComponent<SpriteRenderer>().color.g,destination1.GetComponent<SpriteRenderer>().color.b,0f);
        destination2.GetComponent<SpriteRenderer>().color=new Color(destination2.GetComponent<SpriteRenderer>().color.r,destination2.GetComponent<SpriteRenderer>().color.g,destination2.GetComponent<SpriteRenderer>().color.b,0f);
        destination = destination1;
    }
    void Update()
    {
        if(StageLoad.stageloading)
        //Debug.Log(Time.deltaTime*speed);
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed);
        if (Vector2.Distance(transform.position, destination.position) == 0)
        {
            //Debug.Log("here");
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
            ss.shakeScreenHard();
            Instantiate(ParticleEffectOBJ, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            
            //if(panel.gameObject.activeInHierarchy){
                foreach (GameObject obj in objs)
                {
                    if(obj==null) continue;
                    obj.GetComponent<RandomMovement>().speed=0;
                }
            //}
            panel.gameObject.SetActive(true);
            AudioManager.playaudiogameover = true;
            StageLoad.stageloading = false;
            //DragwithMouse.takemouseinput=false;
            //Dragable.taketouchinput=false;
        }
    }
}
