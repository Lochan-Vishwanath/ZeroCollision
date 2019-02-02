using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static bool playaudiogood = false,playaudiogameover=false;
    AudioSource mainau;
    public AudioClip good, gameover,next;
    
    void Start()
    {
        
        mainau = GetComponent<AudioSource>();
    }

    
    void LateUpdate()
    {
        if (playaudiogood)
        {
            //mainau.Play();
            mainau.PlayOneShot(good);
            playaudiogood = false;
            //Debug.Log("inside audiomanager");
        }
        if (playaudiogameover)
        {
            mainau.PlayOneShot(gameover);
            playaudiogameover = false;
        }
        /*if (playaudionext)
        {
            mainau.PlayOneShot(next);
           
            if (once)
            {
                playaudionext = false;
                once = false;
            }
        }*/
    }
}
