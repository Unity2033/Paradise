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
        Diamond.text = DataManager.instance.data.diamond.ToString();
    }

    public void PurchaseButton()
    {
        switch (DataManager.instance.data.spaceShipCount)
        {
            case 1 : 
            if(shuttle[1].price <= DataManager.instance.data.diamond)
            {
                    DataManager.instance.data.diamond -= shuttle[1].price;
            }
            break;
            case 2 : 
                if (shuttle[2].price <= DataManager.instance.data.diamond)
            {
                    DataManager.instance.data.diamond -= shuttle[2].price;
            }
            break;
        }

    }

    public void SpaceShipRightButton()
    {
        if (++DataManager.instance.data.spaceShipCount >= shuttle.Length)
        {
            DataManager.instance.data.spaceShipCount = 0;
        }

        SpaceShipView();
    }

    public void SpaceShipLeftButton()
    {
        if (--DataManager.instance.data.spaceShipCount < 0)
        {
            DataManager.instance.data.spaceShipCount = shuttle.Length - 1;
        }

        SpaceShipView();
    }

    public void SpaceShipView()
    {
        DataManager.instance.Save();
        spaceShip.GetComponent<Image>().sprite = shuttle[DataManager.instance.data.spaceShipCount].sprite;
    }
   

}
