using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoor : Interaction
{
    [SerializeField] GameObject toiletDoor;

    string item = "Toliet Key";

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.ConfirmItem(item))
        {
            Inventory.Instance.UseItem(item);

            toiletDoor.layer = 8;

            Destroy(gameObject);
        }
    }
}
