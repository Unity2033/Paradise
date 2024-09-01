using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] Vector3 direction;
    [SerializeField] Rigidbody rigidBody;


    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.Instance.State == false)
        {
            rigidBody.freezeRotation = true;
            return;
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AudioManager.Instance.Scenery("Scenery");
        
            GameManager.Instance.State = false;

            CursorManager.ActiveMouse(true, CursorLockMode.None);
        
            StartCoroutine(FadeManager.Instance.FadeOut());
        }
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + transform.TransformDirection(direction) * speed * Time.deltaTime);
    }
}
