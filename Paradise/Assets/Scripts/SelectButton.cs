using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] GameObject prefab;

    void Start()
    {
        button = GetComponent<Button>(); 
    }

    public void Enter()
    {
        if(button.IsInteractable())
        {
            prefab.SetActive(true);
        }
    }

    public void Select()
    {
        prefab.SetActive(false);
    }
}
