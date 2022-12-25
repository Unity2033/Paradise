using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer shape;

    [SerializeField] int probability = 90;

    private string itemName = "Diamond";

    private void Start()
    {
        ProbabilityActivation(Random.Range(0, 100));
    }

    public void ProbabilityActivation(int percentage)
    {
        if (percentage > probability)
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
        shape = GetComponent<SpriteRenderer>();
        shape.sprite = Resources.Load<Sprite>(itemName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);

            SoundManager.Instance.Sound(2);

            DataManager.Instance.data.diamond++;

            DataManager.Instance.Save();
        }       
    }
}
