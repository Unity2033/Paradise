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

    char[] uiNumbers = { '4', '2', '5' };

    private void Update()
    {
        if (success == false) Success();
        else Fail();
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

        cabinetDoor.layer = 8;
    }

    private void Fail()
    {
        for (int i = 0; i < uiNumbers.Length; i++)
        {
            if (uiNumbers[i] != cabinetNumbers[i].text[0]) success = false;
        }

        if (success == true) return;

        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].color = Color.red;
            greenLights[i].color = Color.black;
        }

        cabinetDoor.layer = 0;
    }

    public void ExitButton()
    {
        if (success == false) gameObject.SetActive(false);
        else
        {
            cabinetPassword.layer = 0;

            Destroy(gameObject);
        }
        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        CursorManager.interactable = true;

    }
}
