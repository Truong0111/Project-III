using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    [Header("Button")]
    [SerializeField] private Button startButton;
    [SerializeField] private Button powerUpButton;
    [SerializeField] private Button settingButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button creditButton;

    [Header("Event")] 
    [SerializeField] private VoidEvent startEvent;
    [SerializeField] private VoidEvent powerUpEvent;
    [SerializeField] private VoidEvent settingEvent;
    [SerializeField] private VoidEvent quitEvent;
    [SerializeField] private VoidEvent creditEvent;

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
        powerUpButton.onClick.AddListener(PowerUp);
        settingButton.onClick.AddListener(Setting);
        quitButton.onClick.AddListener(Quit);
        creditButton.onClick.AddListener(Credit);
    }

    private void StartGame()
    {
        startEvent.Raise();
    }

    private void PowerUp()
    {
        powerUpEvent.Raise();
    }

    private void Setting()
    {
        settingEvent.Raise();
    }

    private void Quit()
    {
        quitEvent.Raise();
    }

    private void Credit()
    {
        creditEvent.Raise();
    }
}
