using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberButton : MonoBehaviour
{
    [SerializeField] Text number;
    [SerializeField] AudioClip safeAudioClip;

    Text numberUI;

    private void Start()
    {
        numberUI = GetComponent<Text>();
        safeAudioClip = AudioManager.Instance.GetAudioClip("Safe");
    }

    public void OnUpButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        numberUI.text = ((int.Parse(numberUI.text) + 1) % 10).ToString();

        number.text = numberUI.text;
    }

    public void OnDownButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        numberUI.text = ((int.Parse(numberUI.text) + 9) % 10).ToString();

        number.text = numberUI.text;
    }
}
