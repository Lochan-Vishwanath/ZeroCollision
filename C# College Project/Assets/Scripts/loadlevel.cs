using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class loadlevel : MonoBehaviour {

    public Text Restarttxt;
    RectTransform nextLevelMenu;
    Scene thisScene;
    char[] lvlname = "l0-0".ToCharArray();
    string _nextlevel, _nextstage;
    List<string> scenesInBuild = new List<string>();
    public TextMeshProUGUI Moves, timetake;
    bool timeset=false;
    private void Start()
    {
        thisScene = SceneManager.GetActiveScene();
        lvlname = thisScene.name.ToCharArray();
        //Debug.Log(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString());
        
        if (string.Compare(thisScene.name,"LevelSelect")!=0)
            if(GameObject.Find("Main/Canvas/Next Level Menu").GetComponent<RectTransform>()!=null)
                nextLevelMenu = GameObject.Find("Main/Canvas/Next Level Menu").GetComponent<RectTransform>();
        //nextLevel();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
        //nextLevel();
        
        int stage, level;
        level = int.Parse((lvlname[1] - '0').ToString() + (lvlname[2] - '0').ToString()) + 1;
        stage = int.Parse((lvlname[4] - '0').ToString() + (lvlname[5] - '0').ToString()) + 1;
        if (level >= 10)
            _nextlevel = ('l').ToString() + (int.Parse((lvlname[1] - '0').ToString() + (lvlname[2] - '0').ToString()) + 1).ToString() + "-01";
        else
            _nextlevel = ('l').ToString() + ('0').ToString() + (int.Parse((lvlname[1] - '0').ToString() + (lvlname[2] - '0').ToString()) + 1).ToString() + "-01";

        if (stage >= 10)
            _nextstage = ('l').ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + (int.Parse((lvlname[4] - '0').ToString() + (lvlname[5] - '0').ToString()) + 1).ToString();
        else
            _nextstage = ('l').ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + ('0').ToString() + (int.Parse((lvlname[4] - '0').ToString() + (lvlname[5] - '0').ToString()) + 1).ToString();
        //Debug.Log(_nextstage+" "+_nextlevel);
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
        Restart.ADCLICKCOUNT = int.Parse(lvlname[1].ToString() + lvlname[2].ToString()) / 5 + 2;
        //Debug.Log(Restart.ADCLICKCOUNT);
        SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);

    }

    

    
    public void nextStage()
    {
        //Debug.Log(scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()) +" " + lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString());

        if (scenesInBuild.Contains(_nextstage))
        {
            //Debug.Log("yes1");
            SceneManager.LoadScene(_nextstage, LoadSceneMode.Single);
        }
        else
        {
            //Debug.Log("yes2");
            nextLevelMenu.gameObject.SetActive(true);
            if (!timeset) {
                playerStats.timeTaken += Time.time - playerStats.timer;
                //Debug.Log(playerStats.timeTaken);
                timeset = true;
            }
            
            Moves.text = DragwithMouse.Moves.ToString();
            if ((int)playerStats.timeTaken / 60 > 0)
                timetake.text = ((int)playerStats.timeTaken / 60).ToString() + " m " + ((int)playerStats.timeTaken % 60).ToString() + " s";
            else
                timetake.text = ((int)playerStats.timeTaken).ToString() + " s";
            //DragwithMouse.Moves = 0;
            //playerStats.timeTaken = 0;
        }

        /* if (lvlname[5] == '3' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
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
         else if (lvlname[4] == '1' && lvlname[5] == '0' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString()+((lvlname[5] - '0' + 1)).ToString()))
         {
             nextLevelMenu.gameObject.SetActive(true);
         }
         /*if (lvlname[4] == '1' && lvlname[5] == '0' && !scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
         {
             nextLevelMenu.gameObject.SetActive(true);
         }

         else
         {

             if (scenesInBuild.Contains(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString()))
             {
                 SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ((lvlname[5] - '0' + 1)).ToString(), LoadSceneMode.Single);
             }
             else
             {
                 int a = lvlname[5] - '0' + 1;
                 if (a > 9)
                 {
                     //lvlname[4] = (char)(a / 10);
                     //lvlname[5] = (char)(a % 10);
                     SceneManager.LoadScene(lvlname[0].ToString() + lvlname[1].ToString() + lvlname[2].ToString() + lvlname[3].ToString() + (a / 10).ToString() + (a % 10).ToString(), LoadSceneMode.Single);
                 }
                 else
                 SceneManager.LoadScene("Main", LoadSceneMode.Single);
             }
         }*/
    }
    public void nextLevel()
    {
        string eventName = "af_fakeImpression";
        Dictionary<string, string> eventParams = new Dictionary<string, string>() { { "imp", "1" } };
        AppsFlyer.trackRichEvent(eventName, eventParams);
        Debug.Log("MAGIC");
        if (scenesInBuild.Contains(_nextlevel))
        {
            //Debug.Log("YES");
            SceneManager.LoadScene(_nextlevel, LoadSceneMode.Single);
        }
        else
        {
            //Debug.Log("error");
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }
        /* int a = lvlname[2] - '0' + 1;
     //    if (string.Compare(lvlname[2].ToString(),"9")==0 && scenesInBuild.Contains(lvlname[0].ToString() + ((lvlname[2] - '0' + 1)).ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()))
     //    {
     //        SceneManager.LoadScene(lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString(), LoadSceneMode.Single);
     //
     //        lvlname[4] = lvlname[4] != '0' ? '0' : '0';
     //        if (string.Compare(PlayerPrefs.GetString("LEVEL"), lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString()) <= 0)
     //        {
     //            PlayerPrefs.SetString("LEVEL", lvlname[0].ToString() + ((lvlname[1] - '0' + 1)).ToString() + ('0').ToString() + lvlname[3].ToString() + lvlname[4].ToString() + ('1').ToString());
     //           Debug.Log("here1");
     //        }
     //        else
     //            Debug.Log("BAD1");
     //   }
         if (a > 9)
         {
                 //lvlname[4] = (char)(a / 10);
                 //lvlname[5] = (char)(a % 10);
                 SceneManager.LoadScene(lvlname[0].ToString()+a.ToString()+lvlname[3].ToString()+('0').ToString()+('1').ToString(), LoadSceneMode.Single);
             PlayerPrefs.SetString("LEVEL","l0-01");
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
             SceneManager.LoadScene("Main", LoadSceneMode.Single);*/
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
