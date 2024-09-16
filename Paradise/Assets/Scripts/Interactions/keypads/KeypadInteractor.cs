using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class KeypadInteractor : MonoBehaviour
{
    [SerializeField] bool success = false;

    [SerializeField] string password;

    [SerializeField] Image image;
    [SerializeField] Text text;

    [SerializeField] GameObject door;
    [SerializeField] GameObject mainCamera;
    [SerializeField] Camera keypadCamera;

    [SerializeField] AudioClip keyAudio;
    [SerializeField] AudioClip successAudio;
    [SerializeField] AudioClip failAudio;

    float distance = 1f;
    float pressTime = 0.1f;
    float time = 0f;

    Ray ray;
    RaycastHit hit;

    Color color;

    Vector3 initialPosition;
    Vector3 pressPosition;

    string Password 
    { 
        get { return password; } 
    }

    private void Awake()
    {
        keyAudio = Resources.Load<AudioClip>("KeyClickAudio");
        successAudio = Resources.Load<AudioClip>("Clear");
        failAudio = Resources.Load<AudioClip>("KeypadFailAudio");

        keypadCamera = GetComponent<Camera>();

        mainCamera = Camera.main.gameObject;

        color = image.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(FadeManager.Instance.SwitchCamera(mainCamera, gameObject));

            GameManager.Instance.State = true;

            CursorManager.ActiveMouse(false, CursorLockMode.Locked);

            CursorManager.interactable = true;
        }

        if (success == true) return;

        ray = keypadCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.CompareTag("Number"))
                {
                    keyPress(hit.collider.transform);
                    ToInput();
                }
                else if (hit.collider.gameObject.CompareTag("Enter"))
                {
                    keyPress(hit.collider.transform);

                    if (text.text == password) Succeed();
                    else Fail();
                }
            }
        }
    }

    void ChangeColor()
    {
        text.text = "";

        image.color = color;
    }

    void Succeed()
    {
        AudioManager.Instance.Sound(successAudio);

        image.color = Color.green;

        success = true;
    }

    void Fail()
    {
        AudioManager.Instance.Sound(failAudio);

        image.color = Color.red;

        Invoke("ChangeColor", 0.6f);
    }

    void ToInput()
    {
        if (text.text.Length < 6) text.text += hit.collider.gameObject.name;
    }

    void keyPress(Transform key)
    {
        AudioManager.Instance.Sound(keyAudio);

        StartCoroutine(PressTheKey(key));
    }

    IEnumerator PressTheKey(Transform key)
    {
        time = 0f;

        initialPosition = key.localPosition;
        pressPosition = initialPosition;
        pressPosition.z = 0;

        while (time < pressTime)
        {
            key.localPosition = Vector3.Lerp(initialPosition, pressPosition, time / pressTime);

            time += Time.deltaTime;

            yield return null;
        }

        while (time < pressTime)
        {
            key.localPosition = Vector3.Lerp(pressPosition, initialPosition, time / pressTime);

            time += Time.deltaTime;

            yield return null;
        }

        key.localPosition = initialPosition;
    }

    private void OnDisable()
    {
        if (success)
        {
            Destroy(transform.parent.GetComponent<BoxCollider>());

            door.layer = 8;
            transform.parent.gameObject.layer = 0;
            transform.parent.parent.gameObject.layer = 8;

            Destroy(gameObject);
        }

        transform.parent.GetComponent<BoxCollider>().enabled = true;
    }
}
