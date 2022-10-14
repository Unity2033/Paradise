using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text Diamond;
    [SerializeField] GameObject [ ] spaceShip;

    private void Start()
    {
        SpaceShipView();
        Singleton.instance.BGM_Sound.Play();
    }

    private void Update()
    {
        Diamond.text = Singleton.instance.Currency.ToString();
    }

    public void SpaceShipRightButton()
    {
        if (++Singleton.instance.Shuttle_Switch_Count >= spaceShip.Length)
        {
            Singleton.instance.Shuttle_Switch_Count = 0;
        }

        SpaceShipView();
    }

    public void SpaceShipLeftButton()
    {
        if (--Singleton.instance.Shuttle_Switch_Count < 0)
        {
            Singleton.instance.Shuttle_Switch_Count = spaceShip.Length - 1;
        }

        SpaceShipView();
    }

    public void SpaceShipView()
    {
        for(int i = 0; i < spaceShip.Length; i++)
        {
            spaceShip[i].SetActive(false);
        }

        spaceShip[Singleton.instance.Shuttle_Switch_Count].SetActive(true);
    }
   

}
