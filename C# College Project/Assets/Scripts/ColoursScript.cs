using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoursScript : MonoBehaviour {

    public Color32 o1, o2, o3, o4, o5;
    SpriteRenderer Myrender;
    public RectTransform nextPanel;
    public static int no_of_objs = 0;
    [HideInInspector]
    public GameObject[] objs;

    bool once = true;

    public Color32 setColor(int Set_Option)
    {
        switch (Set_Option)
        {
            case 1: return o1; 
            case 2: return o2; 
            case 3: return o3; 
            case 4: return o4; 
            case 5: return o5; 
            default: throw new System.Exception("Color not Selected");
        }
    }

    private void Start()
    {
        once = true;
        no_of_objs = 0;
        objs = GameObject.FindGameObjectsWithTag("EnemyA");

        foreach (GameObject obj in objs)
        {
            no_of_objs++;
        }
        Debug.Log(no_of_objs);
    }
    private void LateUpdate()
    {
        if (no_of_objs <= 0)
        {
            nextPanel.gameObject.SetActive(true);
            if (once)
            {
                GetComponent<AudioSource>().Play();
                once = false;
            }
            
        }
    }
}
