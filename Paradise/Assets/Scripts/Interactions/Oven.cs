using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Interaction
{
    [SerializeField] public bool isFire = false;

    [SerializeField] GameObject ovenDoor;
    
    [SerializeField] public GameObject cakes;
    
    [SerializeField] Material fire;

    [SerializeField] AudioClip ovenOnButton;
    [SerializeField] AudioClip ovenRunning;
    [SerializeField] AudioClip ovenStopped;

    float initialTime;
    float time = 3f;

    float red;
    float maxRed = 0.85f;

    Color color;

    Coroutine routine;

    WaitForSeconds waitForSeconds = new WaitForSeconds(3f);

    private void Start()
    {
        ovenDoor = transform.parent.Find("Oven Door").gameObject;

        color.r = 0;

        fire.SetColor("_SpecColor", color);

        ovenOnButton = Resources.Load<AudioClip>("Oven Button");
        ovenRunning = Resources.Load<AudioClip>("Oven Running");
        ovenStopped = Resources.Load<AudioClip>("Oven Stopped");
    }
    
    public override void OnClick(Collider ovenButton)
    {
        if (ovenDoor.GetComponent<DoorOven>().isOpen == true) return;

        if (routine != null) return;

        AudioManager.Instance.Sound(ovenOnButton);

        ovenDoor.layer = 0;

        routine = StartCoroutine(RaiseTheTemperature());
    }

    IEnumerator RaiseTheTemperature()
    {
        initialTime = 0;

        AudioManager.Instance.Sound(ovenRunning);

        while (initialTime < time)
        {
            red = Mathf.Lerp(0f, maxRed, initialTime / time);

            color.r = red;

            fire.SetColor("_SpecColor", color);

            initialTime += Time.deltaTime;

            yield return null;
        }

        color.r = maxRed;

        fire.SetColor("_SpecColor", color);

        if (cakes != null) 
        { 
            cakes.BroadcastMessage("ChangeMaterial", SendMessageOptions.DontRequireReceiver);

            isFire = true;

            cakes.layer = 8;
        }

        yield return waitForSeconds;

        StartCoroutine(LowerTheTemperature());
    }

    IEnumerator LowerTheTemperature()
    {
        initialTime = 0;

        while (initialTime < time)
        {
            red = Mathf.Lerp(maxRed, 0f, initialTime / time);

            color.r = red;

            fire.SetColor("_SpecColor", color);

            initialTime += Time.deltaTime;

            yield return null;
        }

        color.r = 0f;

        fire.SetColor("_SpecColor", color);

        AudioManager.Instance.Sound(ovenStopped);

        routine = null;

        ovenDoor.layer = 8;
    }
}
