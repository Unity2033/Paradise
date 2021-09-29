using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Move_Object
{
    [SerializeField] GameObject Origin;

    private void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            if (Vector3.Distance(Origin.transform.position, this.transform.position) >= 12.5f)
            {
                Destroy(gameObject);
            }

            this.transform.position += dir * _speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Singleton.instance.Quest_Turret = 1;
            Singleton.instance.SaveData();
            Destroy(gameObject);
        }
    }
}
