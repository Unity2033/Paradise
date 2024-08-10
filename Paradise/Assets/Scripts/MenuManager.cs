using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] string [] buttonNames;
    [SerializeField] SelectButton [] buttons; 

    void Start()
    {
        for(int i = 0; i < buttonNames.Length; i++)
        {
            buttons[i].GetComponentInChildren<Text>().text = buttonNames[i];
        }
    }
}
