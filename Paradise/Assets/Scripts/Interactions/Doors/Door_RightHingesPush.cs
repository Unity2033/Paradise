using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_RightHingesPush : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y + openAngle, initialRotation.eulerAngles.z);
    }
}
