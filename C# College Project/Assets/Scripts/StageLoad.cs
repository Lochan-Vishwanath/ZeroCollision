using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageLoad : MonoBehaviour
{
    public bool loadstage=false;
    public static bool stageloading=false;
    public int PauseTime = 1;

    void Awake(){
        if(loadstage){
            StartCoroutine(Pause(PauseTime));
        }
        if (!loadstage)
        {
            stageloading = true;
        }
    }
    private IEnumerator Pause(int p){
        Time.timeScale = 0.1f;
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        Time.timeScale = 1;
        stageloading=true;
    }
}
