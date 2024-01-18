using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [Title("Event")]
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent menuEvent;

    [SerializeField] private GameObject pauseButton;
    private void Awake()
    {
        startGameEvent.Register(ShowInGameUI);
        menuEvent.Register(HideGameUI);
    }
    
    private void OnDestroy()
    {
        startGameEvent.Unregister(ShowInGameUI);
        menuEvent.Unregister(HideGameUI);
    }

    private void Start()
    {
        pauseButton.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseGameEvent.Raise();
    }

    private void ShowInGameUI()
    {
        gameObject.SetActive(true);
        pauseButton.SetActive(true);
    }

    private void HideGameUI()
    {
        pauseButton.SetActive(false);
    }
}
