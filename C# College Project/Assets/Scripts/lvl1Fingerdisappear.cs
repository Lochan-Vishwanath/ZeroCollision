using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1Fingerdisappear : MonoBehaviour
{
    public GameObject animationObj;
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), Vector2.zero);
            if (hit.collider.gameObject.tag=="EnemyA")
            {
                animationObj.SetActive(false);
            }
        }
    }
    private void OnMouseDown()
    {
        animationObj.SetActive(false);
    }
}
