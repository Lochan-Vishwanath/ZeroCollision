using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {

	public void loadlvl(string lvlName)
    {
        StageLoad.stageloading=false;
        SceneManager.LoadScene(lvlName,LoadSceneMode.Single);
    }
    public void loadmain()
    {
        StageLoad.stageloading=false;
        SceneManager.LoadScene("Main",LoadSceneMode.Single);
    }
    public void playaudio()
    {
        //AudioManager.playaudiogood = true;
    }
}
