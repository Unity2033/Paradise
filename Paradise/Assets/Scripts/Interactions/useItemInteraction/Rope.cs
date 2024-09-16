using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : Interaction
{
    [SerializeField] GameObject LeftDrawer;
    [SerializeField] GameObject RightDrawer;


    void Start()
    {

    }

    string item = "Knife";

    public override void OnClick(Collider door)
    {
        if (Inventory.Instance.UseItem(item))
        {
            LeftDrawer.layer = 8;
            RightDrawer.layer = 8;


        }
    }
}
