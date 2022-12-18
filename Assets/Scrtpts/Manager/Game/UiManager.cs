using GooglePlayGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private int count = 2;
    private bool power = true;

    [SerializeField] GameObject window;

    public void WindowToggle(bool state)
    {
        SoundManager.Instance.Sound(1);

        window.SetActive(state);
    }

    public void GameStart()
    {
        SoundManager.Instance.Sound(3);

        if (GameManager.Instance.State == GameManager.state.Exit)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        GameManager.Instance.State = GameManager.state.Progress;
    }

    public void SoundMute()
    {
        power = !power;

        switch (power)
        {
            case true:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound on");
                break;
            case false:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound off");
                break;
        }

        AudioListener.volume = Convert.ToInt32(power);
    }

    public void Language()
    {
        SoundManager.Instance.Sound(4);

        if (++count >= 4)
        {
            count = 0;
        }
        
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
            Social.ReportScore
            (
                DataManager.Instance.data.statirsMaxScore, "CgkIhLHxpZoVEAIQDQ",
                (bool success) =>
                {
                    if (success)
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
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
