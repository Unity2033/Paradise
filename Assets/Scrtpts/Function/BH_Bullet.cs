using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BH_Bullet : MonoBehaviour
{
 
    Object_Pool memoryPool;
    public Vector3 direction;
    [SerializeField] GameObject Origin;

    public GameObject Particle, Explosion, Aiming;
    public float currentSpeed, slowSpeed = 0.1f, initialSpeed;

    void Update()
    {
        if (Singleton.instance.state == false) return;

        transform.Rotate(new Vector3(0, 0, 50f) * Time.deltaTime);

        transform.position += direction * currentSpeed * Time.deltaTime;
                 
        if (Vector3.Distance(Origin.transform.position,this.transform.position) >= 12.5f)
        {
            memoryPool.DeactivatePoolItem(gameObject);
        }

        switch (GameManager.instance.itemState)
        {
            case 1 : StartCoroutine(SlowEffectTime(5));               
                break;
            case 2 : StartCoroutine(BombEffectTime(5));
                break;
        }
    }

    private IEnumerator SlowEffectTime(float duration)
    {
        while (duration >= 0)
        {
            currentSpeed = slowSpeed;
            Particle.SetActive(true);
            duration -= Time.deltaTime;

            yield return null;
        }

        currentSpeed = initialSpeed;
        Particle.gameObject.SetActive(false);

        GameManager.instance.itemState = -1;
    }

    private IEnumerator BombEffectTime(float duration)
    {
        Aiming.SetActive(true);
        while (duration >= 0)
        {     
            duration -= Time.deltaTime;
            yield return null;
        }

        GameManager.instance.itemState = -1;
        // Sound_Manager.instance.Sound(5);

        Aiming.SetActive(false);

        //Explosion.SetActive(true);

        memoryPool.DeactivatePoolItem(gameObject);

        //Explosion.SetActive(false);
    }

    public void SetBullet(float speed, Object_Pool memoryPool)
    {
        this.memoryPool = memoryPool;
        initialSpeed = speed;
        currentSpeed = initialSpeed;
    }

    public void SetUp(Vector3 direction, Object_Pool memoryPool)
    {
        this.memoryPool = memoryPool;
        this.direction = direction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            memoryPool.DeactivatePoolItem(gameObject);
        }
    }
}
