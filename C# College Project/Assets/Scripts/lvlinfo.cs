using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class lvlinfo : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    //bool done = false;
    Scene thisscene;
    private void Start()
    {
        thisscene = SceneManager.GetActiveScene();
        char[] SceneName = thisscene.name.ToCharArray();
        //mytxt.text = "Level " + SceneName[1] + " Stage " + SceneName[3];
        //mytxt.text = "Level " + SceneName[1]+SceneName[2] + " Stage " + SceneName[4]+SceneName[5];

        List<string> scenesInBuild = new List<string>();
        for (int i = 1; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            int lastSlash = scenePath.LastIndexOf("/");
            scenesInBuild.Add(scenePath.Substring(lastSlash + 1, scenePath.LastIndexOf(".") - lastSlash - 1));
        }
        for(int j=0;j<scenesInBuild.Count;j++)
        //Debug.Log(scenesInBuild[j]);
        if (scenesInBuild.Contains(SceneName[0].ToString() + SceneName[1].ToString() + SceneName[2].ToString() +SceneName[3].ToString()+ 10.ToString()))
            //Debug.Log("here1");
        mytxt.text = "Stage " + SceneName[4] + SceneName[5] + "/10";
        else if (scenesInBuild.Contains(SceneName[0].ToString() + SceneName[1].ToString() + SceneName[2].ToString()+SceneName[3].ToString()+0.ToString() + 7.ToString()))
            //Debug.Log("here2");
        mytxt.text = "Stage " + SceneName[4] + SceneName[5] + "/07";
        else if (scenesInBuild.Contains(SceneName[0].ToString() + SceneName[1].ToString() + SceneName[2].ToString() + SceneName[3].ToString() + 0.ToString() + 5.ToString()))
            //Debug.Log("here3");
        mytxt.text = "Stage " + SceneName[4] + SceneName[5] + "/05";
        else
            Debug.Log("false");
        StartCoroutine(Pause(2));
    }
    private IEnumerator Pause(int p)
    {
        
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
    //    done = true;
        mytxt.color = Color.clear;
    }
    //private void LateUpdate()
    //{
    //    if (done)
    //        mytxt.color = Color.clear;
    //}
}
