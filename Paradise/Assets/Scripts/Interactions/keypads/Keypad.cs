using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Interaction
{
    [SerializeField] GameObject keypadCamera;
    [SerializeField] GameObject mainCamera;

    [SerializeField] GameObject door;

    [SerializeField] Image screen;

    Color color = new Color(0, 0, 0);
    float alpha;

    float time = 0f;
    public float fadeTime = 0.3f;

    KeypadInteractor keypadInteractor;
    BoxCollider keypadCollider;

    private void Start()
    {
        keypadCamera = transform.Find("Camera").gameObject;
        mainCamera = Camera.main.gameObject;

        keypadInteractor = keypadCamera.GetComponent<KeypadInteractor>();
        keypadCollider = gameObject.GetComponent<BoxCollider>();
    }

    public override void OnClick(Collider keypad)
    {  
        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        GameManager.Instance.State = false;

        keypadCollider.enabled = false;

        StartCoroutine(FadeScreen());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && keypadCamera.activeSelf)
        {
            keypadCollider.enabled = true;

            StartCoroutine(FadeScreen());
        }
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

        if (mainCamera.activeSelf)
        {
            mainCamera.SetActive(false);

            keypadCamera.SetActive(true);
        }
        else
        {
            mainCamera.SetActive(true);

            if (keypadInteractor == null)
            {
                Destroy(keypadCamera);

                gameObject.layer = 0;
            }
            else keypadCamera.SetActive(false);

            CursorManager.interactable = true;

            CursorManager.ActiveMouse(false, CursorLockMode.Locked);

            GameManager.Instance.State = true;
        }

        StartCoroutine(ConventionalScreen());
    }

    private IEnumerator ConventionalScreen()
    {
        time = 0f;

        while (time < fadeTime)
        {
            time += Time.deltaTime;

            alpha = Mathf.Lerp(1f, 0f, time / fadeTime);

            color.a = alpha;

            screen.color = color;

            yield return null;
        }

        color.a = 1;

        screen.gameObject.SetActive(false);

        screen.color = color;

        if (keypadCamera == null)
        {
            door.layer = 8;

            Destroy(this);
        }
    }
}
