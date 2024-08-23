using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Interaction
{
    [SerializeField] GameObject LeftDrawer;
    [SerializeField] GameObject RightDrawer;

    [SerializeField] AudioClip woodBreakAudioClip;
    [SerializeField] AudioClip woodLockAudioClip;

    void Start()
    {
        woodBreakAudioClip = AudioManager.Instance.GetAudioClip("Wood Break");
        woodLockAudioClip = AudioManager.Instance.GetAudioClip("Wood Lock");
    }

    string item = "Driver";

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.UseItem(item))
        {
            AudioManager.Instance.Sound(woodBreakAudioClip);

            LeftDrawer.layer = 8;
            RightDrawer.layer = 8;

            Destroy(gameObject);
        }
        else
        {
            AudioManager.Instance.Sound(woodLockAudioClip);
        }
    }

}
