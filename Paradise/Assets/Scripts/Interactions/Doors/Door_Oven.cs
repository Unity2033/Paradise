using System.Collections;
using UnityEngine;

public class Door_Oven : Door
{
    [SerializeField] public GameObject cakes;

    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x + openAngle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
    }

    public override void OnClick(Collider door)
    {
        door.enabled = false;

        if (isOpen) StartCoroutine(CloseDoor(door));
        else StartCoroutine(OpenDoor(door));

        isOpen = !isOpen;
    }

    new private IEnumerator OpenDoor(Collider door)
    {
        yield return StartCoroutine(base.OpenDoor(door));

        if (cakes != null && transform.parent.Find("Oven Button").GetComponent<Oven>().isFire == true) cakes.layer = 8;
    }

    new private IEnumerator CloseDoor(Collider door)
    {
        if (cakes != null) cakes.layer = 0;

        StartCoroutine(base.CloseDoor(door));

        yield return null;
    }
}
