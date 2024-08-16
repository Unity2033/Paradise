using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] float mouseSpeed;

    private float mouseX;
    private float mouseY;

    private void Update()
    {
        if (GameManager.Instance.State == false) return;

        mouseX += Input.GetAxisRaw("Mouse X") * mouseSpeed;
        mouseY += Input.GetAxisRaw("Mouse Y") * mouseSpeed;

        mouseY = Mathf.Clamp(mouseY, -60, 60);

        this.transform.localEulerAngles = new Vector3(-mouseY, 0, 0);

        transform.parent.localEulerAngles = new Vector3(0, mouseX, 0);
    }

}