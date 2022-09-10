using UnityEngine;
using UnityEngine.UI;

public class BH_PlayerMove : MonoBehaviour
{
    BH_GameManager Game;

    public bool Item_Condition;

    SpriteRenderer sprite_renderer;

    [SerializeField] float speed = 1.0f;

    public GameObject Barrier, Particle;

    public GameObject Watch;

    [SerializeField] Text Life_Cycle;

    float Life_time;
    public int classification = 0;

    private void Start()
    {
        sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        Game = GameObject.Find("GameManager").GetComponent<BH_GameManager>();      
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
                x * speed *  Time.deltaTime,
                y * speed * Time.deltaTime,
                transform.position.z
            );

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
            pos.y = Mathf.Clamp(pos.y, 0.025f, 0.95f);
  
            transform.position = Camera.main.ViewportToWorldPoint(pos);

            Item_Cylce();
        }
    }

    void Item_Cylce()
    {  
        if (Item_Condition)
        {
            Watch.SetActive(true);
            Life_time -= Time.deltaTime;

            Life_Cycle.text = Life_time.ToString("F0");

            switch (classification)
            {
                case 1:
                    Item_Life(Life_time, 0.0f);
                    break;
                case 2:
                    Item_Life(Life_time, 0.0f);
                    break;
                case 3:
                    Item_Life(Life_time, 0.0f);
                    break;
            }
        }
        else
        {
            Life_time = 5.0f;
            Watch.SetActive(false);          
        }
    }

    void Item_Life(float Item_time, float Item_compare)
    {
        if (Item_time <= Item_compare)
        {
            Item_Condition = false;
            Barrier.SetActive(false);
            Watch.SetActive(false);
            classification = 0;
            Life_time = 5.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Item_Condition = true;

            switch (other.gameObject.GetComponent<Item>().itemCount)
            {
                case 0 : classification = 1;
                    break;
                case 1 : classification = 2;
                    Barrier.SetActive(true);
                    break;
                case 2 : classification = 3;
                    break;

            }
        }

        if (other.gameObject.CompareTag("Enemy") && classification != 2)
        {
            Game.GameOver();
            Particle.SetActive(true);
            Singleton.instance.SaveData();
            Destroy(this.gameObject, 0.5f);
            Sound_Manager.instance.Sound(0);
        }
    }
}
