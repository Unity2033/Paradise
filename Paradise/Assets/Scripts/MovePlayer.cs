using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float speed;
    [SerializeField] AudioClip audioClip;

    private float x;
    private float z;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 direction = transform.forward * z + transform.right * x;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CursorManager.ActiveMouse(true, CursorLockMode.None);

            StartCoroutine(FadeManager.Instance.FadeOut());

            DataManager.Instance.SetTransform(transform.position, transform.rotation);

            DataManager.Instance.Save();
        }

        rigidbody.velocity = direction * speed;
    }
}
