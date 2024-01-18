using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShowUI : MonoBehaviour
{
    [SerializeField] private VoidEvent menuEvent;
    [SerializeField] private Image imageWeapon;
    [SerializeField] private TextMeshProUGUI levelWeaponText;
    [ShowInInspector] public WeaponSpawner WeaponSpawner { get; set; }

    private void Awake()
    {
        menuEvent.Register(DestroyWeaponShow);
    }

    private void OnDestroy()
    {
        menuEvent.Unregister(DestroyWeaponShow);
    }

    private void DestroyWeaponShow()
    {
        Destroy(gameObject);
    }
    
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
