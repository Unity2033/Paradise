using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Interaction
{
    public override void OnClick(Collider paper)
    {
        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        Instantiate(Resources.Load<GameObject>("Paper UI"));
    }
}
