using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    private void Start()
    {
        Scenery("Scenery");
    }

    public void Scenery(string soundName)
    {
        scenerySource.clip = Resources.Load<AudioClip>(soundName);

        scenerySource.loop = true;
        scenerySource.Play();
    }

    public void Sound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public AudioClip GetAudioClip(string soundName)
    {
        return Resources.Load<AudioClip>(soundName);
    }
}
