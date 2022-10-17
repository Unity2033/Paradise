using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaffoldManager : MonoBehaviour
{
    int [ ] positionX = new int[10];

    [SerializeField] GameObject scaffold;

    void Start()
    {
        for(int i = 0; i < positionX.Length; i++)
        {
            int [ ] value = RandomPositionX();

            Instantiate
            (
                scaffold,
                new Vector3(value[i], -2 + i / 2f, 0),
                Quaternion.identity
            );
        }
    }

    public int [ ] RandomPositionX()
    {
        for (int i = 1; i < positionX.Length; i++)
        {
            positionX[i-1] = Random.Range(-3, 3);

            if (positionX[i-1] == positionX[i])
            {
                i--;
            }
        }

        return positionX;       
    }
}
