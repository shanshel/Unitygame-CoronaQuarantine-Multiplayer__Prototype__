﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIInGameCanvas : MonoBehaviour
{
    private static UIInGameCanvas _instance;
    public static UIInGameCanvas _inst { get { return _instance; } }

    public Slider uiHealthSlider;

    Tweener uiHealthIncreaseTween, uiHealthDecreaseTween;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        uiHealthIncreaseTween = uiHealthSlider.transform.DOShakeScale(.5f, .4f, 4, 45).SetAutoKill(false).SetId("uiHealth_Increase");
        uiHealthDecreaseTween = uiHealthSlider.transform.DOShakeScale(.5f, .4f, 9, 70).SetAutoKill(false).SetId("uiHealth_Decrease");
    }

    public void healthIncrease(int newAmount, int maxValue)
    {
        uiHealthSlider.maxValue = maxValue;
        uiHealthSlider.value = newAmount;
        uiHealthIncreaseTween.Restart();
    }

    public void healthDecrease(int newAmount, int maxValue)
    {
        uiHealthSlider.maxValue = maxValue;
        uiHealthSlider.value = newAmount;
        uiHealthDecreaseTween.Restart();
    }
}
