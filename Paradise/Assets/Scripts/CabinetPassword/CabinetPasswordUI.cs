using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetPasswordUI : MonoBehaviour
{
    [SerializeField] bool success = false;

    [SerializeField] Image[] redLights;
    [SerializeField] Image[] greenLights;

    [SerializeField] Text[] cabinetNumbers;

    [SerializeField] GameObject cabinetDoor;
    [SerializeField] GameObject cabinetPassword;

    [SerializeField] AudioClip clearAudioClip;
    [SerializeField] AudioClip closePopUpAudioClip;

    char[] uiNumbers = { '4', '2', '5' };

    private void Start()
    {
        clearAudioClip = Resources.Load<AudioClip>("Clear");
        closePopUpAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    private void Update()
    {
        if (success == false) Success();
    }

    private void Success()
    {
        for (int i = 0; i < uiNumbers.Length; i++)
        {
            if (uiNumbers[i] != cabinetNumbers[i].text[0]) return;
        }

        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].color = Color.black;
            greenLights[i].color = Color.green;
        }

        success = true;

        for (int i = 0; i < cabinetNumbers.Length; i++)
        {
            Destroy(cabinetNumbers[i].GetComponent<NumberButton>());
        }

        cabinetDoor.layer = 8;

        AudioManager.Instance.Sound(clearAudioClip);
    }

    public void ExitButton()
    {
        transform.parent.GetChild(0).gameObject.SetActive(false);
        transform.parent.GetChild(0).transform.Find("ExitButton").GetComponent<Button>().onClick.RemoveAllListeners();

        if (success == false) gameObject.SetActive(false);
        else
        {
            cabinetPassword.layer = 0;

            Destroy(gameObject);
        }

        GameManager.Instance.State = true;

        AudioManager.Instance.Sound(closePopUpAudioClip);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        CursorManager.interactable = true;
    }
}
