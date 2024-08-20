using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DoorChangeColor : MonoBehaviour
{
    [SerializeField] List<Color> colors;

    WaitForSeconds delay;
    WaitForSeconds totalDelay;

    void Start()
    {
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        delay = new WaitForSeconds(0.5f);
        totalDelay = new WaitForSeconds(2f);

        while (true)
        {
            for (int i = 0; i < colors.Count; i++)
            {
                gameObject.GetComponent<Renderer>().material.color = colors[i];

                yield return delay;
            }

            gameObject.GetComponent<Renderer>().material.color = Color.clear;

            yield return totalDelay;
        }
    }
}
