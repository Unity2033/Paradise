using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayOut : Interaction
{
    [SerializeField] GameObject wayOutDoor;

    

    void Success()
    {
        wayOutDoor.layer = 8;
    }
}
