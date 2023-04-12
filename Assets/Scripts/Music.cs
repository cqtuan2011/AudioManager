using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType
{
    Unknown,
    Bgm1,
    Bgm2,
    Bgm3,
    Indoor,
    OutDoor,

}

[System.Serializable]
public class Music : Audio
{
    public MusicType Type;
}
