using System;
using UnityEngine;
using System.Collections.Generic;

public class ScaffoldManager : Singleton<ScaffoldManager>
{
    [SerializeField] SpaceShip character;

    private int value = 0;
 
    public GameObject [ ] scaffold = new GameObject[20];

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
        if(UnityEngine.Random.Range(0, 2) == 0)
            return positionX += 1;         
        else
            return positionX -= 1; 
    }

    public void CreateScaffold(int initial, int count)
    {
        for (int i = initial; i < count; i++)
        {
            GameObject temporary = Instantiate
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
            scaffold[i] = temporary;
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
        character.animator.Play("Jump Animation");

        SoundManager.Instance.Sound(0);

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

        // ScaffoldManager 오브젝트의 위치와 Scaffold 오브젝트의 현재 요소의 local 위치를 계산합니다.
        if (transform.position.x + scaffold[accumulateCount].transform.localPosition.x != 0)
        {
            GameManager.Instance.StateCanvas(GameManager.state.Exit);
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
