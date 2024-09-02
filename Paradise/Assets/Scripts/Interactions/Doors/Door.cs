using System.Collections;
using UnityEngine;

public class Door : Interaction
{
    [SerializeField] public bool isOpen = false;

    public override bool State
    {
        get { return isOpen; }
    }

    protected float openTime = 0.5f;
    protected float openAngle = 90f;
    
    protected Quaternion initialRotation;
    protected Quaternion openRotation; // 자식 클래스에서 값을 할당

    [SerializeField] AudioClip openDoorAudio;
    [SerializeField] AudioClip closeDoorAudio;

    [SerializeField] Door_Handle door_Handle;

    private void Awake()
    {
        door_Handle = GetComponentInChildren<Door_Handle>();

        initialRotation = transform.rotation;
    }

    public override void OnClick(Collider door)
    {
        door.enabled = false;

        if (isOpen) StartCoroutine(CloseDoor(door));
        else StartCoroutine(OpenDoor(door));

        isOpen = !isOpen;
    }

    private IEnumerator OpenDoor(Collider door)
    {
        if (openDoorAudio == null)
        {
            openDoorAudio = AudioManager.Instance.GetAudioClip("Open Door");
        }

        if (door_Handle) yield return StartCoroutine(door_Handle.OpenHandling());

        AudioManager.Instance.Sound(openDoorAudio);

        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, openRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.rotation = openRotation;

        door.enabled = true;
    }

    private IEnumerator CloseDoor(Collider door)
    {
        if(closeDoorAudio == null)
        {
            closeDoorAudio = AudioManager.Instance.GetAudioClip("Close Door");
        }

        float initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.rotation = Quaternion.Slerp(openRotation, initialRotation, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        AudioManager.Instance.Sound(closeDoorAudio);

        transform.rotation = initialRotation;

        door.enabled = true;
    }
}
