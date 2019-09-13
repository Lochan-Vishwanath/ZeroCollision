using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUp : MonoBehaviour
{
    void Start()
    {
        /* Mandatory - set your AppsFlyer’s Developer key. */
        AppsFlyer.setAppsFlyerKey("8MAzUC3B2BHYVi2uYVHaSd");
        /* For detailed logging */
        /* AppsFlyer.setIsDebug (true); */
#if UNITY_IOS
        /* Mandatory - set your apple app ID
         NOTE: You should enter the number only and not the "ID" prefix */
        AppsFlyer.setAppID("W7RZX86KPC.com.Lochan.ColorSplat");
        AppsFlyer.trackAppLaunch();
#elif UNITY_ANDROID
  /* Mandatory - set your Android package name */
  AppsFlyer.setAppID ("YOUR_ANDROID_PACKAGE_NAME_HERE");
  /* For getting the conversion data in Android, you need to add the "AppsFlyerTrackerCallbacks" listener.*/
  AppsFlyer.init ("YOUR_APPSFLYER_DEV_KEY","AppsFlyerTrackerCallbacks");
#endif
    }


}
