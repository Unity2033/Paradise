using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using GooglePlayGames;

public class TitleButton : MonoBehaviour
{

    public void Function1()
    {
        Debug.Log("Open");
        SoundManager.Instance.Sound(SoundType.Open);
    }

    public void Function2()
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

    public void Function3()
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
}
