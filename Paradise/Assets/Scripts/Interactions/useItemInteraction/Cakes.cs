using System.Collections;
using UnityEngine;

public class Cakes : Interaction
{
    string item = "Cakes";

    Oven ovenButton;

    [SerializeField] AudioClip platePutDown;

    private void Start()
    {
        platePutDown = AudioManager.Instance.GetAudioClip("Plate Put Down");
    }

    public override void OnClick(Collider oven)
    {
        if (Inventory.Instance.UseItem(item))
        {
            AudioManager.Instance.Sound(platePutDown);

            GameObject cakes = Instantiate(Resources.Load<GameObject>("Plate"), oven.transform.position, Quaternion.Euler(-90, 0, 0));

            cakes.transform.SetParent(transform.parent);

            ovenButton = oven.transform.parent.Find("Oven Button").GetComponent<Oven>();

            ovenButton.cakes = cakes;

            Destroy(oven.gameObject);
        }
    }
}