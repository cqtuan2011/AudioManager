using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Button thisButton;
    [SerializeField] private Image  buttonImage;

    [SerializeField] private Sprite switchOn;
    [SerializeField] private Sprite switchOff;

    public void Init(bool value, Action onClick)
    {
        UpdateButtonSprite(value);

        thisButton.onClick.AddListener(() =>
        {
            onClick?.Invoke();
        });
    }

    public void OnCick(bool value)
    {
        UpdateButtonSprite(value);
    }

    public void UpdateButtonSprite(bool value)
    {
        buttonImage.sprite = value ? switchOn : switchOff;
    }
}
