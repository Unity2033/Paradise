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
        Diamond.text = DataManager.instance.data.diamond.ToString();
    }

    public void PurchaseButton()
    {
         if(shuttle[spaceShip.spaceShipNumber].price <= DataManager.instance.data.diamond)
         {
              DataManager.instance.data.diamond -= shuttle[spaceShip.spaceShipNumber].price;         
              DataManager.instance.data.purchaseConfirmation[spaceShip.spaceShipNumber] = true;
              shuttle[spaceShip.spaceShipNumber].purchaseButton.interactable = false;
        }
    }

    public void PurchaseHistory()
    {
        for (int i = 0; i < shuttle.Length; i++)
        {
            if (DataManager.instance.data.purchaseConfirmation[i] == false)
            {
                shuttle[i].purchaseButton.interactable = false;
            }
            else
            {
                shuttle[i].purchaseButton.interactable = true;
            }
        }
    }

    public void SpaceShipRightButton()
    {
        if (++spaceShip.spaceShipNumber >= shuttle.Length)
        {
            spaceShip.spaceShipNumber = 0;
        }

        spaceShip.SpriteView();
    }

    public void SpaceShipLeftButton()
    {
        if (--spaceShip.spaceShipNumber < 0)
        {
            spaceShip.spaceShipNumber = shuttle.Length - 1;
        }

        spaceShip.SpriteView();
    }

}
