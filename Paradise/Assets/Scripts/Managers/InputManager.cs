using System;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action keyAction;

    private void Update()
    {
        if (Input.anyKey == false)
        {
            return;
        }

        if (keyAction != null)
        {
            keyAction.Invoke();
        }
    }
}