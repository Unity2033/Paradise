using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float speed;
    [SerializeField] AudioClip audioClip;

    [SerializeField] Vector3 initializeDirection;

    private float x;
    private float z;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initializeDirection = transform.position;
    }

    void Update()
    {
        if (GameManager.Instance.State == false) return;

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.forward * z + transform.right * x;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.Scenery("Scenery");
        
            GameManager.Instance.State = false;
        
            rigidbody.freezeRotation = true;
        
            CursorManager.ActiveMouse(true, CursorLockMode.None);
        
            StartCoroutine(FadeManager.Instance.FadeOut());
        
            DataManager.Instance.SetTransform(transform.position, transform.rotation);
        
            DataManager.Instance.Save();
        }

        rigidbody.velocity = direction * speed;
    }

    public void ResetTransform()
    {
        transform.position = initializeDirection;
    }
}
