using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CreateButton : MonoBehaviour
{
    public Sprite[] sprite;
    public Transform parentPosition;

    abstract public void Create(int createCount, string buttonName);

    abstract public void Function1();
    abstract public void Function2();
    abstract public void Function3();
}
