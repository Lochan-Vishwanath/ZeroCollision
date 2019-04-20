using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    RectTransform panel;

    public void pauseGame()
    {
        panel = GameObject.Find("Main/Canvas/Pause Menu").GetComponent<RectTransform>();
        panel.gameObject.SetActive(true);
        RandomMovement.notPaused = false;
    }
}
