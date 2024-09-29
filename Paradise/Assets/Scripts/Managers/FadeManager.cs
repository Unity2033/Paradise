using System.Collections;
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

    public IEnumerator GameEnd()
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

        Application.Quit();
    }

    public IEnumerator SwitchCamera(GameObject onCamera, GameObject offCamera, float coefficient = 0.3f)
    {
        Color color = screenImage.color;

        color.a = 0;

        screenImage.gameObject.SetActive(true);

        while (color.a <= 1.0f)
        {
            color.a += Time.deltaTime / coefficient;

            screenImage.color = color;

            yield return null;
        }

        onCamera.SetActive(true);
        offCamera.SetActive(false);

        StartCoroutine(SubSwitchCamera(color, coefficient));
    }

    public IEnumerator SubSwitchCamera(Color color, float coefficient)
    {
        while (color.a >= 0.0f)
        {
            color.a -= Time.deltaTime / coefficient;

            screenImage.color = color;

            yield return null;
        }

        screenImage.gameObject.SetActive(false);
    }
}
