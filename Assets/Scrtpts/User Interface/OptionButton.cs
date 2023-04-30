using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class OptionButton : CreateButton
{
    private int count = 2;
    private bool power = true;

    private void Start()
    {
        button[0].GetComponent<Button>().onClick.AddListener(Function1);
        button[1].GetComponent<Button>().onClick.AddListener(Function2);
        button[2].GetComponent<Button>().onClick.AddListener(Function3);
    }

    public override void Function1()
    {
        power = !power;

        AudioListener.volume = Convert.ToInt32(power);
    }

    public override void Function2()
    {
        SoundManager.Instance.Sound(SoundType.Select);

        if (++count >= 4)
        {
            count = 0;
        }

        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[count];
    }

    public override void Function3()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
