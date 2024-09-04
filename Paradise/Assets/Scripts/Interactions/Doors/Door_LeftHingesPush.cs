using UnityEngine;

public class Door_LeftHingesPush : Door_OperatesOnlyOnce
{
    new private void Start()
    {
       base.Start();

       openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y - openAngle, initialRotation.eulerAngles.z);
    }
}
