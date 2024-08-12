using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDrawer : Interaction
{
    [SerializeField] bool isOpen = false;

    float openPositionZ = 0.5f;
    float openTime = 0.2f;

    Vector3 initialPosition;
    Vector3 openPosition;

    Coroutine routine = null;

    private void Start()
    {
        initialPosition = transform.position;
        openPosition = transform.TransformPoint(new Vector3(0, 0, openPositionZ));
    }

    public override void OnClick(RaycastHit door)
    {
        if (routine != null) return;

        if (isOpen) routine = StartCoroutine(PushDoor());
        else routine = StartCoroutine(PullDoor());

        isOpen = !isOpen;
    }

    private IEnumerator PullDoor()
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.position = Vector3.Lerp(initialPosition, openPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.position = openPosition;

        routine = null;
    }

    private IEnumerator PushDoor()
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.position = Vector3.Lerp(openPosition, initialPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.position = initialPosition;

        routine = null;
    }
}
