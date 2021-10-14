using UnityEngine;

public class Turret : Move_Object
{
    [SerializeField] GameObject Origin;

    private void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            transform.Rotate(new Vector3(0, 0, 50f) * Time.deltaTime);

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
            Social.ReportProgress(GPGSIds.achievement_2, 100, null);
            Destroy(gameObject);
        }
    }
}
