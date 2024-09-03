using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPasswordUI : MonoBehaviour
{
    [SerializeField] bool success = false;

    [SerializeField] Image[] redLights;
    [SerializeField] Image[] greenLights;

    [SerializeField] Text[] doorNumbers;

    [SerializeField] GameObject door;
    [SerializeField] GameObject doorPassword;
    
    [SerializeField] AudioClip closeAudioClip;
    [SerializeField] AudioClip clearAudioClip;

    char[] uiNumbers = { 'K', 'L', 'E', 'Y' };

    private void Start()
    {
        clearAudioClip = Resources.Load<AudioClip>("Clear");
        closeAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    private void Update()
    {
        if (success == false) Success();
    }

    private void Success()
    {
        for (int i = 0; i < uiNumbers.Length; i++)
        {
            if (uiNumbers[i] != doorNumbers[i].text[0]) return;
        }

        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].color = Color.black;
            greenLights[i].color = Color.green;
        }

        success = true;

        for (int i = 0; i < doorNumbers.Length; i++)
        {
            Destroy(doorNumbers[i].GetComponent<AlphabetButton>());
        }

        door.layer = 8;
        doorPassword.layer = 0;

        AudioManager.Instance.Sound(clearAudioClip);
    }

    public void ExitButton()
    {
        transform.parent.GetChild(0).gameObject.SetActive(false);
        transform.parent.GetChild(0).transform.Find("ExitButton").GetComponent<Button>().onClick.RemoveAllListeners();

        if (success == false) gameObject.SetActive(false);
        else
        {
            doorPassword.layer = 0;

            Destroy(gameObject);
        }

        GameManager.Instance.State = true;

        AudioManager.Instance.Sound(closeAudioClip);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        CursorManager.interactable = true;
    }
}
