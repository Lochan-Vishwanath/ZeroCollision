using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalMovement : MonoBehaviour
{
    public Transform position;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.transform.tag=="EnemyA"){
            collision.gameObject.SetActive(false);
            collision.transform.position=position.position;
            collision.gameObject.SetActive(true);
        }
    }
}
