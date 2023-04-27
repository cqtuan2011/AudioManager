using UnityEngine;

public abstract class Audio
{
    [Range(0.0f, 1.0f)]
    public float DefaultVolume = 1;

    [Range(0.0f, 1.0f)]
    public float Volume = 1;

    public AudioClip Clip;
}
