using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] GameObject cursorCanvas;

    void Start()
    {
        ActiveMouse(true, false, CursorLockMode.Locked);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(cursorCanvas.activeSelf == true)
            {
                ActiveMouse(false, true, CursorLockMode.None);
            }
            else
            {
                ActiveMouse(true, false, CursorLockMode.Locked);
            }
        }
    }

    public void ActiveMouse(bool active, bool state, CursorLockMode mode)
    {
        cursorCanvas.SetActive(active);
        Cursor.visible = state;
        Cursor.lockState = mode;
    }
}