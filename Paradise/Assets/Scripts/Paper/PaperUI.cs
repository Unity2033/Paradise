using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperUI : MonoBehaviour
{
    public void ExitButton()
    {
        CursorManager.interactable = true;

        CursorManager.ActiveMouse(false, CursorLockMode.Locked);

        Destroy(gameObject);
    }
}
