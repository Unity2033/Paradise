using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Interaction
{
    [SerializeField] GameObject LeftDrawer;
    [SerializeField] GameObject RightDrawer;

    void Success()
    {
        LeftDrawer.layer = 8;
        RightDrawer.layer = 8;
    }
}
