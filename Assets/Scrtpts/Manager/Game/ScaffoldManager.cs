using UnityEngine;
using System.Collections.Generic;

public class ScaffoldManager : MonoBehaviour
{
    [SerializeField] SpaceShip character;
 
    private int value = 0;
    private GameObject temporary;
    private List<GameObject> scaffold = new List<GameObject>();

    private int keyCount;
    private int accumulateCount;

    private int positionX;
    private bool direction = false;
    public int scaffoldNumber = 20;

    void Start()
    {
        CreateScaffold(0, scaffoldNumber);    
    }

    public int RandomPositionX()
    {
        if(Random.Range(0, 2) == 0)
            return positionX += 1;         
        else
            return positionX -= 1; 
    }

    public void CreateScaffold(int initial, int count)
    {
        for (int i = initial; i < count; i++)
        {
            temporary = Instantiate
            (
                Resources.Load<GameObject>("Scaffold"), new Vector3
                (
                    RandomPositionX(),
                    -3f + i / 2f,
                    0
                ),
                Quaternion.identity
            );

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

    public void StepUpButton()
    {
        character.animator.SetBool("Jump", true);

        SoundManager.Instance.Sound(0);

        if(direction == false)
            keyCount += 1;      
        else
            keyCount -= 1;

        character.GetComponent<SpriteRenderer>().flipX = direction;

        if (direction == true)
        {
            transform.position = new Vector3
            (
                transform.position.x + 1,
                transform.position.y - 0.5f,
                transform.position.z
            );
        }
        else
        {
            transform.position = new Vector3
            (
                transform.position.x - 1,
                transform.position.y - 0.5f,
                transform.position.z
            );
        }
        
        if (scaffold[accumulateCount].transform.localPosition.x != keyCount)
        {
            GameManager.Instance.State = GameManager.state.Exit;
        }

        if (++accumulateCount >= scaffoldNumber)
        {
            accumulateCount = 0;
        }
    }

    public void DirectionButton()
    {
        direction = !direction;

        StepUpButton();
    }


}
