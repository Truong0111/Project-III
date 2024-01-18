using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField] private VoidEvent winEvent;
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private Button backToMenuButton;

    private void Awake()
    {
        winEvent.Register(ShowWinUI);
        
        backToMenuButton.onClick.AddListener(BackToMenu);
        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        winEvent.Unregister(ShowWinUI);
    }

    private void ShowWinUI()
    {
        gameObject.SetActive(true);
    }

    private void BackToMenu()
    {
        menuEvent.Raise();
        gameObject.SetActive(false);
    }
}
