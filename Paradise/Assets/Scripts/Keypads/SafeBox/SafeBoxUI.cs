using UnityEngine;
using UnityEngine.UI;

public class SafeBoxUI : MonoBehaviour
{
    [SerializeField] bool unlocked = false;

    [SerializeField] Image[] redLights;
    [SerializeField] Image[] greenLights;

    [SerializeField] Text[] password;

    string unlockPassword = "1478";

    [SerializeField] AudioClip clearAudioClip;
    [SerializeField] AudioClip closePopUpAudioClip;

    private void Start()
    {
        clearAudioClip = Resources.Load<AudioClip>("Clear");
        closePopUpAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    private void Update()
    {
        if (unlocked == false) Success();
        else Fail();
    }

    private void Success()
    {
        for (int i = 0; i < unlockPassword.Length; i++)
        {
            if (unlockPassword[i] != password[i].text[0]) return;
        }

        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].color = Color.black;
            greenLights[i].color = Color.green;
        }

        unlocked = true;

        AudioManager.Instance.Sound(clearAudioClip);
    }

    private void Fail()
    {
        for (int i = 0; i < unlockPassword.Length; i++)
        {
            if (unlockPassword[i] != password[i].text[0])
            {
                unlocked = false;

                for (int j = 0; j < redLights.Length; j++)
                {
                    redLights[j].color = Color.red;
                    greenLights[j].color = Color.black;
                }

                return;
            }
        }
    }

    public void ExitButton()
    {
        if (unlocked == false) gameObject.SetActive(false);
        else Destroy(gameObject);

        AudioManager.Instance.Sound(closePopUpAudioClip);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        CursorManager.interactable = true;

        GameManager.Instance.State = true;
    }
}
