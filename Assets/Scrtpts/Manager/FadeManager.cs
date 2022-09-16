using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    [SerializeField] Image sceneImage;

    private void Awake()
    {
        StartCoroutine(FadeIn(1));
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
