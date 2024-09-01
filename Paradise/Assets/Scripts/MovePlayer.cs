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
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;

            return;
        }

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");

        if (direction == Vector3.zero)
        {       
            rigidBody.constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rigidBody.constraints =  RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }

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
