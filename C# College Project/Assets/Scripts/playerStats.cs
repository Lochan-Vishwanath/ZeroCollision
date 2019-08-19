using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerStats : MonoBehaviour
{
    public static float timer, timeTaken;
    Scene thisscene;
    public RectTransform nextLevel;
    private void Start()
    {
        thisscene = SceneManager.GetActiveScene();
        char[] SceneName = thisscene.name.ToCharArray();
        if (SceneName[4] == '0' && SceneName[5] == '1') {
            timer = 0;
            DragwithMouse.Moves = 0;
        }
        if (timer == 0) timer = Time.time;
    }
}
