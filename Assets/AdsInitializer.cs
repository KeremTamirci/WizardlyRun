
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    string _gameId;
    [SerializeField] bool _testMode = false;
    bool intIsReady;
    bool rewIsReady;
    bool rewIsWatched=false;

    private void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameId = (Application.platform == RuntimePlatform.IPhonePlayer) ? _iOSGameId : _androidGameId;
        Advertisement.Initialize(_gameId, _testMode, this);
        LoadInerstitialAd();    
        LoadRewardedAd();   


    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }



    public void LoadInerstitialAd()
    {
        Advertisement.Load("Interstitial_Android", this);
    }
    public void LoadRewardedAd()
    {
        Advertisement.Load("Rewarded_Android", this);
    }


    public void OnUnityAdsAdLoaded(string placementId)
    {
        if (placementId.Equals("Interstitial_Android"))
        {
            intIsReady = true;
        }
        else if (placementId.Equals("Rewarded_Android"))
        {
            rewIsReady = true;
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {placementId}: {error.ToString()} - {message}");

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }
    public void OnUnityAdsShowStart(string placementId)
    {
        
    }
    public void OnUnityAdsShowClick(string placementId)
    {
        
    }
    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals("Rewarded_Android") && UnityAdsShowCompletionState.COMPLETED.Equals(showCompletionState))
        {
            rewIsWatched = true;
            FindObjectOfType<AdsManagerScript>().RewardPlayer();
        }
    }
    public void ShowAd()
    {
        Advertisement.Show("Interstitial_Android",this);
    }
    public void ShowRew()
    {
        Advertisement.Show("Rewarded_Android",this);
    }
}
