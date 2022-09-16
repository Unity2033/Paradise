using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BH_PlayerMove : MonoBehaviour
{
    private GameManager Game;
    private SpriteRenderer sprite_renderer;

    [SerializeField] float speed = 1.0f;

    public GameObject Barrier, Particle;

    public GameObject Watch;
    private Rigidbody rigid;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        Game = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            if (Input.touchCount > 0)
            {
                x = Input.touches[0].deltaPosition.x;
                y = Input.touches[0].deltaPosition.y;
            }

            if(Input.GetAxis("Mouse X") > 0)
            {
                sprite_renderer.flipX = false;
            }
            else if(Input.GetAxis("Mouse X") < 0)
            {
                sprite_renderer.flipX = true;
            }

            transform.Translate
            (
                x * speed * Time.deltaTime,
                y * speed * Time.deltaTime,
                transform.position.z
            );

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
            pos.y = Mathf.Clamp(pos.y, 0.025f, 0.95f);
  
            transform.position = Camera.main.ViewportToWorldPoint(pos);
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
                Game.GameOver();
                Particle.SetActive(true);
                Singleton.instance.SaveData();
                Destroy(this.gameObject, 0.5f);
                Sound_Manager.instance.Sound(0);
            }
        }
    }
}
