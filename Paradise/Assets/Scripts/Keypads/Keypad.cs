using UnityEngine;

public class Keypad : Interaction
{
    [SerializeField] GameObject keypadUI;

    public override void OnClick(Collider keypad)
    {
        GameManager.Instance.State = false;

        CursorManager.interactable = false;

        CursorManager.ActiveMouse(true, CursorLockMode.None);

        keypadUI.SetActive(true);
    }
}
