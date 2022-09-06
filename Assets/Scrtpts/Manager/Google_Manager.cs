using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using System.Collections;

public class Google_Manager : MonoBehaviour
{
    [SerializeField] Image Internet;
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

    IEnumerator Connection()
    {
        yield return null;

        int count = 3;

        while(true)
        {
            yield return null;

            if(Social.localUser.authenticated)
            {
                break;
            }
            else
            {
                count--;
                Social.localUser.Authenticate(AuthenticateCallback);
                yield return new WaitForSeconds(1.0f);
            }

            // 3번 로그인 시도 후에 로그인 되지 않으면 강제 종료
            if(count < 0)
            {
                // Text로 로그인 실패를 알린 후 Application.Quit(); 발동
                Internet.gameObject.SetActive(true);
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
