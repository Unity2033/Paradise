using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : Interaction
{
    [SerializeField] GameObject ovenDoor;
    
    [SerializeField] public GameObject cakes;
    
    [SerializeField] Material fire;

    float initialTime;
    float time = 3f;

    float red;
    float maxRed = 0.85f;

    Color color;

    WaitForSeconds waitForSeconds = new WaitForSeconds(3f);

    private void Start()
    {
        ovenDoor = transform.parent.Find("Oven Door").gameObject;
    }
    
    public override void OnClick(Collider ovenButton)
    {
        if (ovenDoor.GetComponent<Door_Oven>().isOpen == true) return;

        ovenDoor.layer = 0;

        StartCoroutine(RaiseTheTemperature());
    }

    IEnumerator RaiseTheTemperature()
    {
        initialTime = 0;

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

        ovenDoor.layer = 8;
    }
}
