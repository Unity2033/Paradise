using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer shape;
    [SerializeField] GameObject origin;
    public Vector3 direction;

    public float _speed;
    public int itemCount;
    public string [] itemName = { "Barrier", "Speed Down", "Support Fire" };

    void Start()
    {
        itemCount = Random.Range(0, 3);
        shape = GetComponent<SpriteRenderer>();
        shape.sprite = Resources.Load<Sprite>(itemName[itemCount]);
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            transform.Rotate(new Vector3(0, 0, 50f) * Time.deltaTime);

            if (Vector3.Distance(origin.transform.position, transform.position) >= 12.5f)
            {
                Destroy(gameObject);
            }

            transform.position += direction * _speed * Time.deltaTime;
        }
    }

    public void Direction_Item(Vector3 direction)
    {
        this.direction = direction;
    }

    public void Set_Item(float speed)
    {
        _speed = speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Social.ReportProgress(GPGSIds.achievement__sh1, 100, null);

            // Social.ReportProgress(GPGSIds.achievement_3, 100, null);
            // Social.ReportProgress(GPGSIds.achievement_2, 100, null);
            Destroy(gameObject);
        }
    }

}
