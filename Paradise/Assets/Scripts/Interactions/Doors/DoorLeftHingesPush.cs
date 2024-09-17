using UnityEngine;

public class DoorLeftHingesPush : DoorOperatesOnlyOnce
{
    new private void Start()
    {
       base.Start();

       openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y - openAngle, initialRotation.eulerAngles.z);
    }
}
