using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetButton : MonoBehaviour
{
    [SerializeField] AudioClip safeAudioClip;
    [SerializeField] KeypadCameraDoor keypadCamera;

    Text alphabet;

    private void Start()
    {
        alphabet = GetComponent<Text>();
        safeAudioClip = AudioManager.Instance.GetAudioClip("Safe");
    }

    public void OnLeftButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        if (alphabet.text == "")
        {
            alphabet.text = "Z";

            return;
        }

        if (alphabet.text[0] <= 'A')
        {
            alphabet.text = "Z";
        }
        else
        {
            alphabet.text = ((char)(alphabet.text[0] - 1)).ToString();
        }
    }

    public void OnRightButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        if (alphabet.text == "")
        {
            alphabet.text = "A";

            return;
        }

        if (alphabet.text[0] >= 'Z')
        {
            alphabet.text = "A";
        }
        else
        {
            alphabet.text = ((char)(alphabet.text[0] + 1)).ToString();
        }
    }
}
