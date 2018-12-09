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
	void Start () {
        txt = this.GetComponent<Text>();
        time = Time.time;
        StartCoroutine(timeToProgressBar());
	}
	
	void Update () {
        txt.text = (MaxTime - (Time.time - time)).ToString("f2");
        if((Time.time - time) == 0)
        {
            dead = true;
        }
        progress = (MaxTime - (Time.time - time)) / MaxTime;
        //Debug.Log((MaxTime-(Time.time - time))/MaxTime);
        timerslider.value = progress;
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
