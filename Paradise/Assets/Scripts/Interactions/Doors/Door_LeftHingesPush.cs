using UnityEngine;

public class Door_LeftHingesPush : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y - openAngle, initialRotation.eulerAngles.z);
    }
}
