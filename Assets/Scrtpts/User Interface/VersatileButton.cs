using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class VersatileButton : MonoBehaviour
{
    [SerializeField] Transform parentPosition;
    [SerializeField] Sprite [] sprite;
    private List<GameObject> button = new List<GameObject>();

    private void Start()
    {
        
    }

    private void CreateButton(int createCount)
    {
        for(int i = 0; i < createCount; i++ )
        {
            GameObject buttonPrefab = Instantiate(Resources.Load<GameObject>("Versatile Button"));

            button.Add(buttonPrefab);
            button[i].GetComponent<Image>().sprite = sprite[i];
        }

    }

}
