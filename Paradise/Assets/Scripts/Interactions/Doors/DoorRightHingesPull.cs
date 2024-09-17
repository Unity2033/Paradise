using UnityEngine;

public class DoorRightHingesPull : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y - openAngle, initialRotation.eulerAngles.z);
    }

}
