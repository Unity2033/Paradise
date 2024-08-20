using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorChangeColor : MonoBehaviour
{
    [SerializeField] List<Color> colors = new List<Color>();
    [SerializeField] Material material;

    WaitForSeconds delay;
    WaitForSeconds totalDelay;

    void Start()
    {
        colors.Add(Color.yellow);   
        colors.Add(Color.red);
        colors.Add(new Color(0f, 97f / 255, 255f / 255));  //ÇÏ´Ã
        colors.Add(new Color(255f / 255, 0, 206f / 255)); // ºÐÈ«
        colors.Add(Color.black);   
        colors.Add(new Color(0, 31f / 255, 93f / 255));   // ³²»ö
        colors.Add(Color.white);
        colors.Add(Color.green);
        colors.Add(new Color(255f / 255, 117f / 255, 0)); // ÁÖÈ²

        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        delay = new WaitForSeconds(0.5f);
        totalDelay = new WaitForSeconds(1.5f);

        while(true)
        {
            for(int i = 0; i < colors.Count; i++)
            {
                yield return delay;

                material.color = colors[i];
            }

            yield return totalDelay;
        }
    }
}
