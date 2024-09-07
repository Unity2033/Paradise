using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : Interaction
{
    [SerializeField] string itemName;
    [SerializeField] AudioClip collectionAudioClip;
    [SerializeField] Outline outline;

    private void Start()
    {
        collectionAudioClip = Resources.Load<AudioClip>("Collection");

        outline = gameObject.GetComponent<Outline>();
    }

    public string ItemNam
    {
        get { return itemName; }
    }

    public override void OnClick(Collider item)
    {
        AudioManager.Instance.Sound(collectionAudioClip);

        Inventory.Instance.GetItem(item.GetComponent<Item>().itemName, item.gameObject);

        Destroy(outline);

        Destroy(item);

        item.gameObject.SetActive(false);
    }


}
