using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] string [] buttonNames;
    [SerializeField] SelectButton [] buttons;

    [SerializeField] GameObject character;

    [SerializeField] GameObject methodPopUp;

    [SerializeField] TextManager textManager;

    private void Awake()
    { 
        for (int i = 0; i < buttonNames.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = buttonNames[i];
        }
    }

    private void Start()
    {
        audioClip = AudioManager.Instance.GetAudioClip("Menu Button");
    }

    public void Continue()
    {
        buttons[0].GetComponentInChildren<Text>().text = "Continue";

        AudioManager.Instance.Sound(audioClip);

        StartCoroutine(FadeManager.Instance.FadeIn());

        if(textManager.BeforeStroyCheck == false)
        {
            StartCoroutine(textManager.Beforestory());
        }

        GameManager.Instance.State = true;

        AudioManager.Instance.Scenery(null);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);
    }

    public void Manual()
    {
        methodPopUp.SetActive(true);

        AudioManager.Instance.Sound(audioClip);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
