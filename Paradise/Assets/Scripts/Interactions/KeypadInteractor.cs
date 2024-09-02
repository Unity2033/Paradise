using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadInteractor : MonoBehaviour
{
    [SerializeField] Text text;

    [SerializeField] Camera camera;

    float distance = 1f;

    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, distance))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (text.text.Length < 6 && hit.collider.gameObject.CompareTag("Number"))
                { text.text += hit.collider.gameObject.name; }
                else if (hit.collider.gameObject.CompareTag("Enter"))
                {
                    
                }
            }
        }
        
    }
}
