using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum SceneID
{
    TITLE,
    GAME,
}

public class SceneryManager : Singleton<SceneryManager>
{
    [SerializeField] Image sceneImage;

    public IEnumerator FadeIn()
    {
        Color color = sceneImage.color;

        color.a = 1;

        sceneImage.gameObject.SetActive(true);

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            sceneImage.color = color;

            yield return null;
        }

        sceneImage.gameObject.SetActive(false);
    }

    public IEnumerator AsyncLoad(SceneID sceneID)
    {
        sceneImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneID);

        asyncOperation.allowSceneActivation = false;

        Color color = sceneImage.color;

        color.a = 0;

        while (asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            sceneImage.color = color;

            if (asyncOperation.progress >= 0.9f)
            {
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime);

                sceneImage.color = color;

                if (color.a >= 1.0f)
                {
                    asyncOperation.allowSceneActivation = true;

                    yield break;
                }
            }

            yield return null;
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FadeIn());
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
