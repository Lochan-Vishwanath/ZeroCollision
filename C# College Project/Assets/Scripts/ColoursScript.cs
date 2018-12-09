using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoursScript : MonoBehaviour {

    public Color32 o1, o2, o3, o4, o5;
    SpriteRenderer Myrender;
    
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
}
