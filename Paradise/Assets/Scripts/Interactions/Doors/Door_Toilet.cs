using UnityEngine;

public class Toilet : Door
{
    private void Start()
    {
        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x + openAngle, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z);
    }
}
