using UnityEngine;
using UnityEngine.UI;

public class BH_PlayerMove : MonoBehaviour
{
    BH_GameManager Game;

    public bool Item_Condition;

    SpriteRenderer sprite_renderer;

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
                x * Time.deltaTime,
                y * Time.deltaTime,
                transform.position.z
            );

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f) pos.x = 0.1f;
            if (pos.x > 1f) pos.x = 0.9f;
            if (pos.y < 0f) pos.y = 0.025f;
            if (pos.y > 1f) pos.y = 0.95f;

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
        if (other.gameObject.CompareTag("Slow"))
        {
            Item_Condition = true;
            classification = 1;
        }

        if (other.gameObject.CompareTag("Barrier")) 
        {
            Item_Condition = true;
            Barrier.SetActive(true);
            classification = 2;
        }

        if (other.gameObject.CompareTag("Turret"))
        {
            Item_Condition = true;
            classification = 3;
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
