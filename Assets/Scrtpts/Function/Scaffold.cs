using UnityEngine;
using System.Collections;

public class Scaffold : MonoBehaviour
{
    ScaffoldManager scaffoldManager;

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            scaffoldManager = GameObject.Find("Character").GetComponent<ScaffoldManager>();
            StartCoroutine(StepAniamtion());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy Zone"))
        {
            transform.GetChild(0).GetComponent<Item>().ProbabilityActivation(Random.Range(0, 100));
            scaffoldManager = GameObject.Find("Scaffold Manager").GetComponent<ScaffoldManager>();
            scaffoldManager.Position(scaffoldManager.scaffoldNumber - 7);
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
