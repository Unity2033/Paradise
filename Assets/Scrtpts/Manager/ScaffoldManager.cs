using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldManager : MonoBehaviour
{
    [SerializeField] ParticleSystem particle; 
    [SerializeField] SpriteRenderer characterSprite;

    private GameObject temporary;

    int positionX;

    void Start()
    {
        particle.Stop();

        for (int i = 0; i < 15; i++)
        {
            temporary = Instantiate
            (
                Resources.Load<GameObject>("Scaffold"), 
                new Vector3 
                (
                    RandomPositionX(), 
                    -3.5f + i / 2f
                    , 0
                ), 
                Quaternion.identity
            );

            temporary.transform.SetParent(transform);
        }
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

    public void ScaffoldMove(bool direction)
    {
        particle.Play();

        SoundManager.instance.Sound(0);

        if (direction == true) // Right Direction
        {
            characterSprite.flipX = false;
            transform.position = new Vector3(transform.position.x - 1f, transform.position.y - 0.5f, transform.position.z);
        }
        else // Left Direction
        {
            characterSprite.flipX = true;
            transform.position = new Vector3(transform.position.x + 1f, transform.position.y - 0.5f, transform.position.z);
        }      
    }
}
