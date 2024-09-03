using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadInteractor : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Text text;

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

    protected string password;

    private void Awake()
    {
        keyAudio = Resources.Load<AudioClip>("KeyClickAudio");
        successAudio = Resources.Load<AudioClip>("Clear");
        failAudio = Resources.Load<AudioClip>("KeypadFailAudio");

        keypadCamera = GetComponent<Camera>();

        color = image.color;
    }

    void Update()
    {
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
        image.color = color;
    }

    void DestroyThis()
    {
        Destroy(this);
    }

    void Succeed()
    {
        AudioManager.Instance.Sound(successAudio);

        image.color = Color.green;

        Invoke("DestroyThis", 0.25f);
    }

    void Fail()
    {
        AudioManager.Instance.Sound(failAudio);

        image.color = Color.red;

        text.text = "";

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

        StartCoroutine(ReleaseTheKey(key, pressPosition, initialPosition));
    }

    IEnumerator ReleaseTheKey(Transform key, Vector3 pressPosition, Vector3 initialPosition)
    {
        time = 0f;

        while (time < pressTime)
        {
            key.localPosition = Vector3.Lerp(pressPosition, initialPosition, time / pressTime);

            time += Time.deltaTime;

            yield return null;
        }

        key.localPosition = initialPosition;
    }
}
