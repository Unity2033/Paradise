using System.Collections;
using UnityEngine;

public class Door : Interaction
{
    [SerializeField] Collider forwardCollider;
    [SerializeField] Collider backCollider;

    [SerializeField] bool isOpen = false;

    float openAngle = 90.0f;
    float openTime = 0.5f;

    Quaternion initialRotation;
    Quaternion traceRotation;

    Coroutine routine = null;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    public override void OnClick(RaycastHit door)
    {
        if (routine != null) return;

        if (isOpen) routine = StartCoroutine(CloseDoor());
        else
        {
            if (door.collider == forwardCollider)
            {
                routine = StartCoroutine(OpenDoor(initialRotation.eulerAngles.y + openAngle));
            }
            else
            {
                routine = StartCoroutine(OpenDoor(initialRotation.eulerAngles.y - openAngle));
            }
        }

        isOpen = !isOpen;
    }

    private IEnumerator OpenDoor(float y)
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, Quaternion.Euler(0, y, 0), initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        traceRotation = transform.rotation;

        routine = null;
    }
    
    private IEnumerator CloseDoor()
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(traceRotation, initialRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        routine = null;
    }
}
