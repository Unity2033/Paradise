using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Scaffold"))
            {
                animator.SetBool("Jump", false);

                DataManager.Instance.CurrentScore++;
                DataManager.Instance.BestScore();

                DataManager.Instance.Save();
            }
    }
}
