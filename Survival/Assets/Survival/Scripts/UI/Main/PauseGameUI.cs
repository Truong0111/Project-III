using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameUI : MonoBehaviour
{
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent resumeEvent;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button backToMenuButton;

    private void Awake()
    {
        menuEvent.Raise();
        pauseGameEvent.Register(ShowPauseGameUI);
        
        resumeButton.onClick.AddListener(Resume);
        backToMenuButton.onClick.AddListener(BackToMenu);
        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        pauseGameEvent.Unregister(ShowPauseGameUI);
    }

    private void ShowPauseGameUI()
    {
        gameObject.SetActive(true);
    }

    private void Resume()
    {
        resumeEvent.Raise();
        gameObject.SetActive(false);
    }

    private void BackToMenu()
    {
        menuEvent.Raise();
        gameObject.SetActive(false);
    }
}
