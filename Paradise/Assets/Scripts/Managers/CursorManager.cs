using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static bool interactable = true;

    public static void ActiveMouse(bool visible, CursorLockMode lockMode)
    {
        Cursor.lockState = lockMode;
        Cursor.visible = visible;
    }
}
