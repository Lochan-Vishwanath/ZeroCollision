using UnityEngine;
using UnityEngine.UI;


public class AutoRestart : MonoBehaviour
{
    float timeElapsed = 0;
    public Text Timer;
    public loadlevel ll;
    public RectTransform gameoverpanel;

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > 3.2)
        {
            ll.resetToLevelHead();
            gameoverpanel.gameObject.SetActive(false);
        }
        if (timeElapsed > 2)
            Timer.text = "1";
        else if (timeElapsed > 1)
            Timer.text = "2";
        else if(timeElapsed > 0)
            Timer.text = "3";
    }
}
