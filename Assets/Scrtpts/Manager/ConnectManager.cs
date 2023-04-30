using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using System.Collections;

public class ConnectManager : MonoBehaviour
{
    static int connectNumber = 0;
    [SerializeField] Image sceneImage;
    [SerializeField] Image connectionFailureImage;

    private void Awake()
    {
        PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().EnableSavedGames().Build());
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        if (connectNumber == 0)
        {
            StartCoroutine(Connection());
        }
    }

    void AuthenticateCallback(bool success)
    {
        if(success)
        {
            connectNumber++;
            StartCoroutine(FadeIn(1));
        }
        else 
        {
            sceneImage.gameObject.SetActive(true);
        }
    }

    private IEnumerator Connection()
    {
        WaitForSeconds chaceSeconds = new WaitForSeconds(1f);

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
                yield return chaceSeconds;
            }

            // 3번 로그인 시도 후에 로그인 되지 않으면 강제 종료
            if(count < 0)
            {
                // Text로 로그인 실패를 알린 후 Application.Quit(); 발동
                connectionFailureImage.gameObject.SetActive(true);
                break;
            }
        }
    }
    private IEnumerator FadeIn(float time)
    {
        Color color = sceneImage.color;
        color.a = 1;

        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / time;
            sceneImage.color = color;
            yield return null;
        }

        sceneImage.transform.root.gameObject.SetActive(false);
    }
}
