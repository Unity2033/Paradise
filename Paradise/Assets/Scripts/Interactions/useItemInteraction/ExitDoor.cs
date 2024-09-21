using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interaction
{
    [SerializeField] GameObject exitDoor;

    string item = "Lobby Key";

    [SerializeField] GameObject key;

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

            exitDoor.layer = 8;

            Destroy(gameObject);
        }
        else
        {
            AudioManager.Instance.Sound(LockAudioClip);
        }
    }

}
