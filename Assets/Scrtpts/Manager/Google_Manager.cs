using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using System.Collections;

public class Google_Manager : MonoBehaviour
{

    [SerializeField] Image Login;
    float time = 0f;
    float Fade_Out = 1f;

    private void Awake()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
    }

    void Start()
    {       
        if (Singleton.Connect == 0)
        {
            StartCoroutine(Connection());
        }
        else
        {
            Login.gameObject.SetActive(false);
        }
    }

    void AuthenticateCallback(bool success)
    {
        if(success)
        {
            Singleton.Connect++;
            StartCoroutine(Fade());
        }
        else 
        {
            Login.gameObject.SetActive(true);
        }
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

    IEnumerator Connection()
    {
        yield return null;

        int try_Loing = 3;

        while(true)
        {
            yield return null;

            if(Social.localUser.authenticated)
            {
                break;
            }
            else
            {
                try_Loing--;
                Social.localUser.Authenticate(AuthenticateCallback);
                yield return new WaitForSeconds(1.0f);
            }

            // 3번 로그인 시도 후에 로그인 되지 않으면 강제 종료
            if(try_Loing < 0)
            {
                // Text로 로그인 실패를 알린 후 Application.Quit(); 발동
                break;
            }
        }
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.25f);

        Color color = Login.color;

        while (color.a > 0f)
        {
            time += Time.deltaTime / Fade_Out;
            color.a = Mathf.Lerp(1, 0, time);
            Login.color = color;
            yield return null;
        }

        Login.gameObject.SetActive(false);
        yield return null;
    }

}
