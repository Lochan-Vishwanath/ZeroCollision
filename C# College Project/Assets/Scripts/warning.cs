using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class warning : MonoBehaviour {

    SpriteRenderer other;

    private void Start()
    {
        //other = GetComponent<SpriteRenderer>();
        other = GetComponentInParent<SpriteRenderer>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            if (!other.GetComponentInParent<SpriteRenderer>().color.Equals(collision.GetComponentInParent<SpriteRenderer>().color))
            {
                Debug.Log("not same color");
                InvokeRepeating("trigger",0.1f,0.3f);
            }
            else
            {
                Debug.Log("samecolor");
            }
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
