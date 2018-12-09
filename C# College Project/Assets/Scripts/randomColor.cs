using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomColor : MonoBehaviour {

    SpriteRenderer myrender;
    [Range(0, 5)]
    public int Set_Option = 0;
   public ColoursScript cs;
    void Start(){
        myrender = GetComponent<SpriteRenderer>();
        Color32 newcolor =cs.setColor(Set_Option);
        myrender.color = newcolor;
    }

    void completelyRandom()
    {
        myrender = GetComponent<SpriteRenderer>();
        Color newcolor = new Color(Random.value, Random.value, Random.value, 1.0f);
        myrender.color = newcolor;
    }

    
}
