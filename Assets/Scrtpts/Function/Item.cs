using UnityEngine;

public class Item : MonoBehaviour
{
    private SpriteRenderer shape;

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
        shape = GetComponent<SpriteRenderer>();
        shape.sprite = Resources.Load<Sprite>(itemName[Random.Range(0, 4)]);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.State == GameManager.state.Progress)
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

}
