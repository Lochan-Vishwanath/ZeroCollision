﻿using System.Collections;
using UnityEngine;

public class Dragable : MonoBehaviour {

	Collider2D mycoll;
	bool objtouched=false;
    bool objpop = false;

	//public static bool taketouchinput=true;
	void Start () {
		mycoll=GetComponent<Collider2D>();
		//taketouchinput=true;
	}
	
	// Update is called once per frame
	void Update () {
		if(StageLoad.stageloading )//&& taketouchinput)
		if(Input.touchCount>0){
			Touch t=Input.GetTouch(0);
			Vector2 touchPosworld2D = Camera.main.ScreenToWorldPoint(t.position);
			if(!objtouched)
				if(mycoll==Physics2D.OverlapCircle(touchPosworld2D,0.01f)){
					objtouched=true;
                    objpop = true;
				}
            if (objpop)
            {
                StartCoroutine(pop());
                    objpop = false;
            }
		    if(objtouched){
			    transform.position=touchPosworld2D;
			    if(t.phase==TouchPhase.Ended){
				    objtouched=false;
			    }
		    }

				/* if(t.phase==TouchPhase.Moved){
					Debug.Log("Yo this boi moved");
					Vector3 touchPosworld = Camera.main.ScreenToWorldPoint(t.position);
					Vector2 touchPosworld2D=new Vector2(touchPosworld.x,touchPosworld.y);
					RaycastHit2D hitInformation = Physics2D.Raycast(touchPosworld2D, Camera.main.transform.forward);

					if (hitInformation.collider != null) {
                 	//We should have hit something with a 2D Physics collider!
                	GameObject touchedObject = hitInformation.transform.gameObject;
                 	//touchedObject should be the object someone touched.
                 	Debug.Log("Touched " + touchedObject.transform.name);
					touchedObject.transform.position=touchPosworld2D;
					}
				}*/
			
		}
	}
    IEnumerator pop()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("EnemyA");

        foreach (GameObject obj in objs)
        {
            if (obj != gameObject && obj.GetComponent<randomColor>().Set_Option == GetComponent<randomColor>().Set_Option)
            {
                Vector3 originalscale = obj.transform.localScale;
                /* if clicked countinously the size of the object grows*/
                obj.transform.localScale *= 1.1f;
                yield return new WaitForSeconds(0.3f);
                obj.transform.localScale = originalscale;
            }
        }
    }
}
