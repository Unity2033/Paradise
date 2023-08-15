using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private Vector3 direction;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }

        transform.position += direction * Time.deltaTime;
    }
}
