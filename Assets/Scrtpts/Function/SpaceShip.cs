using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    private GameManager Game;
    private SpriteRenderer sprite;

    [SerializeField] float speed = 1.0f;

    public GameObject Barrier;

    public GameObject Watch;
  
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

        Game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Singleton.instance.state == false) return;

        //if (Input.touchCount > 0)
        //{
        //    x = Input.touches[0].deltaPosition.x;
        //    y = Input.touches[0].deltaPosition.y;
        //}

        if (Input.GetAxis("Mouse X") > 0)
        {
             sprite.flipX = false;
        }
        else if(Input.GetAxis("Mouse X") < 0)
        {
             sprite.flipX = true;
        }
    }

    private IEnumerator EffectTime(float duration)
    {
        Watch.SetActive(true);

        while (duration >= 0)
        {
            duration -= Time.deltaTime;
            Watch.GetComponentInChildren<Text>().text = duration.ToString("F0");
            yield return null;
        }

        Watch.SetActive(false);
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (GameManager.instance.itemState != 0)
            {
                Singleton.instance.DataSave();
                Destroy(this.gameObject, 0.5f);

                Game.GameOver();
                SoundManager.instance.Sound(0);
            }
        }
    }
}
