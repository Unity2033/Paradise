using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRightHingesPush : DoorOperatesOnlyOnce
{
    new private void Start()
    {
        base.Start();

        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y + openAngle, initialRotation.eulerAngles.z);
    }
}
