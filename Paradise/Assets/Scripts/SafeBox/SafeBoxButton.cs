using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeBoxButton : MonoBehaviour
{
    [SerializeField] Text safeNumber;
    [SerializeField] AudioClip safeAudioClip;

    Text safeNumberUI;

    private void Start()
    {
        safeNumberUI = GetComponent<Text>();
        safeAudioClip = AudioManager.Instance.GetAudioClip("Safe");
    }

    public void OnUpButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        safeNumberUI.text = ((int.Parse(safeNumberUI.text) + 1) % 10).ToString();

        safeNumber.text = safeNumberUI.text;
    }

    public void OnDownButton()
    {
        AudioManager.Instance.Sound(safeAudioClip);

        safeNumberUI.text = ((int.Parse(safeNumberUI.text) + 9) % 10).ToString();

        safeNumber.text = safeNumberUI.text;
    }
}
