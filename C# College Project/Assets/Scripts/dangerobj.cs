using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dangerobj : MonoBehaviour {

    public RectTransform panel;
    public bool Show_GameOver_screen;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "enemy")
        {
            Destroy(collision.gameObject);
            if(Show_GameOver_screen)
                panel.gameObject.SetActive(true);
        }
    }
}
