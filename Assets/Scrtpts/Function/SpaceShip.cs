using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public int spaceShipNumber;
    private Rigidbody rigidBody;
    private SpriteRenderer sprite;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        sprite = gameObject.GetComponent<SpriteRenderer>();

        SpriteView();
    }

    public void SpriteView()
    {
        switch (spaceShipNumber)
        {
            case 0:
                sprite.sprite = Resources.Load<Sprite>("Atlantis");
                break;
            case 1:
                sprite.sprite = Resources.Load<Sprite>("Discovery");
                break;
            case 2:
                sprite.sprite = Resources.Load<Sprite>("Endeavour");
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Scaffold"))
        {
            DataManager.instance.CurrentScore++;

            DataManager.instance.BestScore();

            DataManager.instance.Save();
        }
    }
}
