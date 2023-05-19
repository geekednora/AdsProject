using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Advertisements;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
    public string _gameID = "5284619";

    private void Awake()
    {
        InitializeAds();
    }


    public void InitializeAds()
    {
        Advertisement.Initialize(_gameID, true, this);
    }
    
    
    public void OnInitializationComplete()
    {
        Debug.Log("Ads Init Comlete!");
    }

    
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Ads Init Failed : {error.ToString()} - {message}");
    }
    
}
