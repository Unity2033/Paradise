using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodPopUp : MonoBehaviour
{
    [SerializeField] AudioClip closePopUpAudioClip;

    private void Start()
    {
        closePopUpAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    public void Exit()
    {
        AudioManager.Instance.Sound(closePopUpAudioClip);

        gameObject.SetActive(false);
    }
}
