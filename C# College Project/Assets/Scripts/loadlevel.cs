using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {

	public void loadlvl(string lvlName)
    {
        SceneManager.LoadScene(lvlName,LoadSceneMode.Single);
    }
    public void loadmain()
    {
        SceneManager.LoadScene("Main",LoadSceneMode.Single);
    }
}
