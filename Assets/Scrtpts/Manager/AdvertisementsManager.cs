using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementsManager : MonoBehaviour
{
    void Start()
    {
        Advertisement.Initialize("4376819");
        BannerAdvertisement();
    }

    public void FullPageAdvertisement()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }
    }

    public void RewardAdvertisementShow()
    {
        if (Advertisement.IsReady("Reward"))
        {
            var options = new ShowOptions { resultCallback = RewardAdvertisement };
            Advertisement.Show("Reward", options);
        }
    }

    public void RewardAdvertisement(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed : Debug.Log("The ad Failed to be Shown");
                break;
            case ShowResult.Skipped : Debug.Log("The ad was Skipped Before reaching the end");
                break;
            case ShowResult.Finished : DataManager.instance.data.diamond += 10;
                break;
        }
    }

    public void BannerAdvertisement()
    {
        if (Advertisement.IsReady("banner"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("banner");
        }
        else
        {
            StartCoroutine(WaitBanner());
        }
    }

    IEnumerator WaitBanner()
    {
        yield return new WaitForSeconds(1f);
        BannerAdvertisement();
    }

}
