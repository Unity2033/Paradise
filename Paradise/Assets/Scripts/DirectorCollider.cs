using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DirectorCollider : MonoBehaviour
{
    [SerializeField] Crawler crawler;
    private WaitForSeconds waitForSeconds = new WaitForSeconds(3.5f);

    private void OnTriggerEnter(Collider other)
    {
        MovePlayer player = other.GetComponent<MovePlayer>();

        if (player != null)
        {
            player.transform.rotation = Quaternion.identity;

            Camera.main.transform.rotation = Quaternion.Euler(0, -90, 0);

            player.GetComponent<Rigidbody>().Sleep();

            crawler.enabled = true;
            crawler.GetComponent<AudioSource>().Play();

            GameManager.Instance.State = false;

            StartCoroutine(Production());
        }
    }

    private IEnumerator Production()
    {
        yield return waitForSeconds;

        StartCoroutine(FadeManager.Instance.GameEnd());
    }

}
