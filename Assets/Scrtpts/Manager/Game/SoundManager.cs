using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip [] soundEffect;

    public void Sound(int count)
    {
        audioSource.PlayOneShot(soundEffect[count]);
    }  
}
