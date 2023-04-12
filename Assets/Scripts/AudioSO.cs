using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum AudioType
{
    Sound,
    Music,
}

[CreateAssetMenu(fileName = "AudioSO", menuName = "ScriptableObjects/AudioSO")]
public class AudioSO : ScriptableObject
{
    public List<Sound> sounds;
    public List<Music> musics;

    public void Toggle(AudioType type, bool isOn)
    {
        switch (type)
        {
            case AudioType.Sound:
                this.Toggle(sounds, isOn);
                break;

            case AudioType.Music:
                this.Toggle(musics, isOn);
                break;
        }
    }

    private void Toggle<T>(List<T> audios, bool isOn) where T : Audio
    {
        foreach (var audio in audios)
        {
            audio.Volume = isOn ? audio.DefaultVolume : 0;
        }
    }
}
