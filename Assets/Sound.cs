using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    Unknown,
    UIButtonClick,
    CoinReward,
    CoinSpend,
    Walking,
    Win,
    Lose,

}

[System.Serializable]
public class Sound : Audio
{
    public SoundType Type;
}
