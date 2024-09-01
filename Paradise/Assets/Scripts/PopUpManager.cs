using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Panel
{
    SafeBoxUI,
    DoorPasswordUI,
    CabinetPasswordUI,
}

public class PopUpManager : MonoBehaviour
{
    [SerializeField] List<GameObject> prefabs;

    public void Start()
    {
        prefabs.Capacity = 10;
    }


    public void Open(Panel panel)
    {
        if (prefabs[(int)panel] == null)
        {
            prefabs[(int)panel] = Instantiate(Resources.Load<GameObject>(panel.ToString()));
        }
        else
        {
            prefabs[(int)panel].SetActive(true);
        }
     
    }
  
}
