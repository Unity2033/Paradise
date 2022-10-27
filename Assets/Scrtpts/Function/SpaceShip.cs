using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private Rigidbody rigidBody;
    private SpriteRenderer sprite;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        switch (DataManager.instance.data.spaceShipCount)
        {
            case 0 : sprite.sprite = Resources.Load<Sprite>("Atlantis");
                break;
            case 1 : sprite.sprite = Resources.Load<Sprite>("Discovery");
                break;
            case 2 : sprite.sprite = Resources.Load<Sprite>("Endeavour");
                break;
        }
    }

    private void Update()
    {
        if (GameManager.instance.State == GameManager.state.Exit)
        {
            rigidBody.useGravity = true;
            GameManager.instance.StateCanvas();
            return;
        }
    }
}
