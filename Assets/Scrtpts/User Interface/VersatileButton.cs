using UnityEngine;
using UnityEngine.UI;

public class VersatileButton : MonoBehaviour
{

    public void Open(GameObject window)
    {
        window.SetActive(true);
        window.GetComponent<Animator>().Rebind();

        Sound_Manager.instance.Sound(1);
    }

    public void Cancle(GameObject window)
    {
        window.GetComponent<Animator>().SetTrigger("close");

        Sound_Manager.instance.Sound(3);
    }

    public void Language()
    {
        Sound_Manager.instance.Sound(5);

        if (++Singleton.instance.Language_Count == 4)
        {
            Singleton.instance.Language_Count = 0;
        }

        Singleton.instance.SaveData();
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
