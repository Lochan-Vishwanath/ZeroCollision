using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dots : MonoBehaviour
{
    public Transform destination1, destination2;
    public GameObject RedDot;
    //distance between 2 dots = 0.4f
    float distbtwn,noofpts,anglebtwn,x,y;
    Vector3 distance;
    public bool ceilValue=false;

    private void Start()
    {
        distbtwn = Vector3.Distance(destination1.position,destination2.position);
        if(ceilValue)
            noofpts = Mathf.Ceil  (distbtwn / 1f);
        else
            noofpts = Mathf.Floor (distbtwn / 1f);
        //anglebtwn = Vector3.Angle(destination1.position, destination2.position)*Mathf.Deg2Rad*-1;
        x =  destination2.position.x - destination1.position.x;
        y =  destination2.position.y - destination1.position.y;
        float sign = (destination2.position.y < destination1.position.y) ? -1.0f : 1.0f;
        //Debug.Log(sign);
        anglebtwn = Mathf.Atan2(y, x)*sign;
        for (int i = 0; i <= noofpts; i++)
        {
            if (i == 0 || i == noofpts)
                RedDot.transform.localScale = new Vector3(2f, 2f, 0);
            else
                RedDot.transform.localScale = Vector3.one;
            distance = new Vector3(destination1.position.x+(i * 1f * Mathf.Cos(anglebtwn)), destination1.position.y + (i * 1f * Mathf.Sin(anglebtwn))*sign, 0);
            Instantiate(RedDot,distance,Quaternion.identity);
        }
    }
}
