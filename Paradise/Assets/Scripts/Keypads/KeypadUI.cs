using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadUI : MonoBehaviour
{
    [SerializeField] bool unlocked = false;

    [SerializeField] Image[] redLights;
    [SerializeField] Image[] greenLights;

    [SerializeField] Text[] password;

    [SerializeField] GameObject unlockObject;
    [SerializeField] GameObject keypad;

    [SerializeField] AudioClip clearAudioClip;
    [SerializeField] AudioClip closePopUpAudioClip;

    protected string unlockPassword;

    private void Start()
    {
        clearAudioClip = Resources.Load<AudioClip>("Clear");
        closePopUpAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    private void Update()
    {
        if (unlocked == false) Success();
        else Fail();
    }

    private void Success()
    {
        for (int i = 0; i < unlockPassword.Length; i++)
        {
            if (unlockPassword[i] != password[i].text[0]) return;
        }

        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].color = Color.black;
            greenLights[i].color = Color.green;
        }

        unlocked = true;

        unlockObject.layer = 8;

        AudioManager.Instance.Sound(clearAudioClip);
    }

    private void Fail()
    {
        for (int i = 0; i < unlockPassword.Length; i++)
        {
            if (unlockPassword[i] != password[i].text[0])
            {
                unlocked = false;

                for (int j = 0; j < redLights.Length; j++)
                {
                    redLights[j].color = Color.red;
                    greenLights[j].color = Color.black;
                }

                unlockObject.layer = 0;

                return;
            }
        }
    }

    public void ExitButton()
    {
        if (unlocked == false) gameObject.SetActive(false);
        else
        {
            keypad.layer = 0;

            Destroy(gameObject);
        }

        AudioManager.Instance.Sound(closePopUpAudioClip);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        CursorManager.interactable = true;

        GameManager.Instance.State = true;
    }
}
