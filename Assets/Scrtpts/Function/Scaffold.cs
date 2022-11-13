using UnityEngine;
using System.Collections;

public class Scaffold : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(StepAniamtion());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy Zone"))
        {
            transform.GetChild(0).GetComponent<Item>().ProbabilityActivation(Random.Range(0, 100));
            ScaffoldManager.Instance.Position(ScaffoldManager.Instance.scaffoldNumber - 7);
        }        
    }

    private IEnumerator StepAniamtion()
    {    
        transform.position = new Vector3
        (
              transform.position.x,
              transform.position.y - 0.1f,
              transform.position.z
        );

        yield return null;

        transform.position = new Vector3
        (
             transform.position.x,
             transform.position.y + -0.1f,
             transform.position.z
        );
    }
}
