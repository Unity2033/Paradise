using UnityEngine;
using UnityEngine.UI;

public class SafeUI : MonoBehaviour
{
    [SerializeField] public bool success = false;

    [SerializeField] Image[] redLights;
    [SerializeField] Image[] greenLights;

    [SerializeField] Text[] safeNumbers;

    char[] uiNumbers = { '1', '4', '7', '8' };

    [SerializeField] AudioClip clearAudioClip;
    [SerializeField] AudioClip closePopUpAudioClip;

    private void Start()
    {
        clearAudioClip = Resources.Load<AudioClip>("Clear");
        closePopUpAudioClip = Resources.Load<AudioClip>("Close PopUp");
    }

    private void Update()
    {
        if (success == false) Success();
    }

    private void Success()
    {
        for (int i = 0; i < uiNumbers.Length; i++)
        {
            if (uiNumbers[i] != safeNumbers[i].text[0]) return;
        }

        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].color = Color.black;
            greenLights[i].color = Color.green;
        }

        success = true;

        for (int i = 0; i < uiNumbers.Length; i++)
        {
            Destroy(gameObject.GetComponentInChildren<NumberButton>());
        }

        AudioManager.Instance.Sound(clearAudioClip);
    }

    public void ExitButton()
    {
        transform.parent.GetChild(0).gameObject.SetActive(false);
        transform.parent.GetChild(0).transform.Find("ExitButton").GetComponent<Button>().onClick.RemoveAllListeners();

        if (success == false) gameObject.SetActive(false);
        else Destroy(gameObject);

        GameManager.Instance.State = true;

        AudioManager.Instance.Sound(closePopUpAudioClip);

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        CursorManager.interactable = true;
    }
}
