using GooglePlayGames;
using System;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class VersatileButton : MonoBehaviour
{
    private int count = 2;
    private bool power;

    public void Open(GameObject window)
    {
        window.SetActive(true);
        window.GetComponent<Animator>().Rebind();

        SoundManager.instance.Sound(1);
    }

    public void Cancle(GameObject window)
    {
        window.GetComponent<Animator>().SetTrigger("close");

        SoundManager.instance.Sound(2);
    }

    public void SoundMute()
    {       
        power = !power;

        AudioListener.volume = Convert.ToInt32(power);
    }

    public void Language()
    {
        SoundManager.instance.Sound(4);

        if(++count >= 4) count = 0;
        
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[count];
    }


    public void Achievement()
    {
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ShowAchievementsUI();
                    return;
                }
                else
                {
                    return;
                }
            });
        }

        Social.ShowAchievementsUI();
    }

    public void LeaderBoard()
    {
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ShowLeaderboardUI();

                    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard);
                    return;
                }
                else
                {
                    return;
                }
            });
        }

        Social.ShowLeaderboardUI();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
