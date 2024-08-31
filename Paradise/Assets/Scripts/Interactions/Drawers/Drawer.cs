using System.Collections;
using UnityEngine;

public class Drawer : Interaction
{
    [SerializeField] protected bool isOpen = false;

    public override bool State
    {
        get { return isOpen; }
    }

    protected float openTime = 0.2f;
    protected float openScale; // 자식 클래스에서 값을 할당

    protected Vector3 initialPosition;
    protected Vector3 openPosition;

    [SerializeField] AudioClip openDrawerAudio;
    [SerializeField] AudioClip closeDrawerAudio;

    private void Start()
    {
        openDrawerAudio = AudioManager.Instance.GetAudioClip("Oepn Drawer");
        closeDrawerAudio = AudioManager.Instance.GetAudioClip("Close Drawer");

        initialPosition = transform.position;

        openPosition = transform.TransformPoint(new Vector3(0, 0, openScale));
    }

    public override void OnClick(Collider drawer)
    {
        drawer.enabled = false;

        if (isOpen) StartCoroutine(PushDoor(drawer));
        else StartCoroutine(PullDoor(drawer));

        isOpen = !isOpen;
    }

    private IEnumerator PullDoor(Collider drawer)
    {
        AudioManager.Instance.Sound(openDrawerAudio);

        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.position = Vector3.Lerp(initialPosition, openPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.position = openPosition;

        drawer.enabled = true;
    }

    private IEnumerator PushDoor(Collider drawer)
    {
        AudioManager.Instance.Sound(closeDrawerAudio);

        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.position = Vector3.Lerp(openPosition, initialPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.position = initialPosition;

        drawer.enabled = true;
    }
}
