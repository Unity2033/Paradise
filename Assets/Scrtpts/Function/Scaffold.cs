using UnityEngine;

public class Scaffold : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy Zone"))
        {
            transform.GetChild(0).GetComponent<Item>().ProbabilityActivation(Random.Range(0, 100));

            ScaffoldManager.instance.Position(ScaffoldManager.instance.scaffoldNumber - 7);
        }        
    }
}
