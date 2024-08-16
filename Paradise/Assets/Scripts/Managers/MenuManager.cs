using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] string [] buttonNames;
    [SerializeField] SelectButton [] buttons;

    [SerializeField] GameObject character;

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
        AudioManager.Instance.Sound(audioClip);
    }

    public void Game()
    {
        GameManager.Instance.State = true;

        StartCoroutine(FadeManager.Instance.FadeIn());

        AudioManager.Instance.Scenery(null);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);
    }
}
