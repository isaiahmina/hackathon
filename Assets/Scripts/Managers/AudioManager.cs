using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour, IGameManager
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioSource music1Source;
    [SerializeField] private AudioSource music2Source;

    [SerializeField] private string introBGMusic;
    [SerializeField] private string levelBGMusic;

    private AudioSource _activeMusic;
    private AudioSource _inactiveMusic;

    public float crossFadeRate = 1.5f;
    private bool _crossFading;

    private float _musicvolume;
    public float musicVolume
    {
        get { return _musicvolume; }
        set
        {
            _musicvolume = value;
            if (music1Source != null && !_crossFading)
            {
                music1Source.volume = _musicvolume;
                music2Source.volume = _musicvolume;
            }
        }
    }

    public void PlayIntroMusic()
    {
        PlayMusic(Resources.Load("Music/" + introBGMusic) as AudioClip);
    }
    public void PlayLevelMusic()
    {
        PlayMusic(Resources.Load("Music/" + levelBGMusic) as AudioClip);
    }
    private void PlayMusic(AudioClip clip)
    {
        if (_crossFading) { return; }
        StartCoroutine(CrossFadeMusic(clip));
        
        //music1Source.clip = clip;
        //music1Source.Play();
    }
    public void StopMusic()
    {
        _activeMusic.Stop();
        _inactiveMusic.Stop();
    }

    public ManagerStatus status { get; private set; }


    public void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
    public float soundVolume
    {
        get { return AudioListener.volume; }
        set { AudioListener.volume = value; }
    }
    public bool soundMute
    {
        get { return AudioListener.pause; }
        set { AudioListener.pause = value; }
    }
    public bool musicMute
    {
        get
        {
            if (music1Source != null)
            {
                return music1Source.mute;
            }
            return false;
        }
        set
        {
            if (music1Source != null)
            {
                music1Source.mute = value;
                music2Source.mute = value;
            }
        }
    }

    public void Startup()
    {
        music1Source.ignoreListenerVolume = true;
        music1Source.ignoreListenerPause = true;
        music2Source.ignoreListenerVolume = true;
        music2Source.ignoreListenerPause = true;

        soundVolume = 1f;
        musicVolume = 1f;

        _activeMusic = music1Source;
        _inactiveMusic = music2Source;

        status = ManagerStatus.Started;
    }
    private IEnumerator CrossFadeMusic(AudioClip clip)
    {
        _crossFading = true;

        _inactiveMusic.clip = clip;
        _inactiveMusic.volume = 0;
        _inactiveMusic.Play();

        float scaledRate = crossFadeRate * _musicvolume;
        while (_activeMusic.volume > 0)
        {
            _activeMusic.volume -= scaledRate * Time.deltaTime;
            _inactiveMusic.volume += scaledRate * Time.deltaTime;

            yield return null;

        }
        AudioSource temp = _activeMusic;

        _activeMusic = _inactiveMusic;
        _activeMusic.volume = _musicvolume;

        _inactiveMusic = temp;
        _inactiveMusic.Stop();

        _crossFading = false;
    }
}
