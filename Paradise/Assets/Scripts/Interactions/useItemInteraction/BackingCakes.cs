using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackingCakes : Interaction
{
    string item = "Mitts";

    [SerializeField] Transform newTransform;
    [SerializeField] AudioClip platePutDown;
    [SerializeField] AudioClip ouch;

    private void Start()
    {
        newTransform = GameObject.Find("Cake New Position").transform;

        platePutDown = AudioManager.Instance.GetAudioClip("Plate Put Down");
        ouch = AudioManager.Instance.GetAudioClip("ouch");
    }

    public override void OnClick(Collider cake)
    {
        if (Inventory.Instance.UseItem(item))
        {
            AudioManager.Instance.Sound(platePutDown);

            cake.transform.position = newTransform.position;

            gameObject.layer = 0;

            Destroy(this);
        }
        else AudioManager.Instance.Sound(ouch);
    }
}
