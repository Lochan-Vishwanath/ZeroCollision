using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class ColoursScript : MonoBehaviour {

    public Color32 o1, o2, o3, o4, o5;
    SpriteRenderer Myrender;
    public RectTransform nextPanel;
    public static int no_of_objs = 0;
    public static bool GameOver = false;
    [HideInInspector]
    public GameObject[] objs;
    RectTransform GameOverPanel;
    RectTransform panel;
    //bool once = true;
    public bool shownextlvl=false;
    loadlevel x;
    //public TextMeshProUGUI moves, timetaken;
    public string nxtstage;
    public Color32 setColor(int Set_Option)
    {
        switch (Set_Option)
        {
            case 1: return o1; 
            case 2: return o2; 
            case 3: return o3; 
            case 4: return o4; 
            case 5: return o5; 
            default: throw new System.Exception("Color not Selected");
        }
    }

    private void Start()
    {
        panel = GameObject.Find("Main/Canvas/Game-Over Menu").GetComponent<RectTransform>();
        GameOver = false;
        x =GetComponent<loadlevel>();
        //once = true;
        no_of_objs = 0;
        objs = GameObject.FindGameObjectsWithTag("EnemyA");

        foreach (GameObject obj in objs)
        {
            no_of_objs++;
        }
        //Debug.Log(no_of_objs);
    }
    private void LateUpdate()
    {
        if (GameOver)
            StartCoroutine(waitGameOver());
        if (no_of_objs <= 0)
        {
            string eventName = "af_fakeImpression";
            Dictionary<string, string> eventParams = new Dictionary<string, string>() { { "imp", "1" } }; AppsFlyer.trackRichEvent(eventName, eventParams);
            StartCoroutine(waitNextStage());
           
            /*if(shownextlvl && !GameOverPanel.gameObject.activeInHierarchy)
                nextPanel.gameObject.SetActive(true);
            else
            {
                if(!AudioManager.playaudiogood)
                x.loadlvl(nxtstage);
            }
               

            if (once)
            {
                if(shownextlvl)
                //GetComponent<AudioSource>().Play();
                once = false;
            }*/
            
        }
    }

     void OnDrawGizmos(){
        Vector3 RandPosition1 = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.12f , Camera.main.farClipPlane / 2));
        Vector3 RandPosition2 = Camera.main.ViewportToWorldPoint(new Vector3(0.86f, 0.12f , Camera.main.farClipPlane / 2));
        Vector3 RandPosition3 = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.88f , Camera.main.farClipPlane / 2));
        Vector3 RandPosition4 = Camera.main.ViewportToWorldPoint(new Vector3(0.86f, 0.88f , Camera.main.farClipPlane / 2));


        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(RandPosition1, 0.2f);
        Gizmos.DrawSphere(RandPosition2, 0.2f);
        Gizmos.DrawSphere(RandPosition3, 0.2f);
        Gizmos.DrawSphere(RandPosition4, 0.2f);
     }

    IEnumerator waitNextStage()
    {
        yield return new WaitForSeconds(0.25f);
        //yield return null;
        x.nextStage();
    }
    IEnumerator waitGameOver()
    {
        //Debug.Log("here");
        string eventName = "af_fakeImpression";
        Dictionary<string, string> eventParams = new Dictionary<string, string>() { { "imp", "1" } }; AppsFlyer.trackRichEvent(eventName, eventParams);
        yield return new WaitForSeconds(1.5f);
        panel.gameObject.SetActive(true);
        if (Restart.ADCLICKCOUNT == 0)
        {
            DragwithMouse.Moves = 0;
            playerStats.timeTaken = 0;
            playerStats.timer = 0;
        }
    }
}
