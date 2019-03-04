using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badredoff : MonoBehaviour
{
    public RectTransform panel;

    private void Update()
    {
        if (panel.gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
