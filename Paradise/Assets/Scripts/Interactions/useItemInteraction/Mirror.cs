using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : Interaction
{
    string item = "Towel";

    [SerializeField] GameObject tower;
    [SerializeField] AudioClip eraseAudioClip;

    private void Start()
    {
        eraseAudioClip = AudioManager.Instance.GetAudioClip("Erase");
    }

    public override void OnClick(Collider blood)
    {
        if (Inventory.Instance.UseItem(item))
        {
            AudioManager.Instance.Sound(eraseAudioClip);

            StartCoroutine(Erase());
        }
    }

    public IEnumerator Erase()
    {
        tower.SetActive(true);

        yield return new WaitForSeconds(tower.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);

        Destroy(tower);

        Destroy(gameObject);
    }
}
