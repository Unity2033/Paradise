using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : Interaction
{
    [SerializeField] string itemName;
    [SerializeField] AudioClip collectionAudioClip;
    [SerializeField] Outline outline;

    [SerializeField] Vector3 itemPosition;
    [SerializeField] Quaternion rotation;

    private void Start()
    {
        collectionAudioClip = Resources.Load<AudioClip>("Collection");

        outline = gameObject.GetComponent<Outline>();
    }

    public string ItemName
    {
        get { return itemName; }
    }

    public Vector3 ItemPosition
    {
        get { return itemPosition; }
    }

    public Quaternion ItemRotation
    {
        get { return rotation; }
    }

    public override void OnClick(Collider item)
    {
        AudioManager.Instance.Sound(collectionAudioClip);

        Inventory.Instance.GetItem(ItemName, item.gameObject, ItemPosition, ItemRotation);

        Destroy(outline);

        Destroy(item);

        item.gameObject.SetActive(false);
    }


}
