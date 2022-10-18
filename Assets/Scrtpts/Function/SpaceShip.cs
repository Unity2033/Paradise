using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    private SpriteRenderer sprite;

    [SerializeField] float speed = 1.0f;

    public GameObject Barrier;
  
    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();

        switch (Singleton.instance.Shuttle_Switch_Count)
        {
            case 0 : sprite.sprite = Resources.Load<Sprite>("Atlantis");
                break;
            case 1 : sprite.sprite = Resources.Load<Sprite>("Discovery");
                break;
            case 2 : sprite.sprite = Resources.Load<Sprite>("Endeavour");
                break;
        }
    }

    private IEnumerator EffectTime(float duration)
    {
        while (duration >= 0)
        {
            duration -= Time.deltaTime;
            yield return null;
        }

        Barrier.SetActive(false);

        GameManager.instance.itemState = -1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            switch (other.gameObject.GetComponent<Item>().itemCount)
            {
                case 0 : GameManager.instance.itemState = other.gameObject.GetComponent<Item>().itemCount;
                    Barrier.SetActive(true);
                    StartCoroutine(EffectTime(5));              
                    break;
                case 1 : GameManager.instance.itemState = other.gameObject.GetComponent<Item>().itemCount;
                    StartCoroutine(EffectTime(5));
                    break;
                case 2 : GameManager.instance.itemState = other.gameObject.GetComponent<Item>().itemCount;
                    StartCoroutine(EffectTime(5));
                    break;
            }
        }
    }
}
