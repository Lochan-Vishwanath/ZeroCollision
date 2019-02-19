﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragwithMouse : MonoBehaviour {
    bool clicked = false;
    private void OnMouseDown()
    {
        clicked = false;
    }
    private void OnMouseUp()
    {
        clicked = true;
    }
    private void OnMouseDrag()
    {
        if(StageLoad.stageloading)
        if (!clicked)
        {
            StartCoroutine(pop());
            clicked = true;
        }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
