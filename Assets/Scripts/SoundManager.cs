using UnityEngine.Audio;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public static AudioClip jingle, death;
    static AudioSource audioSrc;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        jingle = Resources.Load<AudioClip>("Audio/jingle");
        death = Resources.Load<AudioClip>("Audio/death");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jingle":
                audioSrc.PlayOneShot(jingle);
                break;
            case "death":
                audioSrc.PlayOneShot(death);
                break;
        }
    }
}