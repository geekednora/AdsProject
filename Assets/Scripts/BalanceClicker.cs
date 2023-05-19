using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class BalanceClicker : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public int balance = 0;
    public GameObject text;
    public string _adUnitId;
    
    // Start is called before the first frame update
    void Start()
    {
        balance = 0;
        Debug.Log("Balance is - " + balance);
    }

    // Update is called once per frame
    private void Awake()
    {
        LoadAd();
    }

    public void OnClick()
    {
        ShowAd();
        balance += 50;
        Debug.Log("Balance is - " + balance);
        text.GetComponent<TMP_Text>().text = balance.ToString();
    }


    public void LoadAd()
    {
        Debug.Log("Loading Ad : " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }
    
    public void ShowAd()
    {
        Advertisement.Show(_adUnitId, this);
    }
    
    
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
 
        /*if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }*/
    }
    
    
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
        }
    }
    
    
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }
    
    
    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }
    
    
    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
}
