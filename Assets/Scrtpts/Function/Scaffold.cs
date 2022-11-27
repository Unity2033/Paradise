using UnityEngine;
using System.Collections;

public class Scaffold : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy Zone"))
        {
            transform.GetChild(0).GetComponent<Item>().ProbabilityActivation(Random.Range(0, 100));
            ScaffoldManager.Instance.Position(ScaffoldManager.Instance.scaffoldNumber - 7);
        }        
    }
}
