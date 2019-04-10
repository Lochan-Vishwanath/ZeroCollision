﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class lvlinfo : MonoBehaviour
{
    public TextMeshProUGUI mytxt;
    bool done = false;

    private void Start()
    {
        StartCoroutine(Pause(2));
    }
    private IEnumerator Pause(int p)
    {
        
        float pauseEndTime = Time.realtimeSinceStartup + p;
        while (Time.realtimeSinceStartup < pauseEndTime)
        {
            yield return 0;
        }
        done = true;
    }
    private void LateUpdate()
    {
        if (done)
            mytxt.color = Color.clear;
    }
}
