using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnoffhandanimation : MonoBehaviour
{
    public GameObject hand;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "EnemyA")
        {
            //Debug.Log("active");
            hand.SetActive(false);
        }
    }
    
    
}
