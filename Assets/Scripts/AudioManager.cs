using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private readonly Dictionary<string, AudioClip> AudioClipsByIds = new Dictionary<string, AudioClip>();

    public List<AudioSource> audioSources;
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

        for (int i = 0; i < 8; i++) {
            audioSources.Add(gameObject.AddComponent<AudioSource>());
        }
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
        Instance.Play(id.ToLower());
    }

    public void PlaySteps()
    {
        StepsAudioSource.Play();
    }

    public void PlayMusic(MusicType type)
    {
        switch (type)
        {
            case MusicType.INTRO:
                MusicAudioSource.clip = IntroMusic;
                break;
            case MusicType.GAME:
                MusicAudioSource.clip = GameMusic;
                break;
        }
        
        MusicAudioSource.Play();
    }

    public enum MusicType
    {
        INTRO,
        GAME
    }

    private void Play(string id)
    {
        var clip = AudioClipsByIds[id];
        if (clip == null)
        {
            Debug.LogError("Audio with id " + id + " not found");
            return;
        }

        var audioSource = GetFreeAudioSource();
        audioSource.clip = clip;
        audioSource.Play();
    }

    AudioSource GetFreeAudioSource() {
        return audioSources.First(audioSource => !audioSource.isPlaying);
    }

    public void PauseMusic()
    {
        MusicAudioSource.Pause();
    }

    public void OnResumeMusic()
    {
        MusicAudioSource.Play();
    }
}