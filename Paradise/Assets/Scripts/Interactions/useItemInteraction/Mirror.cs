using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interaction
{
    string item = "Towel";

    [SerializeField] AudioClip eraseAudioClip;

    private void Start()
    {
        eraseAudioClip = AudioManager.Instance.GetAudioClip("Erase");
    }

    public override void OnClick(Collider blood)
    {
        if (Inventory.Instance.UseItem(item))
        {
            AudioManager.Instance.Sound(eraseAudioClip);

            Destroy(gameObject);
        }
    }
}
