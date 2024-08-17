using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeManager : MonoBehaviour
{  
    [SerializeField] Interaction [ ] interactionObjects;

    void Awake()
    {
        interactionObjects = FindObjectsOfType<Interaction>();
    }

    public void Initialize()
    {
        foreach (Interaction interaction in interactionObjects)
        {
            if (interaction.State)
            {
                interaction.OnClick(interaction.transform.GetComponentInChildren<Collider>());             
            }
        }
    }
}
