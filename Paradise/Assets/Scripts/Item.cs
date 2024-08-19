using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Interaction
{
    [SerializeField] string itemName;
    [SerializeField] AudioClip collectionAudioClip;

    private void Start()
    {
        collectionAudioClip = Resources.Load<AudioClip>("Collection");
    }

    public string ItemNam
    {
        get { return itemName; }
    }

    public override void OnClick(Collider item)
    {
        AudioManager.Instance.Sound(collectionAudioClip);

        Inventory.Instance.GetItem(item.GetComponent<Item>().itemName);

        item.gameObject.SetActive(false);
    }


}
