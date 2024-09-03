using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DoorPassword : Interaction
{
    [SerializeField] GameObject backGroundUI;
    [SerializeField] GameObject doorPasswordUI;

    public override void OnClick(Collider doorPassword)
    {
        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        GameManager.Instance.State = false;

        backGroundUI.SetActive(true);
        doorPasswordUI.SetActive(true);
        backGroundUI.transform.Find("ExitButton").GetComponent<Button>()
            .onClick.AddListener(doorPasswordUI.GetComponent<DoorPasswordUI>().ExitButton);
    }
}
