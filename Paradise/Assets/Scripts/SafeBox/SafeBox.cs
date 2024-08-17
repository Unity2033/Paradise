using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeBox : Interaction
{
    [SerializeField] protected bool isOpen = false;

    protected float openTime = 0.6f;

    [SerializeField] GameObject safeUI;
    [SerializeField] Transform safeDoor;
    [SerializeField] GameObject cabinetDoor;

    float openAngle = 95.0f;

    Quaternion initialRotation;
    Quaternion openRotation;

    Coroutine routine;

    private void Start()
    {
        initialRotation = safeDoor.rotation;

        openRotation = Quaternion.Euler(0, initialRotation.y + openAngle, 0);
    }

    public override void OnClick(Collider safe)
    {
        if (safeUI)
        {
            CursorManager.interactable = false;

            CursorManager.ActiveMouse(true, CursorLockMode.None);

            safeUI.SetActive(true);
        }
        else
        {
            if (routine != null) return;

            if (isOpen) routine = StartCoroutine(CloseDoor());
            else routine = StartCoroutine(OpenDoor());

            isOpen = !isOpen;
        }
    }

    private IEnumerator OpenDoor()
    {
        float initialTime = 0f;

        cabinetDoor.layer = 0;

        while (initialTime < openTime)
        {
            safeDoor.transform.rotation = Quaternion.Slerp(initialRotation, openRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        safeDoor.rotation = openRotation;

        routine = null;
    }

    private IEnumerator CloseDoor()
    {
        float initialTime = 0f;

        cabinetDoor.layer = 8;

        while (initialTime < openTime)
        {
            safeDoor.transform.rotation = Quaternion.Slerp(openRotation, initialRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        safeDoor.rotation = initialRotation;

        routine = null;
    }
}
