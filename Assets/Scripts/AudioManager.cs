using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{
    public bool IsSoundOn => isSoundOn();
    public bool IsMusicOn => isMusicOn();

    [SerializeField] private AudioSO     audioSO;
    [SerializeField] private AudioSource soundSource, musicSource;

    private const string SOUND = "Sound";
    private const string MUSIC = "Music";

    private void Start()
    {
        this.audioSO.Toggle(AudioType.Sound, IsSoundOn);
        this.audioSO.Toggle(AudioType.Music, IsMusicOn);
    }

    public void PlaySound(SoundType type)
    {
        Sound sound = this.GetSound(type);
        soundSource.PlayOneShot(sound.Clip, sound.Volume);
    }

    public void PlayMusic(MusicType type)
    {
        Music music = this.GetMusic(type);
        musicSource.volume = music.Volume;
        musicSource.loop = true;
        musicSource.Play();
    }

    public bool Toggle(AudioType type)
    {
        string AUDIO       = type == AudioType.Sound ? SOUND : MUSIC;
        AudioSource source = type == AudioType.Sound ? soundSource : musicSource;

        bool isOn = Mathf.Abs(PlayerPrefs.GetInt(AUDIO, 1) - 1) == 1;
        audioSO.Toggle(type, isOn);

        source.mute = !isOn;
        PlayerPrefs.SetInt(AUDIO, isOn ? 1 : 0);

        return isOn;
    }

    private bool isSoundOn()
    {
        return PlayerPrefs.GetInt(SOUND, 1) == 1;
    }

    private bool isMusicOn()
    {
        return PlayerPrefs.GetInt(MUSIC, 1) == 1;
    }

    private Sound GetSound(SoundType type)
    {
        return audioSO.sounds.Find(s => s.Type.Equals(type));
    }

    private Music GetMusic(MusicType type)
    {
        return audioSO.musics.Find(s => s.Type.Equals(type));
    }


}
