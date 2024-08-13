using System.Collections;
using UnityEngine;

public class Door : Interaction
{
    protected float openAngle = 90f;
    
    protected Quaternion initialRotation;
    protected Quaternion openRotation; // 자식 클래스에서 값을 할당

    private void Awake()
    {
        openTime = 0.5f;

        initialRotation = transform.rotation;
    }

    public override void OnClick(Collider door)
    {
        door.enabled = false;

        if (isOpen) StartCoroutine(CloseDoor(door));
        else StartCoroutine(OpenDoor(door));

        isOpen = !isOpen;
    }

    private IEnumerator OpenDoor(Collider door)
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, openRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.rotation = openRotation;

        door.enabled = true;
    }

    private IEnumerator CloseDoor(Collider door)
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(openRotation, initialRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.rotation = initialRotation;

        door.enabled = true;
    }
}
