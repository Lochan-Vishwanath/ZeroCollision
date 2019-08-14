using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {


    Scene thisScene;
    char[] lvlname = "l0-0".ToCharArray();
    static string oldname;
    static char[] oldlvlname;
    public static int ADCLICKCOUNT;
    public RectTransform _Restart;


    private void Start()
    {
        if (string.IsNullOrEmpty(oldname)) {
            oldname = "l01-01";
            oldlvlname = "l01-01".ToCharArray();
        }
        thisScene = SceneManager.GetActiveScene();
        lvlname = thisScene.name.ToCharArray();
        //Debug.Log(lvlname[1]+ ""+lvlname[2]);
        if (lvlname[1] == '0' && lvlname[2] == '1')
        {
            Debug.Log("HERE1");
            oldlvlname = "l01-01".ToCharArray();
        }

        else if (lvlname[1] != '0')
        {
            Debug.Log("OLD=" + oldlvlname[1] + oldlvlname[2] + "NEW" + lvlname[1] + lvlname[2]);
            if (oldlvlname[1] != lvlname[1] && oldlvlname[2] != lvlname[2])
            {
                Debug.Log("HERE2.1");
                oldlvlname[1] = lvlname[1];
                oldlvlname[2] = lvlname[2];
                ADCLICKCOUNT = int.Parse(lvlname[1].ToString() + lvlname[2].ToString()) / 5+1;
            }
            else
            {
                Debug.Log("HERE3");
                ADCLICKCOUNT--;
            }
            if (ADCLICKCOUNT < 1) _Restart.gameObject.SetActive(false);
        }
        else if (oldlvlname[2] != lvlname[2])
        {
            Debug.Log("HERE2.2");
            oldlvlname[1] = lvlname[1];
            oldlvlname[2] = lvlname[2];
            ADCLICKCOUNT = int.Parse(lvlname[1].ToString() + lvlname[2].ToString()) / 5+1 ;
        }
        
        else
        {
            Debug.Log("HERE3");
            ADCLICKCOUNT--;
        }
        if (ADCLICKCOUNT < 1) _Restart.gameObject.SetActive(false);
    }


    public void restartlvl()
    {
        StageLoad.stageloading=false;   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
