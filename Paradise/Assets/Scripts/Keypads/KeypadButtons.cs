using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadButtons : MonoBehaviour
{
    [SerializeField] Text password;
    [SerializeField] AudioClip safeAudioClip;

    Text passwordUI;

    KeypadUI keypadUI;

    private void Start()
    {
        passwordUI = GetComponent<Text>();
        safeAudioClip = AudioManager.Instance.GetAudioClip("Safe");
    }

    public void OnLeftButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        if (passwordUI.text[0] <= 'A')
        {
            passwordUI.text = 'Z'.ToString();
        }
        else
        {
            passwordUI.text = ((char)(passwordUI.text[0] - 1)).ToString();
        }

        password.text = passwordUI.text;
    }

    public void OnRightButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        if (passwordUI.text[0] >= 'Z')
        {
            passwordUI.text = 'A'.ToString();
        }
        else
        {
            passwordUI.text = ((char)(passwordUI.text[0] + 1)).ToString();
        }

        password.text = passwordUI.text;
    }

    public void OnUpButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        passwordUI.text = ((int.Parse(passwordUI.text) + 1) % 10).ToString();

        password.text = passwordUI.text;
    }

    public void OnDownButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        passwordUI.text = ((int.Parse(passwordUI.text) + 9) % 10).ToString();

        password.text = passwordUI.text;
    }
}
