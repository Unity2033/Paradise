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
