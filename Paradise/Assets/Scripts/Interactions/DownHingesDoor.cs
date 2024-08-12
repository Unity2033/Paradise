using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownHingesDoor : Interaction
{
    [SerializeField] bool isOpen = false;

    float openAngle = 90.0f;
    float openTime = 0.5f;

    Quaternion initialRotation;
    Quaternion openRotation;

    Coroutine routine = null;

    private void Start()
    {
        initialRotation = transform.rotation;
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x + openAngle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
    }

    public override void OnClick(RaycastHit door)
    {
        if (routine != null) return;

        if (isOpen) routine = StartCoroutine(CloseDoor());
        else routine = StartCoroutine(OpenDoor());

        isOpen = !isOpen;
    }

    private IEnumerator OpenDoor()
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, openRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.rotation = openRotation;

        routine = null;
    }

    private IEnumerator CloseDoor()
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(openRotation, initialRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.rotation = initialRotation;

        routine = null;
    }
}
