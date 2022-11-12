using UnityEngine;
using System.Collections;

public class SpaceShip : MonoBehaviour
{
    public Animator animator;

    private Rigidbody rigidBody;
    [SerializeField] ParticleSystem particle;

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
                particle.Play();

                DataManager.Instance.CurrentScore++;
                DataManager.Instance.BestScore();

                DataManager.Instance.Save();

                StartCoroutine(DelayAnimation());
            }
        }   
    }

    private IEnumerator DelayAnimation()
    {
        WaitForSeconds chaceSeconds = new WaitForSeconds(0.1f);

        yield return chaceSeconds;
        animator.SetBool("Jump", false);
    }

    
}
