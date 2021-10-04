using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class Google_Manager : MonoBehaviour
{

    private void Awake()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    void Start()
    {
        if(Social.localUser.authenticated) // 이미 인증된 사용자는 바로 로그인 성공합니다.
        {
            return;
        }
        else
        {
            Social.localUser.Authenticate(AuthenticateCallback);
        }

        if(Singleton.instance.Adventure == 1)
        {
            Social.ReportProgress(GPGSIds.achievement, 100, null);
        }

        if (Singleton.instance.Quest_Barrier == 1)
        {
            Social.ReportProgress(GPGSIds.achievement__sh1, 100, null);
        }

        if (Singleton.instance.Quest_Slow == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_3, 100, null);
        }

        if (Singleton.instance.Quest_Turret == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_2, 100, null);
        }

        if(Singleton.instance.Gliese_876 == 1)
        {
            Social.ReportProgress(GPGSIds.achievement_4, 100, null);
        }    
    }

    void AuthenticateCallback(bool success)
    {
        if(success) {}
        else {}
    }

    public void Achievement_UI()
    {
        // Sign In 이 되어있지 않은 상태라면
        // Sign In 후 업적 UI 표시 요청할 것
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    // Sign In 성공
                    // 바로 업적 UI 표시 요청
                    Social.ShowAchievementsUI();
                    return;
                }
                else
                {
                    // Sign In 실패 처리
                    return;
                }
            });
        }

        Social.ShowAchievementsUI();
    }

    public void ShowLeaderboardUI()
    {
        // Sign In 이 되어있지 않은 상태라면
        // Sign In 후 리더보드 UI 표시 요청할 것
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    // Sign In 성공
                    // 바로 리더보드 UI 표시 요청
                      Social.ShowLeaderboardUI();

                    // ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard);
                    return;
                }
                else
                {
                    // Sign In 실패 
                    // 그에 따른 처리
                    return;
                }
            });
        }
        Social.ShowLeaderboardUI();

    }
}
