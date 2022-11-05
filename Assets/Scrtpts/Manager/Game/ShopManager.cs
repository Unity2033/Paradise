using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Shuttle
{
    public int price;
    public Button purchaseButton;
}

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text Diamond;
    [SerializeField] SpaceShip spaceShip;

    public Shuttle [] shuttle;

    private void Start()
    {
        spaceShip.SpriteView();
    }

    private void Update()
    {
        Diamond.text = DataManager.Instance.data.diamond.ToString();
    }

    public void PurchaseButton()
    {
         if(shuttle[spaceShip.spaceShipNumber].price <= DataManager.Instance.data.diamond)
         {
              DataManager.Instance.data.diamond -= shuttle[spaceShip.spaceShipNumber].price;         
              shuttle[spaceShip.spaceShipNumber].purchaseButton.interactable = false;
         }
    }
    public void SpaceShipRightButton()
    {
        SoundManager.instance.Sound(5);

        if (++spaceShip.spaceShipNumber >= shuttle.Length)
        {
            spaceShip.spaceShipNumber = 0;
        }

        spaceShip.SpriteView();
    }

    public void SpaceShipLeftButton()
    {
        SoundManager.instance.Sound(5);

        if (--spaceShip.spaceShipNumber < 0)
        {
            spaceShip.spaceShipNumber = shuttle.Length - 1;
        }

        spaceShip.SpriteView();
    }

}
