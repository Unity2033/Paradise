using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPassword : Interaction
{
    [SerializeField] GameObject doorPasswordUI;

    public override void OnClick(Collider doorPassword)
    {
        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        doorPasswordUI.SetActive(true);
    }
}
