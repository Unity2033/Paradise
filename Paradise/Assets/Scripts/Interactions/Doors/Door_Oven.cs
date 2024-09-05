using UnityEngine;

public class Door_Oven : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x + openAngle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
    }
}
