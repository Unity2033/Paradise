using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] bool state;

    public bool State
    {
        get { return state; }
        set { state = value; }
    }
}
