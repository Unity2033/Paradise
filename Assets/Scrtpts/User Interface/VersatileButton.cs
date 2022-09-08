using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class VersatileButton : MonoBehaviour
{
   private int count = 2;

    public void Open(GameObject window)
    {
        window.SetActive(true);
        window.GetComponent<Animator>().Rebind();

        Sound_Manager.instance.Sound(1);
    }

    public void Cancle(GameObject window)
    {
        window.GetComponent<Animator>().SetTrigger("close");

        Sound_Manager.instance.Sound(2);
    }

    public void Language()
    {
        Sound_Manager.instance.Sound(4);

        if(++count >= 4)
        {
            count = 0;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[count];
    }


    public void Achievement()
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

    public void LeaderBoard()
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

    public void Exit()
    {
        Application.Quit();
    }
}
