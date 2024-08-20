using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperUI : MonoBehaviour
{
    [SerializeField] AudioClip closePopUpAudioClip;

    private void Start()
    {
        closePopUpAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    public void ExitButton()
    {
        AudioManager.Instance.Sound(closePopUpAudioClip);

        GameManager.Instance.State = true;

        CursorManager.interactable = true;

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        Destroy(gameObject);
    }
}
