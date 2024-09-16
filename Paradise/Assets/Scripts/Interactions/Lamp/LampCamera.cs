using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampCamera : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main.gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(FadeManager.Instance.SwitchCamera(mainCamera, gameObject));

            GameManager.Instance.State = true;
        }
    }
}
