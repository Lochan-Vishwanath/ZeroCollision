using UnityEngine;
using UnityEngine.UI;

public class levelSelect : MonoBehaviour
{
    public bool DEVELOPER_BUILD = false;
    public Button[] Levels;
    int maxlevelno;
    char[] maxlvl;
    
    // Start is called before the first frame update
    void Start()
    {
        if (string.Compare(PlayerPrefs.GetString("LEVEL", "0"), "0") == 0)
            maxlevelno = 0;
        else
        {
            maxlvl = PlayerPrefs.GetString("LEVEL").ToCharArray();
            //maxlvl = 0.ToString().ToCharArray();
            //Debug.Log(new string(maxlvl));
            maxlevelno = int.Parse((maxlvl[1] - '0').ToString() + (maxlvl[2] - '0').ToString());
            //Debug.Log(maxlevelno);
        }
        for (int i = 1; i < Levels.Length; i++) { 
            if(i+1>maxlevelno)//i+1 cause we need to unlock the next level
                Levels[i].interactable = DEVELOPER_BUILD;
        }
        Levels[0].interactable = true;
    }
}
