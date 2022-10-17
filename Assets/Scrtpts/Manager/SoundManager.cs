using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource auido;

    public AudioClip[] Sound_Effect;

    public static SoundManager instance; 

    private void Awake() 
    {
        if (instance == null) // Sound_Manager 값이 없다면
            instance = this; // Sound_Manager.instance에 자기 자신을 넣습니다.
        else if (instance != this)
            Destroy(this.gameObject);

        DontDestroyOnLoad(auido);
    }

    void Start()
    {
        auido = GetComponent<AudioSource>();
    }

    public void Sound(int count)
    {
        auido.PlayOneShot(Sound_Effect[count]);
    }  
}
