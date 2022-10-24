using System.Collections;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    private SpriteRenderer sprite;

    private Rigidbody rigidBody;

    [SerializeField] float speed = 1.0f;

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
        if (GameManager.instance.State == GameManager.state.END)
        {
            rigidBody.useGravity = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Scaffold"))
        {
            GameManager.instance.State = GameManager.state.EXECUTION;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Scaffold"))
        {
            GameManager.instance.State = GameManager.state.END;
        }
    }
}
