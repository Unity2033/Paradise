using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;


public class OptionButton : MonoBehaviour
{
    private int count = 2;
    private bool power = true;

    public void Function1()
    {
        power = !power;

        AudioListener.volume = Convert.ToInt32(power);
    }

    public void Function2()
    {
        SoundManager.Instance.Sound(SoundType.Select);

        if (++count >= 4)
        {
            count = 0;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[count];
    }

    public void Function3()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
