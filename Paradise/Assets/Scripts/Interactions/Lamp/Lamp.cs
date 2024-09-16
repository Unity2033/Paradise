using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : Interaction
{
    [SerializeField] GameObject lampCamera;

    private void Start()
    {
        lampCamera = transform.Find("Lamp Camera").gameObject;
    }

    public override void OnClick(Collider lamp)
    {
        GameManager.Instance.State = false;

        StartCoroutine(FadeManager.Instance.SwitchCamera(lampCamera, Camera.main.gameObject));
    }
}
