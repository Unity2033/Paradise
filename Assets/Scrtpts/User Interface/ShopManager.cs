using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Shuttle
{
    public int price;
    public Sprite sprite;

}


public class ShopManager : MonoBehaviour
{
    [SerializeField] Text Diamond;
    [SerializeField] GameObject spaceShip;

    public Shuttle [] shuttle;

    private void Start()
    {
        SpaceShipView();
    }

    private void Update()
    {
        Diamond.text = Singleton.instance.Currency.ToString();
    }

    public void PurchaseButton()
    {
        switch (Singleton.instance.Shuttle_Switch_Count)
        {
            case 1 : if(shuttle[1].price <= Singleton.instance.Currency)
            {
                Singleton.instance.Currency -= shuttle[1].price;
            }
            break;
            case 2 : if (shuttle[2].price <= Singleton.instance.Currency)
            {
                Singleton.instance.Currency -= shuttle[2].price;
            }
            break;
        }

    }

    public void SpaceShipRightButton()
    {
        if (++Singleton.instance.Shuttle_Switch_Count >= shuttle.Length)
        {
            Singleton.instance.Shuttle_Switch_Count = 0;
        }

        SpaceShipView();
    }

    public void SpaceShipLeftButton()
    {
        if (--Singleton.instance.Shuttle_Switch_Count < 0)
        {
            Singleton.instance.Shuttle_Switch_Count = shuttle.Length - 1;
        }

        SpaceShipView();
    }

    public void SpaceShipView()
    {
        spaceShip.GetComponent<Image>().sprite = shuttle[Singleton.instance.Shuttle_Switch_Count].sprite;
    }
   

}
