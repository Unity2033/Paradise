using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CabinetPassword : Interaction
{
    [SerializeField] GameObject backGroundUI;
    [SerializeField] GameObject cabinetPasswordUI;

    public override void OnClick(Collider cabinetPassword)
    {
        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        GameManager.Instance.State = false;

        backGroundUI.SetActive(true);
        cabinetPasswordUI.SetActive(true);
        backGroundUI.transform.Find("ExitButton").GetComponent<Button>()
            .onClick.AddListener(cabinetPasswordUI.GetComponent<CabinetPasswordUI>().ExitButton);
    }
}
