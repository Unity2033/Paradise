using System.Collections;
using UnityEngine;

public class Door_OperatesOnlyOnce : Interaction
{
    protected float openTime = 0.5f;
    protected float openAngle = 90f;

    protected Quaternion initialRotation;
    protected Quaternion openRotation; // 자식 클래스에서 값을 할당

    [SerializeField] AudioClip openDoorAudio;
    [SerializeField] AudioClip closeDoorAudio;

    [SerializeField] Door_Handle handle;

    private void Awake()
    {
        initialRotation = transform.rotation;

        openRotation = Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y + openAngle, initialRotation.eulerAngles.z);
    }

    protected void Start()
    {
        handle = transform.Find("Door_Handle").gameObject.GetComponent<Door_Handle>();
    }

    public override void OnClick(Collider door)
    {
        door.enabled = false;

        StartCoroutine(OpenDoor(door));
    }

    private IEnumerator OpenDoor(Collider door)
    {
        if (openDoorAudio == null)
        {
            openDoorAudio = AudioManager.Instance.GetAudioClip("Open Door");
        }

        yield return StartCoroutine(handle.OpenHandling());

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

        door.gameObject.layer = 0;

        Destroy(this);
    }
}
