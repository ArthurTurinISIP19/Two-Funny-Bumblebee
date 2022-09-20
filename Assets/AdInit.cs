using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdInit : MonoBehaviour
{
    public void Awake()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
