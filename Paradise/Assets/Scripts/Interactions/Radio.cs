using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interaction
{
    [SerializeField] AudioSource audioSorce;

    private void Start()
    {
        audioSorce = GetComponent<AudioSource>();
    }

    public override void OnClick(Collider radio)
    {
        if (audioSorce.volume == 1) audioSorce.volume = 0;
        else audioSorce.volume = 1;
    }

}
