using UnityEngine;
using UnityEngine.UI;

public class PlayPuzzle : Interaction
{
    [SerializeField] GameObject backGroundUI;
    [SerializeField] GameObject puzzleObject;

    private GameObject backGroundObj;
    private GameObject puzzleObj;
    private Button exitButton;

    [SerializeField] AudioClip interactionAudio;

    private void Start()
    {
        interactionAudio = Resources.Load<AudioClip>("Close PopUp");
    }

    public override void OnClick(Collider puzzle)

    {
        backGroundObj = Instantiate(backGroundUI);
        exitButton = backGroundObj.transform.Find("ExitButton").GetComponent<Button>();
        exitButton.onClick.AddListener(ExitButton);

        puzzleObj = Instantiate(puzzleObject);

        CursorChange(false, true, CursorLockMode.None);
        GameManager.Instance.State = false;
    }

    public void ExitButton()
    {
        AudioManager.Instance.Sound(interactionAudio);

        Destroy(backGroundObj);
        Destroy(puzzleObj);

        CursorChange(true, false, CursorLockMode.Locked);
        GameManager.Instance.State = true;
    }

    private void CursorChange(bool interactable, bool visible, CursorLockMode lockMode)
    {
        CursorManager.ActiveMouse(visible, lockMode);

        CursorManager.interactable = interactable;
    }
}
