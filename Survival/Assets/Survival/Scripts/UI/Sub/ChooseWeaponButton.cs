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
    [SerializeField] private TextMeshProUGUI textChoose;
    [SerializeField] private Image imageChoose;

    [SerializeField] private Sprite coinSprite;
    [SerializeField] private Sprite healthSprite;
    public WeaponValue WeaponValue { get; set; }
    public ChooseWeaponType ChooseWeaponType { get; set; }
    public int Level { get; set; }
    public int Coin { get; set; } = 200;
    public float Health { get; set; } = 30;

    private void OnEnable()
    {
        chooseWeaponButton.onClick.RemoveAllListeners();
        chooseWeaponButton.interactable = true;
    }

    public void Init()
    {
        switch (ChooseWeaponType)
        { 
            case ChooseWeaponType.Weapon:
                var weapon = weaponSo.weaponValues.Find(x => x.weaponType == WeaponValue.weaponType);
                var level = Level + 1;
                textChoose.text = weapon.name + " - Level: " + level;
                imageChoose.sprite = weapon.sprite;
                chooseWeaponButton.onClick.AddListener(AddWeapon);
                break;
            case ChooseWeaponType.Coin:
                textChoose.text = Coin.ToString();
                imageChoose.sprite = coinSprite;
                chooseWeaponButton.onClick.AddListener(AddCoin);
                break;
            case ChooseWeaponType.Health:
                textChoose.text = Health.ToString();
                imageChoose.sprite = healthSprite;
                chooseWeaponButton.onClick.AddListener(AddHealth);
                break;
        }
    }

    private void AddWeapon()
    {
        chooseWeaponButton.interactable = false;
        GameController.Instance.Hero.AddWeapon(WeaponValue.weaponType);
        GameController.Instance.Hero.RemainChooseWeapon -= 1;
        ChooseWeaponUI.Instance.HideChooseWeaponUI();
    }

    private void AddCoin()
    {
        chooseWeaponButton.interactable = false;
        GameController.Instance.Hero.RemainChooseWeapon -= 1;
        ChooseWeaponUI.Instance.HideChooseWeaponUI();
    }

    private void AddHealth()
    {
        chooseWeaponButton.interactable = false;
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