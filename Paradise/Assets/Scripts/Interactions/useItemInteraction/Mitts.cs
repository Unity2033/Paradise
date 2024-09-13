using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mitts : Interaction
{
    string item = "Mitts";

    [SerializeField] Transform newTransform;

    private void Start()
    {
        newTransform = GameObject.Find("Cake New Position").transform;
    }

    public override void OnClick(Collider cake)
    {
        if (Inventory.Instance.UseItem(item))
        {
            cake.transform.position = newTransform.position;
        }
        else
        {

        }
    }
}
