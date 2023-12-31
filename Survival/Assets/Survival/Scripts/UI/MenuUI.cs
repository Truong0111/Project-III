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
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private VoidEvent powerUpEvent;
    [SerializeField] private VoidEvent settingEvent;
    [SerializeField] private VoidEvent quitEvent;
    [SerializeField] private VoidEvent creditEvent;

    private void Awake()
    {
        menuEvent.Register(ShowMenuUI);
        
        startButton.onClick.AddListener(StartGame);
        powerUpButton.onClick.AddListener(PowerUp);
        settingButton.onClick.AddListener(Setting);
        quitButton.onClick.AddListener(Quit);
        creditButton.onClick.AddListener(Credit);
    }

    private void OnDestroy()
    {
        menuEvent.Unregister(ShowMenuUI);
    }

    private void StartGame()
    {
        startEvent.Raise();
        HideMenuUI();
    }

    private void PowerUp()
    {
        powerUpEvent.Raise();
        HideMenuUI();
    }

    private void Setting()
    {
        settingEvent.Raise();
        HideMenuUI();
    }

    private void Quit()
    {
        quitEvent.Raise();
        HideMenuUI();
    }

    private void Credit()
    {
        creditEvent.Raise();
        HideMenuUI();
    }

    private void ShowMenuUI()
    {
        gameObject.SetActive(true);
    }

    private void HideMenuUI()
    {
        gameObject.SetActive(false);
    }
}
