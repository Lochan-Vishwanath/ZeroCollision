using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour {

    SpriteRenderer other;
   // Color mycolor;
   // bool checkingDone = false;
    int no;

    private void Start()
    {
        //other = GetComponent<SpriteRenderer>();
        other = GetComponentInParent<SpriteRenderer>();
        no = GetComponentInParent<randomColor>().Set_Option;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "EnemyB")
        {
            InvokeRepeating("trigger", 0.1f, 0.3f);
        }
        if (collision.transform.tag == "EnemyA")
        {
            int colno=collision.GetComponentInParent<randomColor>().Set_Option;
            if (!(no == colno))
            {
                Debug.Log("not same color");
                InvokeRepeating("trigger", 0.1f, 0.3f);
            }
            else
            {
                Debug.Log("samecolor");
            }


            /*
            SpriteRenderer[] sps = collision.GetComponentsInParent<SpriteRenderer>();
            foreach (SpriteRenderer x in sps)
            {
                if (mycolor.Equals(x.color) && !checkingDone)
                {
                    checkingDone = true;
                }
                else
                {
                    checkingDone = false;
                }
            }
            if (!checkingDone)
            {
                Debug.Log("not same color");
                InvokeRepeating("trigger", 0.1f, 0.3f);
            }
            else
            {
                Debug.Log("samecolor");
            }
            */
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke();
    }

    void trigger()
    {
        StartCoroutine(flash());
    }
    IEnumerator flash()
    {
        Color colour = other.color;
        colour.a = 0.5f;
        other.color = colour;
        yield return new WaitForSeconds(0.3f);
        colour.a = 0f;
        other.color = colour;
    }
}
