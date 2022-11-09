using System;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class VersatileButton : MonoBehaviour
{
    private int count = 2;
    private bool power = true;
    private int windowCount = 0;

    public void Open(GameObject window)
    {
        SoundManager.Instance.Sound(1);

        if (++windowCount % 2 == 1)
        {
            window.SetActive(true);
            window.GetComponent<Animator>().Rebind();
        }
        else
        {
            window.GetComponent<Animator>().SetTrigger("close");
        } 
    }

    public void SoundMute()
    {       
        power = !power;

        if(power)
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound on");
        }
        else
        {
            GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound off");
        }

        AudioListener.volume = Convert.ToInt32(power);     
    }

    public void Language()
    {
        SoundManager.Instance.Sound(4);

        if(++count >= 4)
            count = 0;
        
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[count];
    }

    public void GameStart()
    {
        SoundManager.Instance.Sound(3);

        if (GameManager.Instance.State == GameManager.state.Exit)
        {
            SceneManager.LoadScene(0);
            GameManager.Instance.StateCanvas();
        }

        GameManager.Instance.State = GameManager.state.Progress;
        GameManager.Instance.StateCanvas();
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
            Social.ReportScore
            (
                DataManager.Instance.data.statirsMaxScore, "CgkIhLHxpZoVEAIQDQ",
                (bool success) =>
                {
                    if(success)
                    {
                        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard);
                    }
                }

            );

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
