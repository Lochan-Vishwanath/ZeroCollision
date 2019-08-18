using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class menuLevelName : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    Scene thisscene;

    private void Start()
    {
        thisscene = SceneManager.GetActiveScene();
        char[] SceneName = thisscene.name.ToCharArray();

        mytxt.text = "LEVEL" + SceneName[1].ToString() + SceneName[2].ToString();
    }
}
