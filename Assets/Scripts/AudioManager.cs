using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _audioManagerInstance;
    
    public AudioSource MusicAudioSource;
    public AudioSource FxAudioSource;

    public List<AudioClip> AudioClips;

    private Dictionary<string, AudioClip> AudioClipsByIds;
    
    private void Awake()
    {
        ConfigureMap();        
        
        DontDestroyOnLoad(gameObject);

        _audioManagerInstance = this;
    }

    private void ConfigureMap()
    {
        AudioClips.ForEach(clip =>
        {
            var id = clip.name.Replace("_SFX", "");
            AudioClipsByIds.Add(id, clip);
        });
    }

    public static void PlaySound(string id)
    {
        _audioManagerInstance.Play(id);
    }

    private void Play(string id)
    {
        var clip = AudioClipsByIds[id];
        if (clip == null)
            return;
        
        FxAudioSource.clip = clip;
        FxAudioSource.Play();
    }
}
