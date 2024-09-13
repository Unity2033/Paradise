using System.Collections;
using UnityEngine;

public class Cakes : Interaction
{
    string item = "Cakes";

    Oven ovenButton;

    public override void OnClick(Collider oven)
    {
        if (Inventory.Instance.UseItem(item))
        {
            GameObject cakes = Instantiate(Resources.Load<GameObject>("Plate"), oven.transform.position, Quaternion.Euler(-90, 0, 0));

            cakes.transform.SetParent(transform.parent);

            ovenButton = oven.transform.parent.Find("Oven Button").GetComponent<Oven>();

            ovenButton.cakes = cakes;

            Destroy(oven.gameObject);
        }
    }
}