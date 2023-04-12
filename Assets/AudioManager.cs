using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{
    [SerializeField] private AudioSO     audioSO;
    [SerializeField] private AudioSource soundSource, musicSource;

    private const string SOUND = "Sound";
    private const string MUSIC = "Music";

    private void Start()
    {
        this.audioSO.Toggle(AudioType.Sound, PlayerPrefs.GetInt(SOUND, 1) == 1);
        this.audioSO.Toggle(AudioType.Music, PlayerPrefs.GetInt(MUSIC, 1) == 1);
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

    public void Toggle(AudioType type)
    {
        string AUDIO = type == AudioType.Sound ? SOUND : MUSIC;
        bool isOn = Mathf.Abs(PlayerPrefs.GetInt(AUDIO, 1) - 1) == 1;
        audioSO.Toggle(type, isOn);
        PlayerPrefs.SetInt(AUDIO, isOn ? 1 : 0);
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
