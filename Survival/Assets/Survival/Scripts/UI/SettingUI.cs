using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    [Title("Toggle")] 
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle damageTextToggle;

    [Title("SO")] 
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private VoidEvent settingEvent;

    [Title("Button")] 
    [SerializeField] private Button backToMenuButton;

    private void Awake()
    {
        settingEvent.Register(ShowSettingUI);
        
        backToMenuButton.onClick.AddListener(HideSettingUI);
        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        settingEvent.Unregister(ShowSettingUI);
    }

    private void Start()
    {
        
    }

    private void ShowSettingUI()
    {
        gameObject.SetActive(true);
    }
    
    private void HideSettingUI()
    {
        menuEvent.Raise();
        gameObject.SetActive(false);
    }
}
