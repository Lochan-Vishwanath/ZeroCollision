using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vanish : MonoBehaviour
{
    public RectTransform[] A;
    IEnumerator autoTimer()
    {
        yield return new WaitForSeconds(3);
        foreach(RectTransform x in A)
        {
            x.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine("autoTimer");
    }
}
