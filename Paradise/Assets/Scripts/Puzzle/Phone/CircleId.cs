using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleId : MonoBehaviour
{
    [SerializeField] Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }
    public int id;

    public void ImageChange(Color color)
    {
        image.color = color;
    }
}
