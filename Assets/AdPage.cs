using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AdPage : MonoBehaviour
{
    private BannerView _bannerAd;
    private InterstitialAd _InterstitialAd;
    List<string> deviceIds = new List<string>();

    void Start()
    {
        deviceIds.Add("0153E0DB6DDE3871277CF9E1103F6C75");
        RequestConfiguration requestConfiguration = new RequestConfiguration
        .Builder()
        .SetTestDeviceIds(deviceIds)
        .build();
        MobileAds.SetRequestConfiguration(requestConfiguration);

        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
        //ShowBanner();
    } 

    public void RequestInterstitial()
    {
        deviceIds.Add("0153E0DB6DDE3871277CF9E1103F6C75");
        string _InterstitialUnitId = "ca-app-pub-2356773422486972/9612957174";
        _InterstitialAd = new InterstitialAd(_InterstitialUnitId);
        AdRequest adRequest = new AdRequest.Builder().Build();
        _InterstitialAd.LoadAd(adRequest);
    }

    public void ShowAd()
    {
        if (_InterstitialAd.IsLoaded())
        {
            _InterstitialAd.Show();
            RequestInterstitial();
        }
    }

    //private void ShowBanner()
    //{
    //    string adUnitId = "ca-app-pub-2356773422486972/2909632239";
    //    _bannerAd = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
    //    AdRequest request = new AdRequest.Builder().Build();
    //    _bannerAd.LoadAd(request);
    //}

}
