using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    [SerializeField] float speed = 3.5f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
