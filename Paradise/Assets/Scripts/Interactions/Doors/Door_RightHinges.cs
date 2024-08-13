using UnityEngine;

public class Door_RightHinges : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y - openAngle, initialRotation.eulerAngles.z);
    }

}
