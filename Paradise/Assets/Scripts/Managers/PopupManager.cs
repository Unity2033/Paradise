using UnityEngine;
using UnityEngine.UI;

public class PopupManager : Interaction
{
    [SerializeField] GameObject backGroundUI;
    [SerializeField] GameObject popUpUI;

    private GameObject backGroundObj;
    private GameObject popUpObj;
    private Button exitButton;

    [SerializeField] AudioClip interactionAudio;

    private void Start()
    {
        interactionAudio = Resources.Load<AudioClip>("Close PopUp");
    }

    public override void OnClick(Collider popUpObject)
    {
        backGroundObj = Instantiate(backGroundUI);
        backGroundObj.transform.Find("BackGround").gameObject.SetActive(true);

        exitButton = backGroundObj.transform.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(ExitButton);

        popUpObj = Instantiate(popUpUI, backGroundObj.transform);    // ¿ÀºêÁ§Æ®¸¦ Äµ¹ö½º ÇÏÀ§ Á© ¹Ø¿¡ »ý¼º

        CursorChange(false, true, CursorLockMode.None);
        GameManager.Instance.State = false;
    }

    public void ExitButton()
    {
        AudioManager.Instance.Sound(interactionAudio);

        Destroy(backGroundObj);
        Destroy(popUpObj);

        CursorChange(true, false, CursorLockMode.Locked);
        GameManager.Instance.State = true;
    }

    private void CursorChange(bool interactable, bool visible, CursorLockMode lockMode)
    {
        CursorManager.ActiveMouse(visible, lockMode);

        CursorManager.interactable = interactable;
    }
}
