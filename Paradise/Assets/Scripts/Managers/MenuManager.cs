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

    [SerializeField] GameObject methodPopUp;

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

        GameManager.Instance.State = true;

        StartCoroutine(FadeManager.Instance.FadeIn());

        AudioManager.Instance.Scenery(null);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);
    }

    public void Manual()
    {
        AudioManager.Instance.Sound(audioClip);

        methodPopUp.SetActive(true);
    }

    public void Exit()
    {
        AudioManager.Instance.Sound(audioClip);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
