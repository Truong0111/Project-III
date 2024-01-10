using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : Singleton<HealthBar>
{
    [SerializeField] private Image heathImage;
    [SerializeField] private FloatEvent playerHeathChangeEvent;
    
    public float PlayerHealth { get; set; }
    public float PlayerMaxHealth { get; set; }
    private void Awake()
    {
        playerHeathChangeEvent.Register(UpdateHeathBar);
    }

    public override void OnDestroy()
    {
        playerHeathChangeEvent.Unregister(UpdateHeathBar);
    }

    private void UpdateHeathBar(float value)
    {
        PlayerHealth += value;
        heathImage.fillAmount = PlayerHealth / PlayerMaxHealth;
    }
}
