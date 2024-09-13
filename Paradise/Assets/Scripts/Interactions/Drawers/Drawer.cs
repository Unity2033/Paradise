using System.Collections;
using UnityEngine;

public class Drawer : Interaction
{
    [SerializeField] protected bool isOpen = false;

    public override bool State
    {
        get { return isOpen; }
    }

    float initialTime;
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
        gameObject.layer = 0;

        if (isOpen) StartCoroutine(CloseDrawer());
        else StartCoroutine(OpenDrawer());

        isOpen = !isOpen;
    }

    private IEnumerator OpenDrawer()
    {
        AudioManager.Instance.Sound(openDrawerAudio);

        initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.position = Vector3.Lerp(initialPosition, openPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.position = openPosition;

        gameObject.layer = 8;
    }

    private IEnumerator CloseDrawer()
    {
        initialTime = 0f;

        while (initialTime < openTime)
        {
            transform.position = Vector3.Lerp(openPosition, initialPosition, initialTime / openTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        AudioManager.Instance.Sound(closeDrawerAudio);

        transform.position = initialPosition;

        gameObject.layer = 8;
    }
}
