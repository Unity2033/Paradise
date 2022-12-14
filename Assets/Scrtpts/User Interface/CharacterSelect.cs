using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] Sprite [] sprite;
    [SerializeField] Image characterSprite;
    [SerializeField] Button purchaseButton;

    private void Start()
    {
        SpriteView();
    }

    private void SpriteView()
    { 
        characterSprite.sprite = sprite[DataManager.Instance.data.characterSelectNumber];
        purchaseButton.interactable = DataManager.Instance.data.check[DataManager.Instance.data.characterSelectNumber];
    }

    public void SpaceShipRightButton()
    {
        SoundManager.Instance.Sound(5);

        if (++DataManager.Instance.data.characterSelectNumber >= sprite.Length)
        {
            DataManager.Instance.data.characterSelectNumber = 0;
        }

        SpriteView();
    }

    public void SpaceShipLeftButton()
    {
        SoundManager.Instance.Sound(5);

        if (--DataManager.Instance.data.characterSelectNumber < 0)
        {
            DataManager.Instance.data.characterSelectNumber = sprite.Length - 1;
        }

        SpriteView();
    }

}
