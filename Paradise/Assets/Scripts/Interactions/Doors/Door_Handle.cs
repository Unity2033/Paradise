using System.Collections;
using UnityEngine;

public class Door_Handle : MonoBehaviour
{ 
    [SerializeField] Quaternion initialRotation;
    [SerializeField] Quaternion openRotation;

    float openAngle = 45f;
    float openTime = 0.2f;
    float initialTime = 0;

    private void Start()
    {
        initialRotation = transform.localRotation;

        openRotation = Quaternion.Euler(initialRotation.x + openAngle, initialRotation.y, initialRotation.z);
    }

    public IEnumerator OpenHandling()
    {
        initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.localRotation = Quaternion.Slerp(initialRotation, openRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.localRotation = openRotation;

        yield return openTime / 4;

        StartCoroutine(CloseHandling());
    }

    public IEnumerator CloseHandling()
    {
        initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.localRotation = Quaternion.Slerp(openRotation, initialRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.localRotation = initialRotation;
    }
}
