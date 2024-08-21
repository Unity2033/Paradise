using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : Interaction
{
    [SerializeField] GameObject exitDoor;

    string item = "Lobby Key";

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.ConfirmItem(item))
        {
            Inventory.Instance.UseItem(item);

            exitDoor.layer = 8;

            Destroy(gameObject);
        }
    }

}
