using UnityEngine;

public class ScaffoldManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particle; 
    [SerializeField] SpaceShip character;

    private GameObject temporary;

    private int positionX;
    private int scaffoldNumber = 15;

    void Start()
    {
        particle.Stop();

        CreateScaffold(0, scaffoldNumber);    
    }

    public int RandomPositionX()
    {
        if(Random.Range(0, 2) == 0)
        {
             positionX += 1;         
        }
        else
        {
             positionX -= 1;
        }

        return positionX;       
    }

    public void CreateScaffold(int initial, int count)
    {
        for (int i = initial; i < count; i++)
        {
            temporary = Instantiate
            (
                Resources.Load<GameObject>("Scaffold"),
                new Vector3
                (
                    RandomPositionX() + transform.position.x,
                    -3.5f + i / 2f
                    , 0
                ),
                Quaternion.identity
            ); ; 

            temporary.transform.SetParent(transform);
        }
    }

    public void ScaffoldMove(bool direction)
    {
        if (GameManager.instance.state == false) return;

        particle.Play();

        SoundManager.instance.Sound(0);

        if (direction == true) // Right Direction
        {
            character.GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 0.5f, transform.position.z);
        }
        else // Left Direction
        {
            character.GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y - 0.5f, transform.position.z);
        }

        CreateScaffold(scaffoldNumber - 1, ++scaffoldNumber);       
    }
}
