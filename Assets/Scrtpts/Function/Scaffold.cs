using UnityEngine;

public class Scaffold : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destroy Zone"))
        {
            ScaffoldManager.instance.Position(ScaffoldManager.instance.scaffoldNumber - 5);
        }        
    }
}
