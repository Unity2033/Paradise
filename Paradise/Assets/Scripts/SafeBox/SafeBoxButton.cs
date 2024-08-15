using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeBoxButton : MonoBehaviour
{
    [SerializeField] Text safeNumber;
    Text safeNumberUI;

    private void Start()
    {
        safeNumberUI = GetComponent<Text>();
    }

    public void OnUpButton()
    {
        safeNumberUI.text = ((int.Parse(safeNumberUI.text) + 1) % 10).ToString();

        safeNumber.text = safeNumberUI.text;
    }

    public void OnDownButton()
    {
        safeNumberUI.text = ((int.Parse(safeNumberUI.text) + 9) % 10).ToString();

        safeNumber.text = safeNumberUI.text;
    }
}
