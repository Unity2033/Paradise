using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadCameraDoor : MonoBehaviour
{
    [SerializeField] bool success = false;

    [SerializeField] Image redLight;
    [SerializeField] Image greenLight;

    [SerializeField] Text[] alphabets;

    [SerializeField] AudioClip clearAudioClip;

    [SerializeField] GameObject door;
    GameObject mainCamera;

    string password = "MLFX";

    private void Awake()
    {
        clearAudioClip = Resources.Load<AudioClip>("Clear");

        mainCamera = Camera.main.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(FadeManager.Instance.SwitchCamera(mainCamera, gameObject));

            GameManager.Instance.State = true;

            CursorManager.ActiveMouse(false, CursorLockMode.Locked);
        }

        if (Input.GetMouseButtonUp(0)) AnswerCheck();
    }

    private void AnswerCheck()
    {
        for (int i = 0; i < password.Length; i++)
        {
            if (alphabets[i].text == "") return;

            if (password[i] != alphabets[i].text[0]) return;
        }

        Success();
    }

    public void Success()
    {
        if (success == true) return; 

        success = true;

        redLight.color = Color.black;
        greenLight.color = Color.green;

        AudioManager.Instance.Sound(clearAudioClip);

        foreach(Text alphabet in alphabets)
        {
            Destroy(alphabet.GetComponent<AlphabetButton>());
        }

        transform.parent.gameObject.layer = 0;
        door.layer = 8;
    }

    void OnDisable()
    {
        if (success)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.parent.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
