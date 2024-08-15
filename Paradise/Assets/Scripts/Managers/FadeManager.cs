using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : Singleton<FadeManager>
{
    [SerializeField] Image titleImage;
    [SerializeField] Image screenImage;

    public IEnumerator FadeIn()
    {
        titleImage.gameObject.SetActive(false);

        Color color = screenImage.color;

        color.a = 1;

        screenImage.gameObject.SetActive(true);

        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        screenImage.gameObject.SetActive(false);
    }

    public IEnumerator FadeOut()
    {
        Color color = screenImage.color;

        color.a = 0;

        screenImage.gameObject.SetActive(true);

        while (color.a <= 1.0f)
        {
            color.a += Time.deltaTime;

            screenImage.color = color;

            yield return null;
        }

        titleImage.gameObject.SetActive(true);
        screenImage.gameObject.SetActive(false);
    }
}
