using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioDemo : MonoBehaviour
{
    [SerializeField] private Button coin;
    [SerializeField] private Button win;
    [SerializeField] private Button lose;

    [SerializeField] private ToggleButton soundToggle;


    private void Start()
    {
        coin.onClick.AddListener(HandleCoinButtonPress);
        win .onClick.AddListener(HandleWinButtonPress);
        lose.onClick.AddListener(HandleLoseButtonPress);

        soundToggle.Init(AudioManager.Instance.IsSoundOn, HandleSoundToggleButtonPress);
    }

    private void HandleCoinButtonPress()
    {
        AudioManager.Instance.PlaySound(SoundType.CoinReward);
    }

    private void HandleWinButtonPress()
    {
        AudioManager.Instance.PlaySound(SoundType.Win);
    }

    private void HandleLoseButtonPress()
    {
        AudioManager.Instance.PlaySound(SoundType.Lose);
    }

    private void HandleSoundToggleButtonPress()
    {
        bool isOn = AudioManager.Instance.Toggle(AudioType.Sound);
        soundToggle.OnCick(isOn);
    }
}
