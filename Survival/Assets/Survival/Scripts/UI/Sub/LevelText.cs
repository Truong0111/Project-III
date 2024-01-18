using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class LevelText : MonoBehaviour
{
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent loseEvent;
    [SerializeField] private VoidEvent winEvent;
    [SerializeField] private VoidEvent menuEvent;

    [SerializeField] private VoidEvent levelUpEvent;
    [SerializeField] private TextMeshProUGUI levelText;

    private Hero _hero => GameController.Instance.Hero;

    private void Awake()
    {
        startGameEvent.Register(ShowLevelText);
        loseEvent.Register(HideLevelText);
        winEvent.Register(HideLevelText);
        menuEvent.Register(HideLevelText);
        levelUpEvent.Register(UpdateLevelText);
        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        startGameEvent.Unregister(ShowLevelText);
        loseEvent.Unregister(HideLevelText);
        winEvent.Unregister(HideLevelText);
        menuEvent.Unregister(HideLevelText);
        levelUpEvent.Unregister(UpdateLevelText);
    }

    private void UpdateLevelText()
    {
        levelText.text = $"Level {_hero.Level}";
    }

    private void ShowLevelText() => gameObject.SetActive(true);
    private void HideLevelText() => gameObject.SetActive(false);
}
