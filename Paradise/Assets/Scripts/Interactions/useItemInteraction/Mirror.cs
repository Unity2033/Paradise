using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interaction
{
    string item = "Towel";

    public override void OnClick(Collider blood)
    {
        if (Inventory.Instance.ConfirmItem(item))
        {
            Inventory.Instance.UseItem(item);

            Destroy(gameObject);
        }
    }
}
