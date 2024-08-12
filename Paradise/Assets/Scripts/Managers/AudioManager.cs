using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Sound
{ 
    Scenery,
}


public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] Sound sound;
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    // protected override void Awake()
    // {
    //     // effectSource = transform.GetChild(0).GetComponent<AudioSource>();
    //     // scenerySource = transform.GetChild(1).GetComponent<AudioSource>();
    // }

    public void Sound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sound = (Sound)scene.buildIndex;

        scenerySource.clip = Resources.Load<AudioClip>(sound.ToString());

        scenerySource.loop = true;
        scenerySource.Play();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
