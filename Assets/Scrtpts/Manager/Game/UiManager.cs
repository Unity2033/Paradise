using GooglePlayGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    private int count = 2;
    private bool power = true;

    public void GameStart()
    {
        SoundManager.Instance.Sound(3);

        GameManager.Instance.StateCanvas(GameManager.state.Progress);
    }

    public void SceneInitialization()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void SoundMute()
    {
        power = !power;

        switch (power)
        {
            case true:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound on");
                break;
            case false:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("Sound off");
                break;
        }

        AudioListener.volume = Convert.ToInt32(power);
    }

    public void Language()
    {
        SoundManager.Instance.Sound(4);

        if (++count >= 4)
        {
            count = 0;
        }
        
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[count];
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
