using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    public Animator animator;

    private Rigidbody rigidBody;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameManager.Instance.State == GameManager.state.Exit)
        {
            rigidBody.useGravity = true;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            GameManager.Instance.StateCanvas();
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.State == GameManager.state.Progress)
        {
            if (other.CompareTag("Scaffold"))
            {
                DataManager.Instance.CurrentScore++;
                DataManager.Instance.BestScore();

                DataManager.Instance.Save();
            }
        }

        Invoke(nameof(FalseAnimation), 0.05f);
    }

    void FalseAnimation()
    {
        animator.SetBool("Jump", false);

    }
}
