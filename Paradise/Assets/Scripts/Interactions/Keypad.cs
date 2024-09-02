using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Interaction
{
    [SerializeField] GameObject keypadCamera;
    [SerializeField] GameObject mainCamera;

    [SerializeField] Image screen;

    Color color = new Color(0, 0, 0);
    float alpha;

    float time = 0f;
    public float fadeTime = 0.3f;

    private void Start()
    {
        keypadCamera = transform.Find("Camera").gameObject;
        mainCamera = Camera.main.gameObject;
    }

    public override void OnClick(Collider keypad)
    {
        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        GameManager.Instance.State = false;

        StartCoroutine(FadeScreen());
    }

    private IEnumerator FadeScreen()
    {
        time = 0f;

        color.a = 0f;

        screen.color = color;

        screen.gameObject.SetActive(true);

        while (time < fadeTime)
        {
            time += Time.deltaTime;

            alpha = Mathf.Lerp(0f, 1f, time / fadeTime);

            color.a = alpha;

            screen.color = color;

            yield return null;
        }

        mainCamera.SetActive(false);

        keypadCamera.SetActive(true);

        StartCoroutine(ConventionalScreen());
    }

    private IEnumerator ConventionalScreen()
    {
        while (time > 0f)
        {
            time -= Time.deltaTime;

            alpha = Mathf.Lerp(1f, 0f, time / fadeTime);

            color.a = alpha;

            screen.color = color;

            yield return null;
        }

        color.a = 1;

        screen.gameObject.SetActive(false);

        screen.color = color;
    }
}
