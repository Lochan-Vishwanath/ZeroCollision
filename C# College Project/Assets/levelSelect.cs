using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{
    public Button[] Levels;
    int maxlevelno;
    char[] maxlvl;
    // Start is called before the first frame update
    void Start()
    {
        maxlvl = PlayerPrefs.GetString("LEVEL","0").ToCharArray();
        maxlevelno = int.Parse((maxlvl[1]-'0').ToString()+(maxlvl[2]-'0').ToString());
        
        for (int i = 0; i < Levels.Length; i++) { 
            if(i+1>maxlevelno)
                Levels[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   if (Input.GetKey(KeyCode.X))
        {   
            Debug.Log(maxlevelno);
        }
    }
}
