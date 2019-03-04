using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour {

    bool dead = false;
    Text txt;
    public Slider timerslider;
    float progress;
    float time;
    public float MaxTime;
    public RectTransform panel;
	void Start () {
        dead = false;
        txt = this.GetComponent<Text>();
        time = Time.time;
        StartCoroutine(timeToProgressBar());
        progress = MaxTime;
	}
	
	void Update () {

        if (StageLoad.stageloading)
        {
            txt.text = (MaxTime - (Time.time - time)).ToString("f2");
            // if((Time.time - time) == 0)
            // {
            //    dead = true;
            // }

            progress = (MaxTime - (Time.time - time)) / MaxTime;
            //Debug.Log(progress);
            timerslider.value = progress;
        }
    }
    private void LateUpdate()
    {
        if (progress<=0)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("EnemyA");

            foreach (GameObject obj in objs)
            {
                obj.GetComponent<RandomMovement>().speed = 0f;
            }
            panel.gameObject.SetActive(true);
        }
    }
    IEnumerator timeToProgressBar()
    {
        while (!dead)
        {
           
            timerslider.value = progress;
            yield return null;
        }
    }
}
