using UnityEngine;
using System.Collections;

public class CreateManager : MonoBehaviour
{
    [SerializeField] GameObject[] item;
    [SerializeField] GameObject _bullet_1;

    private BH_PlayerMove Player;
    private Object_Pool memorypool;

    [SerializeField] GameObject Origin;

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

        StartCoroutine(nameof(ItemCreation));
        StartCoroutine(nameof(CurrencyIncrese));
        StartCoroutine(nameof(AsteroidCreation));
    }

    private IEnumerator CurrencyIncrese()
    {
        while (Singleton.instance.GamePlay)
        {
            yield return new WaitForSeconds(5f);

            if (Singleton.instance.GamePlay == false) yield break;

            Singleton.instance.Currency += 1;
        }
    }


    private IEnumerator AsteroidCreation()
    {
        while(Singleton.instance.GamePlay)
        {
            yield return new WaitForSeconds(1f);

            if (Singleton.instance.GamePlay == false) yield break;

            _bullet_1 = memorypool.ActivatePoolItem();
            _bullet_1.transform.position = Random.insideUnitCircle.normalized * 10;

            _bullet_1.GetComponent<BH_Bullet>().SetBullet(Random.Range(2.5f, 5.0f), memorypool);
            _bullet_1.GetComponent<BH_Bullet>().SetUp((Player.transform.position - _bullet_1.transform.position).normalized, memorypool);
        }
    }

    private IEnumerator ItemCreation()
    {
        while (Singleton.instance.GamePlay)
        {
            yield return new WaitForSeconds(10f);

            if (Singleton.instance.GamePlay == false) yield break;

            int index = Random.Range(0, 3);

            Instantiate(item[index], gameObject.transform);

            item[index].transform.position = Random.insideUnitCircle.normalized * 10;

            item[index].GetComponent<Move_Object>().Set_Item(Random.Range(2.5f, 5.0f));
            item[index].GetComponent<Move_Object>().Direction_Item((Origin.transform.position - item[index].transform.position).normalized);
        }
    }
}

