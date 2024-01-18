using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShowUI : MonoBehaviour
{
    [SerializeField] private Image imageWeapon;
    [SerializeField] private TextMeshProUGUI levelWeaponText;
    [ShowInInspector] public WeaponSpawner WeaponSpawner { get; set; }
    
    public void UpdateWeaponShowUI()
    {
        imageWeapon.sprite = WeaponSpawner.WeaponValue.sprite;
        levelWeaponText.text = WeaponSpawner.WeaponValue.level.ToString();
    }

    private void Update()
    {
        UpdateWeaponShowUI();
    }
}
