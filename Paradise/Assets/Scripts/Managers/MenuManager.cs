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

    [SerializeField] UnityEvent unityEvent;

    [SerializeField] GameObject methodPopUp;

    private void Awake()
    { 
        for (int i = 0; i < buttonNames.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = buttonNames[i];
        }

        if (PlayerPrefs.HasKey("PositionX"))
        {
            buttons[1].gameObject.SetActive(true);
        }
        else
        {
            buttons[1].gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        audioClip = AudioManager.Instance.GetAudioClip("Menu Button");
    }

    public void Excute()
    {
        AudioManager.Instance.Sound(audioClip);

        if(unityEvent != null) unityEvent.Invoke();
        
        Game();
    }

    public void Continue()
    {
        AudioManager.Instance.Sound(audioClip);

        DataManager.Instance.Load();

        character.transform.position = DataManager.Instance.GetPosition();

        Game();
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

    public void Game()
    {
        GameManager.Instance.State = true;

        StartCoroutine(FadeManager.Instance.FadeIn());

        AudioManager.Instance.Scenery(null);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);
    }
}
