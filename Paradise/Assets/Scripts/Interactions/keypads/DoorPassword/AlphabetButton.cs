using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetButton : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] AudioClip safeAudioClip;

    Text numberUI;

    private void Start()
    {
        numberUI = GetComponent<Text>();
        safeAudioClip = AudioManager.Instance.GetAudioClip("Safe");
    }

    public void OnLeftButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        if (numberUI.text[0] <= 'A')
        {
            numberUI.text = 'Z'.ToString();
        }
        else
        {
            numberUI.text = ((char)(numberUI.text[0] - 1)).ToString();
        }

        number.text = numberUI.text;
    }

    public void OnRightButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        if (numberUI.text[0] >= 'Z')
        {
            numberUI.text = 'A'.ToString();
        }
        else
        {
            numberUI.text = ((char)(numberUI.text[0] + 1)).ToString();
        }

        number.text = numberUI.text;
    }
}
