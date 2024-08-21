using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : Interaction
{
    [SerializeField] GameObject toiletDoor;

    string item = "Toliet Key";

    [SerializeField] AudioClip LockAudioClip;
    [SerializeField] AudioClip unLockAudioClip;

    private void Start()
    {
        LockAudioClip = AudioManager.Instance.GetAudioClip("Locked");
        unLockAudioClip = AudioManager.Instance.GetAudioClip("UnLocked");
    }

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.ConfirmItem(item))
        {
            AudioManager.Instance.Sound(unLockAudioClip);

            Inventory.Instance.UseItem(item);

            toiletDoor.layer = 8;

            Destroy(gameObject);
        }
        {
            AudioManager.Instance.Sound(LockAudioClip);
        }
    }
}
