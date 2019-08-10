using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragwithMouse : MonoBehaviour {
    bool clicked = false;
    public bool draging = false;
    RectTransform panel;
    public static bool cutoff=false;
    Vector3 originalscale;
    //public static bool takemouseinput=true;
    void Start(){
        panel = GameObject.Find("Main/Canvas/Game-Over Menu").GetComponent<RectTransform>();
        originalscale = transform.localScale;
        Debug.Log(originalscale);
        //takemouseinput=true;
    }
//    void LateUpdate(){
//        if(panel.gameObject.activeInHierarchy)
//            takemouseinput=false;
//    }
    private void OnMouseDown()
    {
        clicked = false;
    }
    private void OnMouseUp()
    {
        cutoff=false;
        clicked = true;
        draging = false;
    }
    private void OnMouseDrag()
    {
        draging = true;
        if (!clicked)
        {
            StartCoroutine(pop());
            clicked = true;
        }
        if(StageLoad.stageloading && !cutoff)// && takemouseinput)
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    IEnumerator pop()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("EnemyA");

        foreach (GameObject obj in objs)
        {
            
            if (obj != gameObject && obj.GetComponent<randomColor>().Set_Option == GetComponent<randomColor>().Set_Option)
            {
                //Vector3 originalscale = obj.transform.localScale;
                /* if clicked countinously the size of the object grows*/
                obj.transform.localScale += new Vector3(0.5f,0.5f,0);
                yield return new WaitForSeconds(0.3f);
                obj.transform.localScale = originalscale;
            }
        }
    }
}
