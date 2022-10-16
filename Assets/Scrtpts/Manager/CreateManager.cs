using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] GameObject _bullet_1;

    private SpaceShip Player;
    private Object_Pool memorypool;

    [SerializeField] GameObject Origin;

    private void Awake()
    {
        memorypool = new Object_Pool(_bullet_1);
    }

    private void OnApplicationQuit()
    {
        memorypool.Destoryobject();
        Singleton.instance.DataSave();
    }

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<SpaceShip>();

        StartCoroutine(nameof(ItemCreation));
        StartCoroutine(nameof(CurrencyIncrese));
        StartCoroutine(nameof(AsteroidCreation));
    }

    private IEnumerator CurrencyIncrese()
    {
        WaitForSeconds chaceSeconds = new WaitForSeconds(5f);

        while (Singleton.instance.state)
        {
            yield return chaceSeconds;

            if (Singleton.instance.state == false) yield break;

            Singleton.instance.Currency += 1;
        }
    }

    private IEnumerator AsteroidCreation()
    {
        WaitForSeconds chaceSeconds = new WaitForSeconds(1f);

        while (Singleton.instance.state == true)
        {
            yield return chaceSeconds;

             if (Singleton.instance.state == false) yield break;

            _bullet_1 = memorypool.ActivatePoolItem();
            _bullet_1.transform.position = Random.insideUnitCircle.normalized * 10;

            _bullet_1.GetComponent<BH_Bullet>().SetBullet(Random.Range(2.5f, 5.0f), memorypool);
            _bullet_1.GetComponent<BH_Bullet>().SetUp((Player.transform.position - _bullet_1.transform.position).normalized, memorypool);
        }
    }

    private IEnumerator ItemCreation()
    {
        WaitForSeconds chaceSeconds = new WaitForSeconds(10f);

        while (Singleton.instance.state == true)
        {
            yield return chaceSeconds;

            if (Singleton.instance.state == false) yield break;

            item.transform.position = Random.insideUnitCircle.normalized * 10;

            item.GetComponent<Item>().Set_Item(Random.Range(2.5f, 5.0f));
            item.GetComponent<Item>().Direction_Item((Origin.transform.position - item.transform.position).normalized);

            Instantiate(item, item.transform.position, item.transform.rotation);
        }
    }
}

