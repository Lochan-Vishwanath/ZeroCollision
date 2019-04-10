using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour {

    SpriteRenderer other;// frame;
   // Color mycolor;
   // bool checkingDone = false;
    int no;
    public Transform parent;
    bool movetowards = false;
    Transform target;

    private void Start()
    {
        //frame = GameObject.Find("Main/Frame Transperent").GetComponent<SpriteRenderer>();
        //other = GetComponent<SpriteRenderer>();
        other = GetComponentInParent<SpriteRenderer>();
        no = GetComponentInParent<randomColor>().Set_Option;
    }
    private void Update()
    {
        if (movetowards)
        {
            parent.position = Vector2.MoveTowards(parent.position, target.position, 10 * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "EnemyB" || collision.transform.tag == "Spike")
        {
            InvokeRepeating("trigger", 0.1f, 0.5f);
            //InvokeRepeating("triggerframe", 0.1f, 0.5f);
        }
        if (collision.transform.tag == "EnemyA")
        {
            int colno=collision.GetComponentInParent<randomColor>().Set_Option;
            if (!(no == colno))
            {
                //Debug.Log("not same color");
                InvokeRepeating("trigger", 0.1f, 0.5f);
                //InvokeRepeating("triggerframe", 0.1f, 0.5f);
            }
            else
            {
                target = collision.gameObject.transform;
                movetowards = true;
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
        if(gameObject.activeInHierarchy)
        StartCoroutine(flash());
    }
   /* void triggerframe()
    {
        if (gameObject.activeInHierarchy)
            StartCoroutine(flashframe());
    }*/
    IEnumerator flash()
    {
        Color colour = other.color;
        colour.a = 0.5f;
        other.color = colour;
        yield return new WaitForSeconds(0.3f);
        colour.a = 0f;
        other.color = colour;
    }
    /*IEnumerator flashframe()
    {
        Color colour = frame.color;
        colour.a = 0.5f;
        frame.color = colour;
        yield return new WaitForSeconds(0.3f);
        colour.a = 0f;
        frame.color = colour;
    }*/
}
