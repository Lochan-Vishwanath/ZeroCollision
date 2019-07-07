﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {

    RectTransform nextLevelMenu;
    Scene thisScene;
    char[] lvlname = "l0-0".ToCharArray();
    List<string> scenesInBuild = new List<string>();
    private void Start()
    {
        thisScene = SceneManager.GetActiveScene();
        lvlname = thisScene.name.ToCharArray();
        if(string.Compare(thisScene.name,"LevelSelect")!=0)
            if(GameObject.Find("Main/Canvas/Next Level Menu").GetComponent<RectTransform>()!=null)
                nextLevelMenu = GameObject.Find("Main/Canvas/Next Level Menu").GetComponent<RectTransform>();
        
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
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
        if (lvlname[5] == '3' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() +lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
        {
            nextLevelMenu.gameObject.SetActive(true);
        }
        else if (lvlname[5] == '5' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
        {
            nextLevelMenu.gameObject.SetActive(true);
        }
        else if (lvlname[5] == '7' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
        {
            nextLevelMenu.gameObject.SetActive(true);
        }
        else if (lvlname[4] == '1' && lvlname[5] == '0' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
        {
            nextLevelMenu.gameObject.SetActive(true);
        }
        /*if (lvlname[4] == '1' && lvlname[5] == '0' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
        {
            nextLevelMenu.gameObject.SetActive(true);
        }*/

        else if (scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
        {
            SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString(), LoadSceneMode.Single);
        }  
        else
            SceneManager.LoadScene("Main",LoadSceneMode.Single);
    }
    public void nextLevel()
    {

        if (lvlname[2].ToString() == "9" && scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()))
        {
            SceneManager.LoadScene(lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);
            PlayerPrefs.SetString("LEVEL", lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString());
        }
        else if (scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()))
        {
            SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);
            PlayerPrefs.SetString("LEVEL", lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString());
        }
        else
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
