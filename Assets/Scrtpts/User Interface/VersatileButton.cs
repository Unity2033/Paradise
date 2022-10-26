using System;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;



public class VersatileButton : MonoBehaviour
{
    private int windowCount = 0;
    private int count = 2;
    private bool power = true;

    public void Open(GameObject window)
    {
        if(++windowCount % 2 == 1)
        {
            window.SetActive(true);
            SoundManager.instance.Sound(1);
            window.GetComponent<Animator>().Rebind();
        }
        else
        {
            window.GetComponent<Animator>().SetTrigger("close");
            SoundManager.instance.Sound(2);
        }
   
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

    public void GameStart()
    {
        if (GameManager.instance.State == GameManager.state.Exit)
        {
            SceneManager.LoadScene(0);
            GameManager.instance.StateCanvas();
        }

        GameManager.instance.State = GameManager.state.Progress;
        GameManager.instance.StateCanvas();
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
