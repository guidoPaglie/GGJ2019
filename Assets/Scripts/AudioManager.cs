using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private readonly Dictionary<string, AudioClip> AudioClipsByIds = new Dictionary<string, AudioClip>();
    
    public static AudioManager Instance;

    public AudioSource MusicAudioSource;
    public AudioClip IntroMusic;
    public AudioClip GameMusic;

    public AudioSource StepsAudioSource;
    
    public AudioSource FxAudioSource;
    public List<AudioClip> FxAudioClips;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        ConfigureFxs();

        DontDestroyOnLoad(gameObject);

        Instance = this;
    }

    private void ConfigureFxs()
    {
        FxAudioClips.ForEach(clip =>
        {
            var id = clip.name.Replace("_SFX", "").ToLower();
            AudioClipsByIds.Add(id, clip);
        });
    }

    public void PlaySound(string id)
    {
        Instance.Play(id);
    }

    public void PlaySteps()
    {
        StepsAudioSource.Play();
    }

    public void PlayMusic(bool isIntro)
    {
        MusicAudioSource.clip = isIntro ? IntroMusic : GameMusic;
        MusicAudioSource.Play();
    }

    private void Play(string id)
    {
        var clip = AudioClipsByIds[id];
        if (clip == null)
        {
            Debug.LogError("Audio with id " + id + " not found");
            return;
        }

        FxAudioSource.clip = clip;
        FxAudioSource.Play();
    }
}