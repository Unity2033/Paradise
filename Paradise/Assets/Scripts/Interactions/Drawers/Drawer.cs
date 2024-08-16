using System.Collections;
using UnityEngine;

public class Drawer : Interaction
{
    [SerializeField] protected GameObject drawer;

    protected float openScale; // 자식 클래스에서 값을 할당

    protected Vector3 initialPosition;
    protected Vector3 colliderInitialPosition;

    protected Vector3 openPosition;
    protected Vector3 colliderOpenPosition;

    [SerializeField] AudioClip openDrawerAudio;
    [SerializeField] AudioClip closeDrawerAudio;


    private void Start()
    {
        openDrawerAudio = AudioManager.Instance.GetAudioClip("Oepn Drawer");
        closeDrawerAudio = AudioManager.Instance.GetAudioClip("Close Drawer");

        openTime = 0.2f;

        initialPosition = drawer.transform.position;
        colliderInitialPosition = transform.position;

        openPosition = drawer.transform.TransformPoint(new Vector3(0, 0, openScale));
        colliderOpenPosition = transform.TransformPoint(new Vector3(0, 0, openScale / 3f));
    }

    public override void OnClick(Collider drawerCollider)
    {
        drawerCollider.enabled = false;

        if (isOpen) StartCoroutine(PushDoor(drawerCollider));
        else StartCoroutine(PullDoor(drawerCollider));

        isOpen = !isOpen;
    }

    private IEnumerator PullDoor(Collider drawerCollider)
    {
        AudioManager.Instance.Sound(openDrawerAudio);

        float initialTime = 0f;

        while (initialTime < openTime)
        {
            drawer.transform.position = Vector3.Lerp(initialPosition, openPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        drawer.transform.position = openPosition;

        transform.position = colliderOpenPosition;

        drawerCollider.enabled = true;
    }

    private IEnumerator PushDoor(Collider drawerCollider)
    {
        AudioManager.Instance.Sound(closeDrawerAudio);


        float initialTime = 0f;

        while (initialTime < openTime)
        {
            drawer.transform.position = Vector3.Lerp(openPosition, initialPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        drawer.transform.position = initialPosition;

        transform.position = colliderInitialPosition;

        drawerCollider.enabled = true;
    }
}
