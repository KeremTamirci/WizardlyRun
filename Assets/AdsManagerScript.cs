using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManagerScript : MonoBehaviour
{

    public die die;
    public GameObject deathpanel;

    // Start is called before the first frame update
    void Start()
    {
       // Gerekli variablelar� ekle
    }


    public void PlayAd()
    {
        FindObjectOfType<AdsInitializer>().ShowAd();
        //Initializerdaki play ad'e ba�la
        // Bunu 3 4 b�l�mde bir olacak �ekilde koy hallet scenemanagerdan
    }

    public void PlayRewardedAd()
    {
        FindObjectOfType<AdsInitializer>().ShowRew();
            //Initializerdaki play rewe ba�la
    }


    /*
    // a�a��daki blok yerin rewiswatched true oldu�unda Rewardplayeri �al��t�racak bir �ey yap
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if((placementId == "Rewarded_Android")&&(showResult== ShowResult.Finished))
        {
            RewardPlayer();
        }
    }
    */


    public void RewardPlayer()
    {
        if(deathpanel != null)
        {
            deathpanel.SetActive(false);
        }
        InvokeToReward();
    }
    
    public void InvokeToReward()
    {
        FindObjectOfType<die>().Revive();
    }


    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }


    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { }

}
