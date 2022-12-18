using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        if (GameManager.Instance.State == GameManager.state.Exit)
        {
            animator.Play("Death Animation");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.State == GameManager.state.Progress)
        {
            if (other.CompareTag("Scaffold"))
            {
                Invoke(nameof(FalseAnimation), 0.05f);

                DataManager.Instance.CurrentScore++;
                DataManager.Instance.BestScore();

                DataManager.Instance.Save();
            }
        }
    }

    void FalseAnimation()
    {
        animator.SetBool("Jump", false);
    }
}
