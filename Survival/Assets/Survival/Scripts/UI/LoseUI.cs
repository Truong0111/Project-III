using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class LoseUI : MonoBehaviour
{
    [SerializeField] private VoidEvent loseEvent;
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private Button backToMenuButton;

    private void Awake()
    {
        loseEvent.Register(ShowLoseUI);
        
        backToMenuButton.onClick.AddListener(BackToMenu);
        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        loseEvent.Unregister(ShowLoseUI);
    }

    private void ShowLoseUI()
    {
        gameObject.SetActive(true);
    }

    private void BackToMenu()
    {
        menuEvent.Raise();
        gameObject.SetActive(false);
    }
}
