using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DirectorCollider : MonoBehaviour
{
    [SerializeField] Zombie zombie;
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();

        if (player != null)
        {
            player.transform.rotation = Quaternion.identity;
            Camera.main.transform.rotation = Quaternion.Euler(0, -90, 0);

            player.GetComponent<Rigidbody>().Sleep();

            GameManager.Instance.State = false;

            animator.Play("Fall Down");
            
            zombie.Move();

            AudioManager.Instance.Scenery("Ending");
        }
    }

}
