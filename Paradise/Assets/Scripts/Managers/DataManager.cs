using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public void Load()
    {
        Debug.Log("Load");
    }

    public void Save()
    {
        Debug.Log("Save");
    }
}
