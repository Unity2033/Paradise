using UnityEngine;

public class BH_BulletManager : MonoBehaviour
{
    [SerializeField] GameObject _bullet_1;

    BH_PlayerMove Player;

    public GameObject Item_B, Item_S, Item_T;

    private Object_Pool memorypool;

    [SerializeField] GameObject Origin;
    Vector3 dir = Vector3.zero;

    float one_time, five_time, ten_time = 0;

    private void Awake()
    {
        memorypool = new Object_Pool(_bullet_1);
    }

    private void OnApplicationQuit()
    {
        memorypool.Destoryobject();
        Singleton.instance.SaveData();
    }

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<BH_PlayerMove>();
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            one_time += Time.deltaTime;
            five_time += Time.deltaTime;
            ten_time += Time.deltaTime;

            if (one_time >= 1.0f)
            {
                SetPositionBullet();
                one_time = 0.0f;
            }

            if (five_time >= 5.0f)
            {          
                Singleton.instance.Currency += 1;           
                Singleton.instance.SaveData();

                five_time = 0.0f;
            }

            if (ten_time >= 15.0f)
            {
                Random_Item_Create();
                ten_time = 0.0f;
            }
        }
    }

    private void SetPositionBullet()
    {
          _bullet_1 = memorypool.ActivatePoolItem();

          _bullet_1.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
          _bullet_1.transform.position = _bullet_1.transform.right * 10f;

          dir = Player.transform.position - _bullet_1.transform.position;
          dir.Normalize();

         _bullet_1.GetComponent<BH_Bullet>().SetBullet(Random.Range(2.5f, 5.0f), memorypool);

         _bullet_1.GetComponent<BH_Bullet>().SetUp(dir, memorypool);              
    }

    private void Random_Item_Create()
    {
            int Number = Random.Range(0, 3);

            switch (Number)
            {
                case 0 : Item_Function(Item_B); break;
                case 1 : Item_Function(Item_S); break;
                case 2 : Item_Function(Item_T); break;
            }
    }

    public void Item_Function(GameObject item)
    {
        Instantiate(item, gameObject.transform);

        item.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        item.transform.position = item.transform.right * 10f;

        dir = (Origin.transform.position - item.transform.position).normalized;

        item.GetComponent<Move_Object>().Set_Item(Random.Range(2.5f, 5.0f));
        item.GetComponent<Move_Object>().Direction_Item(dir);
    }
}

