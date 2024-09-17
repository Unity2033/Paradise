using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoorFrontOnTheMitts : DoorLeftHingesPull
{
    [SerializeField] GameObject mitts;

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

        mitts.layer = 8;
    }

    new private IEnumerator CloseDoor(Collider door)
    {
        mitts.layer = 0;

        StartCoroutine(base.CloseDoor(door));

        yield return null;
    }
}
