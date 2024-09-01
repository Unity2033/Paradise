using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] float speed = 2.5f;
    [SerializeField] float degree;

    void Start()
    {
        degree = 0;
    }

    void Update()
    {
        degree += speed * Time.deltaTime;

        if (degree >= 360)
            degree = 0;

        RenderSettings.skybox.SetFloat("_Rotation", degree);
    }
}
