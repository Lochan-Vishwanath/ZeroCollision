using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	public void restartlvl()
    {
        StageLoad.stageloading=false;   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
