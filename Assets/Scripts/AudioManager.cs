using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Configurações")]
    public AudioSource efxSource;
    public AudioSource musicSource;

    public AudioClip bgmMenu;
    public AudioClip victory;
    public AudioClip jump;
    public AudioClip collected;
    public AudioClip danger;
    public AudioClip gameOver;

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void ChangeBGM(AudioClip newTrack)
    {
        if (musicSource.clip == newTrack) return;
        musicSource.Stop();
        musicSource.clip = newTrack;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        efxSource.PlayOneShot(clip);
    }
}
