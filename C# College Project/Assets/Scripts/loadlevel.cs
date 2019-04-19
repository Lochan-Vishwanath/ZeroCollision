using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {

    RectTransform nextLevelMenu;
    Scene thisScene;
    char[] lvlname = "l0-0".ToCharArray();
    private void Start()
    {
        thisScene = SceneManager.GetActiveScene();
        lvlname = thisScene.name.ToCharArray();
        nextLevelMenu = GameObject.Find("Main/Canvas/Next Level Menu").GetComponent<RectTransform>();
    }
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
    public void resetToLevelHead()
    {
        /*char[] newlvlname="l0-0".ToCharArray();
        newlvlname[0] = lvlname[0];
        newlvlname[1] = lvlname[1];
        newlvlname[2] = lvlname[2];
        newlvlname[3] = '1';
        //Debug.Log(newlvlname.ToString());
        SceneManager.LoadScene(new string(newlvlname), LoadSceneMode.Single);*/
        SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + ('1').ToString(), LoadSceneMode.Single);
    }
    public void nextStage()
    {
        if (lvlname[3] == '3')
        {
            nextLevelMenu.gameObject.SetActive(true);
        }
        else 
        {
            SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + ((lvlname[3] - '0' + 1)).ToString(), LoadSceneMode.Single);
        }  
    }
    public void nextLevel()
    {
        SceneManager.LoadScene(lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + lvlname[2].ToString() + ('1').ToString(), LoadSceneMode.Single);
    }
}
