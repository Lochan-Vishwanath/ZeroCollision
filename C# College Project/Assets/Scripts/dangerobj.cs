using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dangerobj : MonoBehaviour {

    //public 
    RectTransform panel;
    public bool Show_GameOver_screen;
    GameObject[] objs;
    public GameObject ParticleEffectOBJ;
    ScreenShake ss;

    void Start(){
        panel=panel = GameObject.Find("Main/Canvas/Game-Over Menu").GetComponent<RectTransform>();
        ss = Camera.main.GetComponent<ScreenShake>();
        objs = GameObject.FindGameObjectsWithTag("EnemyA");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemyA")
        {
            ss.shakeScreenHard();
            Instantiate(ParticleEffectOBJ, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            
            //if(panel.gameObject.activeInHierarchy){
                foreach (GameObject obj in objs)
                {
                    if(obj==null) continue;//if obj is destroyed 
                    obj.GetComponent<RandomMovement>().speed=0;
                }
            //}
            if (Show_GameOver_screen)
            {
                panel.gameObject.SetActive(true);
                AudioManager.playaudiogameover = true;
                StageLoad.stageloading = false;
             //   DragwithMouse.takemouseinput=false;
            //    Dragable.taketouchinput=false;
            }
        }
    }
}
