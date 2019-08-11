using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadlevel : MonoBehaviour {

    public Text Restarttxt;
    RectTransform nextLevelMenu;
    Scene thisScene;
    char[] lvlname = "l0-0".ToCharArray();
    List<string> scenesInBuild = new List<string>();
    private void Start()
    {

        thisScene = SceneManager.GetActiveScene();
        lvlname = thisScene.name.ToCharArray();
        Debug.Log(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString());
        if (string.Compare(thisScene.name,"LevelSelect")!=0)
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
        SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);
    }
    public void nextStage()
    {
        if (lvlname[5] == '3' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
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
        {
            
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
    }
    public void nextLevel()
    {

        if (lvlname[2].ToString() == "9" && scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()))
        {
            SceneManager.LoadScene(lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);
            lvlname[4] = lvlname[4] != '0' ? '0' : '0';
            if (string.Compare(PlayerPrefs.GetString("LEVEL"), lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()) <= 0)
            {
                PlayerPrefs.SetString("LEVEL", lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString());
                Debug.Log("here1");
            }
            else
                Debug.Log("BAD1");
        }
        else if (scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()))
        {
            SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);
            lvlname[4]=lvlname[4] != '0' ? '0' : '0';
            if (string.Compare(PlayerPrefs.GetString("LEVEL"), lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()) <= 0)
            {
                PlayerPrefs.SetString("LEVEL", lvlname[0].ToString() + lvlname[1].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString());
                Debug.Log("Here2");

            }
            else
                Debug.Log("Bad2");
        }
        else
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void AutoRestart()
    {
        StartCoroutine("autoTimer");
    }

    IEnumerator autoTimer()
    {
        Restarttxt.text = "3";
        yield return new WaitForSeconds(1);
        Restarttxt.text = "2";
        yield return new WaitForSeconds(2);
        Restarttxt.text = "1";
        yield return new WaitForSeconds(3);
        Restarttxt.text = "1";
        resetToLevelHead();
    }
}
