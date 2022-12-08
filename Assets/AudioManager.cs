using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    //public static AudioManager Instance;

    private byte _musicNumber = 1;

    private void Awake()
    {
        // if (Instance)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        //
        // Instance = this;
        //
        // DontDestroyOnLoad(gameObject);

        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.minDistance = 100;
        }
    }

    public void Play(string name)
    {
        var s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void PlayNextMusic()
    {
        var s = Array.Find(sounds, sound => sound.name == "music"+_musicNumber.ToString());
        s.source.Stop();
        
        _musicNumber += 1;
        if (_musicNumber > 3) _musicNumber = 1;
        
        s = Array.Find(sounds, sound => sound.name == "music"+_musicNumber.ToString());
        s.source.Play();
    }
}