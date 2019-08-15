using UnityEngine;


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
