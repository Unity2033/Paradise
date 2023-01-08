using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Scaffold"))
        {
            DataManager.Instance.CurrentScore++;
            DataManager.Instance.BestScore();

            DataManager.Instance.Save();
        }
    }
}
