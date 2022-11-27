using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    private int count = 0;
    [SerializeField] ScaffoldManager scaffoldManager;

    private void Start()
    {
        InvokeRepeating(nameof(Move), 0, 1);
    }

    private void Move()
    {
        if(GameManager.Instance.State == GameManager.state.Progress)
        {
            Vector3 direicton = scaffoldManager.scaffold[count++].transform.position;

            direicton.y += 0.5f;
            transform.position = direicton;
        }
    }




}
