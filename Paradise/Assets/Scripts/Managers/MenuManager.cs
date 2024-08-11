using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] AudioClip audioClip;
    [SerializeField] string [] buttonNames;
    [SerializeField] SelectButton [] buttons; 

    void Start()
    {
        for(int i = 0; i < buttonNames.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = buttonNames[i];
        }
    }

    public void Excute()
    {
        AudioManager.Instance.Sound(audioClip);

        StartCoroutine(SceneryManager.Instance.AsyncLoad(SceneID.GAME));
    }

    public void Continue()
    {
        AudioManager.Instance.Sound(audioClip);
    }

    public void Manual()
    {
        AudioManager.Instance.Sound(audioClip);
    }
}
