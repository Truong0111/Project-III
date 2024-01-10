using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChooseWeaponButton : MonoBehaviour
{
    [SerializeField] private WeaponSo weaponSo;
    [SerializeField] private Button chooseWeaponButton;
    [SerializeField] private TextMeshProUGUI text;
    public WeaponValue WeaponValue { get; set; }
    public ChooseWeaponType ChooseWeaponType { get; set; }
    public int Level { get; set; }
    public int Coin { get; set; } = 200;
    public float Health { get; set; } = 30;

    public void Init()
    {
        switch (ChooseWeaponType)
        {
            case ChooseWeaponType.Weapon:
                text.text = weaponSo.weaponValues.Find(x => x.weaponType == WeaponValue.weaponType).name + " - Level: " + Level;
                chooseWeaponButton.onClick.AddListener(AddWeapon);
                break;
            case ChooseWeaponType.Coin:
                chooseWeaponButton.onClick.AddListener(AddCoin);
                break;
            case ChooseWeaponType.Health:
                chooseWeaponButton.onClick.AddListener(AddHealth);
                break;
        }
        
    }

    private void AddWeapon()
    {
        GameController.Instance.Hero.AddWeapon(WeaponValue.weaponType);
        GameController.Instance.Hero.RemainChooseWeapon -= 1;
        ChooseWeaponUI.Instance.HideChooseWeaponUI();
    }

    private void AddCoin()
    {
        GameController.Instance.Hero.RemainChooseWeapon -= 1;
        ChooseWeaponUI.Instance.HideChooseWeaponUI();
    }

    private void AddHealth()
    {
        GameController.Instance.Hero.Health += Health;
        GameController.Instance.Hero.RemainChooseWeapon -= 1;
        ChooseWeaponUI.Instance.HideChooseWeaponUI();
    }
    
}

public enum ChooseWeaponType
{
    Weapon,
    Coin,
    Health
}