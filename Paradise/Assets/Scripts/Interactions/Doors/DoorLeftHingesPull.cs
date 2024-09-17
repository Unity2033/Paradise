using UnityEngine;

public class DoorLeftHingesPull : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y + openAngle, initialRotation.eulerAngles.z);
    }
}

