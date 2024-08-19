using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetPassword : Interaction
{
    [SerializeField] GameObject cabinetPasswordUI;

    public override void OnClick(Collider cabinetPassword)
    {

        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        cabinetPasswordUI.SetActive(true);
    }
}
