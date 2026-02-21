using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Mixer")]
    public AudioMixer mainMixer;

    [Header("Zrodla Dzwieku")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Klipy Audio (Ambient)")]
    public AudioClip ambientClip;
    
    private bool isMusicPlaying = false;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (ambientClip != null)
        {
            PlayMusic(ambientClip);
        }
    }


    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
        isMusicPlaying = true;
    }

    public void StopMusic()
    {
        musicSource.Stop();
        isMusicPlaying = false;
    }

    public bool RestoreMusic()
    {
        if (isMusicPlaying) return false;
        
        if (musicSource.clip == null) return false;
        
        musicSource.loop = true;
        musicSource.Play();
        
        return true;
    }

    public bool IsMusicPlaying()
    {
        return isMusicPlaying;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }


    public void SetMusicVolume(float sliderValue)
    {
        float volume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        mainMixer.SetFloat("MusicVol", volume);
    }

    public void SetSFXVolume(float sliderValue)
    {
        float volume = Mathf.Log10(Mathf.Clamp(sliderValue, 0.0001f, 1f)) * 20;
        mainMixer.SetFloat("SFXVol", volume);
    }
}