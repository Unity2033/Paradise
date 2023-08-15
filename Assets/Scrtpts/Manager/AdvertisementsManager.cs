using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementsManager : MonoBehaviour
{
    void Start()
    {
        Advertisement.Initialize("4376819");
        StartCoroutine(BannerInitialize());
    }

    public void FullPageAdvertisement()
    {
        Advertisement.Show("video");
    }

    private IEnumerator BannerInitialize()
    {
        WaitForSeconds wait = new WaitForSeconds(0.5f);

        while (Advertisement.isInitialized == false)
        {
            yield return wait;
        }

        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show("banner");
    }

}
