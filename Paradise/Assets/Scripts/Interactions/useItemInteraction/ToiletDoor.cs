using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : Interaction
{
    [SerializeField] GameObject toiletDoor;

    string item = "Toliet Key";

    [SerializeField] GameObject key;

    [SerializeField] Animator animator;
    [SerializeField] AudioClip LockAudioClip;
    [SerializeField] AudioClip unLockAudioClip;

    private void Start()
    {
        LockAudioClip = AudioManager.Instance.GetAudioClip("Locked");
        unLockAudioClip = AudioManager.Instance.GetAudioClip("UnLocked");
    }

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.UseItem(item))
        {
            key.SetActive(true);

            AudioManager.Instance.Sound(unLockAudioClip);

            toiletDoor.layer = 8;

            Destroy(animator);
            Destroy(gameObject);
        }
        else
        {
            animator.Play("Toilet Door Handle");
            AudioManager.Instance.Sound(LockAudioClip);
        }
    }
}
