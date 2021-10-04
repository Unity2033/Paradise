using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner_ADS : MonoBehaviour, IUnityAdsListener
{
    void Start()
    {
        Advertisement.Initialize("4376819");
        Show_Banner();
    }

    public void Show_Banner()
    {
        if (Advertisement.IsReady("banner"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("banner");
        }
        else
        {
            StartCoroutine(Repeate_Banner());
        }
    }

    IEnumerator Repeate_Banner()
    {
        yield return new WaitForSeconds(1f);
        Show_Banner();
    }

    public void Reward_Show()
    {
        Advertisement.Show("Reward");
    }

    public void OnUnityAdsReady(string placementId)
    {
      
    }

    public void OnUnityAdsDidError(string message)
    {
       
    }

    public void OnUnityAdsDidStart(string placementId)
    {
       
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            Singleton.instance.Currency += Random.Range(1, 10);
        }
        else if(showResult == ShowResult.Failed)
        {

        }
    }
}
