using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Interaction
{
    [SerializeField] GameObject LeftDrawer;
    [SerializeField] GameObject RightDrawer;

    string item = "Driver";

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.ConfirmItem(item))
        {
            Inventory.Instance.UseItem(item);

            LeftDrawer.layer = 8;
            RightDrawer.layer = 8;

            Destroy(gameObject);
        }
    }

}
