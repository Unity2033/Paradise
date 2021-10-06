using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : Move_Object
{
    [SerializeField] GameObject Origin;

    void Update()
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
            Social.ReportProgress(GPGSIds.achievement__sh1, 100, null);
             Destroy(gameObject);
        }
    }
}
