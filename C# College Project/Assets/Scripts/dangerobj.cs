using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dangerobj : MonoBehaviour {

    //public 
    RectTransform panel;
    public bool Show_GameOver_screen;
    GameObject[] objs;

    void Start(){
        panel=panel = GameObject.Find("Main/Canvas/GAME OVER PANEL").GetComponent<RectTransform>();
        objs = GameObject.FindGameObjectsWithTag("EnemyA");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemyA")
        {
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            
            //if(panel.gameObject.activeInHierarchy){
                foreach (GameObject obj in objs)
                {
                    if(obj==null) continue;
                    obj.GetComponent<RandomMovement>().speed=0;
                }
            //}
            if (Show_GameOver_screen)
            {
                panel.gameObject.SetActive(true);
                AudioManager.playaudiogameover = true;
            }
        }
    }
}
