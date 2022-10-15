using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementsManager : MonoBehaviour
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

}
