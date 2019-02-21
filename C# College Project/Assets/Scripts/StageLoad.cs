using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoad : MonoBehaviour
{
    public bool loadstage=false;
    public static bool stageloading=false;

    void Awake(){
        if(loadstage){
            StartCoroutine(Pause(3));
        }
    }
    private IEnumerator Pause(int p){
        Time.timeScale = 0.1f;
        float pauseEndTime = Time.realtimeSinceStartup + 1;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        stageloading=true;
    }
}
