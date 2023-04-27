using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : BaseManager<AudioManager>
{
    public bool IsSoundOn => isSoundOn();
    public bool IsMusicOn => isMusicOn();

    public float SoundVolume => GetVolume(AudioType.Sound);
    public float MusicVolume => GetVolume(AudioType.Music);

    [SerializeField] private AudioSO     audioSO;
    [SerializeField] private AudioSource soundSource, musicSource;

    private const string SOUND_TOGGLE_KEY = "SoundToggle";
    private const string SOUND_VOLUME_KEY = "SoundVolume";
    private const string MUSIC_TOGGLE_KEY = "MusicToggle";
    private const string MUSIC_VOLUME_KEY = "MusicVolume";

    private void Start()
    {
        //Toggle sound base on PlayerPref in the beginning
        this.audioSO.Toggle(AudioType.Sound, IsSoundOn);
        this.audioSO.Toggle(AudioType.Music, IsMusicOn);

        //Also update the sound volume base on the saved data
        this.audioSO.SetVolume(AudioType.Sound, GetVolume(AudioType.Sound));
        this.audioSO.SetVolume(AudioType.Music, GetVolume(AudioType.Music));
    }

    public void PlaySound(SoundType type)
    {
        Sound sound = this.GetSound(type);

        if (sound != null)
            soundSource.PlayOneShot(sound.Clip, sound.Volume);
    }

    public void PlayMusic(MusicType type)
    {
        Music music        = this.GetMusic(type);
        musicSource.clip   = music.Clip;
        musicSource.volume = music.Volume;
        musicSource.loop   = true;
        musicSource.Play();
    }

    //For slider to register the OnValueChanged call back to this function
    public void OnSoundVolumeChanged(float value)
    {
        audioSO.SetVolume(AudioType.Sound, value);
        PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, value);
    }

    //For slider to register the OnValueChanged call back to this function
    public void OnMusicVolumeChanged(float value)
    {
        audioSO.SetVolume(AudioType.Music, value);
        musicSource.volume = value;
        PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, value);
    }
 
    public bool Toggle(AudioType type)
    {
        string AUDIO       = type == AudioType.Sound ? SOUND_TOGGLE_KEY : MUSIC_TOGGLE_KEY;
        AudioSource source = type == AudioType.Sound ? soundSource      : musicSource;

        bool isOn = Mathf.Abs(PlayerPrefs.GetInt(AUDIO, 1) - 1) == 1;
        audioSO.Toggle(type, isOn);

        source.mute = !isOn;
        PlayerPrefs.SetInt(AUDIO, isOn ? 1 : 0);

        return isOn;
    }

    private bool isSoundOn()
    {
        return PlayerPrefs.GetInt(SOUND_TOGGLE_KEY, 1) == 1;
    }

    private bool isMusicOn()
    {
        return PlayerPrefs.GetInt(MUSIC_TOGGLE_KEY, 1) == 1;
    }

    private Sound GetSound(SoundType type)
    {
        return audioSO.Sounds.Find(s => s.Type.Equals(type));
    }

    private Music GetMusic(MusicType type)
    {
        return audioSO.Musics.Find(s => s.Type.Equals(type));
    }

    private float GetVolume(AudioType type)
    {
        string KEY = type == AudioType.Sound ? SOUND_VOLUME_KEY : MUSIC_VOLUME_KEY;
        return PlayerPrefs.GetFloat(KEY, 1);
    }


}
