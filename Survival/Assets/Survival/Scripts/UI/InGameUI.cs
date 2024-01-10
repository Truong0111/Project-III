using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    private void Awake()
    {
        startGameEvent.Register(ShowInGameUI);
    }

    private void OnDestroy()
    {
        startGameEvent.Unregister(ShowInGameUI);
    }

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGameEvent.Raise();
        }
    }

    private void ShowInGameUI()
    {
        gameObject.SetActive(true);
    }
}
