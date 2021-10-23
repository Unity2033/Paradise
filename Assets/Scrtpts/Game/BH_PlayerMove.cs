using UnityEngine;
using UnityEngine.UI;

public class BH_PlayerMove : MonoBehaviour
{
    BH_GameManager Game;

    public bool Item_Condition,Skill_Condition;

    private Touch touch;

    public GameObject Barrier, Particle;
    public GameObject Watch;

    [SerializeField] Text Life_Cycle;

    SpriteRenderer Shuttle;

    float Life_time, Skill_Life_time;
    public int classification = 0;

    private void Start()
    {
        Shuttle = GetComponent<SpriteRenderer>();
        Game = GameObject.Find("GameManager").GetComponent<BH_GameManager>();      
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            Debug.Log(Singleton.instance.Gear_Speed);

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Moved)
                {
                    transform.position = new Vector3(
                        transform.position.x + touch.deltaPosition.x * Singleton.instance.Gear_Speed,
                        transform.position.y + touch.deltaPosition.y * Singleton.instance.Gear_Speed,
                        transform.position.z);
                }
            }

            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

            if (pos.x < 0f) pos.x = 0.1f;
            if (pos.x > 1f) pos.x = 0.9f;
            if (pos.y < 0f) pos.y = 0.025f;
            if (pos.y > 1f) pos.y = 0.95f;

            transform.position = Camera.main.ViewportToWorldPoint(pos);

            if (Random.Range(1, 10000) <= 1)
            {
                Skill_Condition = true;
            }

            Item_Cylce();
            Skill_Cycle();
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

    void Skill_Cycle()
    {
        if (Skill_Condition)
        {
            Shuttle.color = new Color(1, 1, 1, 0.25f);

            Skill_Life_time -= Time.deltaTime;
            Skill_Life(Skill_Life_time, 0.0f);
        }
        else
        {
            Shuttle.color = new Color(1, 1, 1, 1);
            Life_time = 3.0f;
        }
    }

    void Skill_Life(float time, float compare)
    {
        if (time <= compare)
        {
            Skill_Condition = false;
            Skill_Life_time = 3.0f;
        }
    }

    void Item_Life(float time, float compare)
    {
        if (time <= compare)
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
            Destroy(this.gameObject, 0.5f);
            Sound_Manager.instance.Belch_Sound();
        }
    }
}
