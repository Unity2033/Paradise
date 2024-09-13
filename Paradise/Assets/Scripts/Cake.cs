using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    [SerializeField] Material material;

    public void ChangeMaterial()
    {
        gameObject.GetComponent<Renderer>().material = material;
    }
}
