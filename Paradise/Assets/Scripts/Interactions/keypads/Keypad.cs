using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : Interaction
{
    [SerializeField] GameObject keypadCamera;

    private void Start()
    {
        if (keypadCamera == null) keypadCamera = transform.Find("Camera").gameObject;
    }

    public override void OnClick(Collider keypad)
    {
        CursorManager.ActiveMouse(true, CursorLockMode.None);

        GameManager.Instance.State = false;

        gameObject.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(FadeManager.Instance.SwitchCamera(keypadCamera, Camera.main.gameObject));
    }

}
