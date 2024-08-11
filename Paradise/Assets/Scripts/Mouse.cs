using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] GameObject mouseCanvas;

    void Start()
    {
        ActiveMouse(true, true, CursorLockMode.Locked);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (mouseCanvas.activeSelf == true)
            {
                ActiveMouse(false, true, CursorLockMode.None);
            }
            else
            {
                ActiveMouse(true, true, CursorLockMode.Locked);
            }
        }
    }

    public void ActiveMouse(bool active, bool state, CursorLockMode mode)
    {
        mouseCanvas.SetActive(active);
        Cursor.visible = state;
        Cursor.lockState = mode;
    }
}