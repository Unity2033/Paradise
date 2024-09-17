using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFrontOnTheSafe : DoorLeftHingesPull
{
    [SerializeField] GameObject keypad;

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

        keypad.layer = 7;
    }

    new private IEnumerator CloseDoor(Collider door)
    {
        keypad.layer = 0;

        StartCoroutine(base.CloseDoor(door)); 

        yield return null;
    }
}
