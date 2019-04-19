using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class lvlinfo : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    bool done = false;
    Scene thisscene;
    private void Start()
    {
        thisscene = SceneManager.GetActiveScene();
        char[] SceneName = thisscene.name.ToCharArray();
        mytxt.text = "Level " + SceneName[1] + " Stage " + SceneName[3];
        StartCoroutine(Pause(2));
    }
    private IEnumerator Pause(int p)
    {
        
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        done = true;
    }
    private void LateUpdate()
    {
        if (done)
            mytxt.color = Color.clear;
    }
}
