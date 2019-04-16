using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resumeButton : MonoBehaviour
{
    RectTransform panel;

    public void resumeGame()
    {
        panel = GameObject.Find("Main/Canvas/Pause Menu").GetComponent<RectTransform>();
        panel.gameObject.SetActive(false);
        RandomMovement.notPaused = true;
    }
}
