using System.Collections;
using UnityEngine;

public class dangerobj : MonoBehaviour {

    //public 
   //RectTransform panel;
    public bool Show_GameOver_screen;
    GameObject[] objs;
    public GameObject ParticleEffectOBJ;
    ScreenShake ss;
    SpriteRenderer other;

    void Start(){
        //panel=panel = GameObject.Find("Main/Canvas/Game-Over Menu").GetComponent<RectTransform>();
        ss = Camera.main.GetComponent<ScreenShake>();
        objs = GameObject.FindGameObjectsWithTag("EnemyA");
        other = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemyA")
        {
            ss.shakeScreenHard();
            Instantiate(ParticleEffectOBJ, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            InvokeRepeating("trigger", 0.2f, 0.2f);
            //if(panel.gameObject.activeInHierarchy){
            foreach (GameObject obj in objs)
                {
                    if(obj==null) continue;//if obj is destroyed 
                    obj.GetComponent<RandomMovement>().speed=0;
                }
            //}
            if (Show_GameOver_screen)
            {
                //panel.gameObject.SetActive(true);
                ColoursScript.GameOver = true;
                AudioManager.playaudiogameover = true;
                StageLoad.stageloading = false;
             //   DragwithMouse.takemouseinput=false;
            //    Dragable.taketouchinput=false;
            }
        }
    }

    IEnumerator flash()
    {
        Color colour = other.color;
        colour.a = 0.85f;
        other.color = colour;
        yield return new WaitForSeconds(0.1f);
        colour.a = 0f;
        other.color = colour;
    }
    void trigger()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(flash());
    }
}
