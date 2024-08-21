using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieState
{ 
   IDLE,
   RUN,
   ATTACK
}

public class Zombie : MonoBehaviour
{
    [SerializeField] ZombieState state;
    [SerializeField] Animator animator;
    [SerializeField] float speed = 3.5f;

    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        state = ZombieState.IDLE;
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

        audioSource.mute = true;
    }

    private void Update()
    {
        switch(state)
        {
            case ZombieState.IDLE:
                break;
            case ZombieState.RUN: Move();
                break;
             case ZombieState.ATTACK : Attack();
                break;
        }
    }

    public void Move()
    {
        audioSource.mute = false;

        state = ZombieState.RUN;

        animator.Play("Run");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Attack()
    {
        state = ZombieState.ATTACK;

        animator.SetTrigger("Attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer movePlayer = other.GetComponent<MovePlayer>();

        if (movePlayer != null)
        {
            audioSource.mute = true;
            Attack();
        }
    }
}
