using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillow : Interaction
{
    float pullTime = 0.3f;
    float pullScale = 0.5f;

    [SerializeField] AudioClip pillowAudioClip;

    Vector3 initialPosition;
    Vector3 pullPosition;

    private void Start()
    {
        pillowAudioClip = Resources.Load<AudioClip>("Pillow");

        initialPosition = transform.position;
        pullPosition = transform.TransformPoint(new Vector3(-pullScale, 0, 0));
    }

    public override void OnClick(Collider pillow)
    {
        StartCoroutine(pullPillow());
    }

    private IEnumerator pullPillow()
    {
        AudioManager.Instance.Sound(pillowAudioClip);

        float initialTime = 0f;

        while (initialTime < pullTime)
        {
            transform.position = Vector3.Lerp(initialPosition, pullPosition, initialTime / pullTime);

            initialTime += Time.deltaTime;

            yield return null;
        }

        transform.position = pullPosition;

        Destroy(this);
    }

}
