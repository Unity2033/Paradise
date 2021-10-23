using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BH_Bullet : MonoBehaviour
{
    [SerializeField] GameObject Origin;

    BH_PlayerMove Player;
    Object_Pool memoryPool;

    public GameObject Particle, Explosion, Aiming;
    public Vector3 dir = Vector3.zero;

    public float _speed, time;

    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<BH_PlayerMove>();     
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            transform.Rotate(new Vector3(0, 0, 50f) * Time.deltaTime);


            if (Player.classification == 1 && Player.Item_Condition)
            {
                Particle.gameObject.SetActive(true);
                this.transform.position += dir * _speed * 0.1f * Time.deltaTime;
            }
            else
            {
                Particle.gameObject.SetActive(false);
                this.transform.position += dir * _speed * Time.deltaTime;
            }
          
            if(Player.classification == 3 && Player.Item_Condition)
            {
                time += Time.deltaTime;
                Aiming.SetActive(true);

                if (time >= 0.75f)
                {
                    Explosion.SetActive(true);
                }

                if (time >= 1.0f)
                {
                    Sound_Manager.instance.Support_Sound();
                    memoryPool.DeactivatePoolItem(gameObject);
                    time = 0.0f;
                }
            }
            else
            {
                Aiming.SetActive(false);
                Explosion.SetActive(false);
            }

            if (Vector3.Distance(Origin.transform.position,this.transform.position) >= 12.5f)
            {
                memoryPool.DeactivatePoolItem(gameObject);
            }
        }
    }

    public void SetBullet(float speed, Object_Pool memoryPool)
    {
        this.memoryPool = memoryPool;

        _speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            memoryPool.DeactivatePoolItem(gameObject);
        }
    }

    public void SetUp(Vector3 direction, Object_Pool memoryPool)
    {
        this.memoryPool = memoryPool;

        dir = direction;
    }
}
