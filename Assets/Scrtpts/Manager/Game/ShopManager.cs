using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Shuttle
{
    public int price;
    public Sprite selectedCharacter;
}

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text Diamond;
    [SerializeField] Image characterSprite;
    [SerializeField] Button purchaseButton;

    public Shuttle [] shuttle;

    private void Start()
    {
        SpriteView();
    }

    private void SpriteView()
    {
        characterSprite.sprite = shuttle[DataManager.Instance.data.characterSelectNumber].selectedCharacter;
    }

    private void Update()
    {
        Diamond.text = DataManager.Instance.data.diamond.ToString();
        purchaseButton.interactable = DataManager.Instance.data.check[DataManager.Instance.data.characterSelectNumber];
    }

    public void PurchaseButton()
    {
         if(shuttle[DataManager.Instance.data.characterSelectNumber].price <= DataManager.Instance.data.diamond)
         {
              DataManager.Instance.data.diamond -= shuttle[DataManager.Instance.data.characterSelectNumber].price;                 
         }

        DataManager.Instance.Save();
    }

    public void SpaceShipRightButton()
    {
        SoundManager.instance.Sound(5);

        if (++DataManager.Instance.data.characterSelectNumber >= shuttle.Length)
        {
            DataManager.Instance.data.characterSelectNumber = 0;
        }

        SpriteView();
    }

    public void SpaceShipLeftButton()
    {
        SoundManager.instance.Sound(5);

        if (--DataManager.Instance.data.characterSelectNumber < 0)
        {
            DataManager.Instance.data.characterSelectNumber = shuttle.Length - 1;
        }

        SpriteView();
    }

}
