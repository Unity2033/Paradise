using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer shape;

    public int itemCount;
    [SerializeField] int probability = 90;
    private string [] itemName = { "Coal", "Sapphire", "Topaz", "Diamond" };

    private void Start()
    {
        ProbabilityActivation(Random.Range(0, 100));
    }

    public void ProbabilityActivation(int percentage)
    {
        if(percentage > probability)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        itemCount = Random.Range(0, 4);
        shape = GetComponent<SpriteRenderer>();
        shape.sprite = Resources.Load<Sprite>(itemName[itemCount]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            DataManager.instance.data.diamond++;

            DataManager.instance.Save();
        }
    }

}
