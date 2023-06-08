using UnityEngine;

public enum SoundType
{ 
    Move,
    Open,
    Collision,
    Start,
    Select,
    Click
}


public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip [] soundEffect;

    public void Sound(SoundType soundType)
    {
        audioSource.PlayOneShot(soundEffect[(int)soundType]);
    }  
}
