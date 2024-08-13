using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortDrawer : Interaction
{
    [SerializeField] GameObject drawer;
    [SerializeField] bool isOpen = false;

    float openPositionZ = 0.5f;
    float openTime = 0.2f;

    Vector3 initialPosition;
    Vector3 openPosition;

    Vector3 colliderInitialPosition;
    Vector3 colliderOpenPosition;

    private void Start()
    {
        initialPosition = drawer.transform.position;
        openPosition = drawer.transform.TransformPoint(new Vector3(0, 0, openPositionZ));

        colliderInitialPosition = transform.position;
        colliderOpenPosition = transform.TransformPoint(new Vector3(0, 0, openPositionZ / 3f));
    }

    public override void OnClick(RaycastHit door)
    {
        door.collider.enabled = false;

        if (isOpen) StartCoroutine(PushDoor(door.collider));
        else StartCoroutine(PullDoor(door.collider));

        isOpen = !isOpen;
    }

    private IEnumerator PullDoor(Collider door)
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            drawer.transform.position = Vector3.Lerp(initialPosition, openPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        drawer.transform.position = openPosition;

        transform.position = colliderOpenPosition;

        door.enabled = true;
    }

    private IEnumerator PushDoor(Collider door)
    {
        float initialTime = 0f;

        while (initialTime < openTime)
        {
            drawer.transform.position = Vector3.Lerp(openPosition, initialPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        drawer.transform.position = initialPosition;

        transform.position = colliderInitialPosition;

        door.enabled = true;
    }
}
