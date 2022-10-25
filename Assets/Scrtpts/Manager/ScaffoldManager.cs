using UnityEngine;
using System.Collections.Generic;

public class ScaffoldManager : MonoBehaviour
{
    public static ScaffoldManager instance;

    [SerializeField] ParticleSystem particle; 
    [SerializeField] SpaceShip character;

    private List<GameObject> scaffold = new List<GameObject>();
    private int value = 0;
    private GameObject temporary;

    private int positionX;
    public int scaffoldNumber = 20;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

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
                    RandomPositionX(),
                    -3f + i / 2f
                    , 0
                ),
                Quaternion.identity
            ); ; 

            temporary.transform.SetParent(transform);
            scaffold.Add(temporary);
        }
    }

    public void Position(int count)
    {
        Vector3 direction = new Vector3
        (
            RandomPositionX() + transform.position.x,
            -3f + (count / 2f), 
            0
        );

        scaffold[value].transform.position = direction;

        if (++value >= scaffoldNumber)
        {
            value = 0;
        }
    }

    public void ScaffoldMove(bool direction)
    {
        if (GameManager.instance.State == GameManager.state.Exit) return;

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
    }
}
