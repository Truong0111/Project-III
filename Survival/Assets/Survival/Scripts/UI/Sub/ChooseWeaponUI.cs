using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChooseWeaponUI : Singleton<ChooseWeaponUI>
{
    [SerializeField] private WeaponSo weaponSo;
    [SerializeField] private VoidEvent levelUpEvent;
    [SerializeField] private VoidEvent stopGameEvent;
    [SerializeField] private VoidEvent continueGameEvent;
    [SerializeField] private List<ChooseWeaponButton> chooseWeaponButtons;

    private void Awake()
    {
        levelUpEvent.Register(ShowChooseWeaponUI);

        gameObject.SetActive(false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        levelUpEvent.Unregister(ShowChooseWeaponUI);
    }

    private void OnEnable()
    {
        foreach (var chooseWeaponButton in chooseWeaponButtons)
        {
            chooseWeaponButton.WeaponValue = null;
        }
    }

    private void ShowChooseWeaponUI()
    {
        gameObject.SetActive(true);
        stopGameEvent.Raise();
        RandomChoose();
    }

    public void HideChooseWeaponUI()
    {
        continueGameEvent.Raise();
        gameObject.SetActive(false);
    }

    private void RandomChoose()
    {
        var weaponValues = new List<WeaponValue>();
        
        foreach (var weaponsValue in weaponSo.weaponValues)
        {
            var weaponValue = new WeaponValue();
            weaponValue.Init(weaponsValue);
            weaponValues.Add(weaponValue);
        }

        foreach (var weaponSpawner in GameController.Instance.Hero.WeaponSpawners)
        {
            if (weaponSpawner.WeaponValue.level >= 7)
            {
                weaponValues.Remove(weaponSpawner.WeaponValue);
            }
            
            foreach (var weaponValue in weaponValues)
            {
                if (weaponValue.weaponType == weaponSpawner.WeaponValue.weaponType)
                {
                    weaponValue.level = weaponSpawner.WeaponValue.level;
                }
            }
        }
        
        if (weaponValues.Count <= 0)
        {
            AddCoin(chooseWeaponButtons[0]);
            AddHealth(chooseWeaponButtons[1]);
        }

        //Random index weaponSpawners
        var tmp = new List<int>();
        for (var i = 0; i < chooseWeaponButtons.Count; i++)
        {
            if (i > weaponValues.Count - 1)
            {
                chooseWeaponButtons[i].gameObject.SetActive(false);
                continue;
            }

            var rand = Except.GetWeaponIndexExcept(tmp, 0, weaponValues.Count);
            
            AddWeapon(chooseWeaponButtons[i], weaponValues[rand]);
            tmp.Add(rand);
        }
    }

    private void AddWeapon(ChooseWeaponButton chooseWeaponButton, WeaponValue weaponValue)
    {
        chooseWeaponButton.ChooseWeaponType = ChooseWeaponType.Weapon;
        chooseWeaponButton.WeaponValue = weaponValue;
        chooseWeaponButton.Level = weaponValue.level;
        chooseWeaponButton.Init();
    }

    private void AddCoin(ChooseWeaponButton chooseWeaponButton)
    {
        chooseWeaponButton.ChooseWeaponType = ChooseWeaponType.Coin;
        chooseWeaponButton.Init();
    }

    private void AddHealth(ChooseWeaponButton chooseWeaponButton)
    {
        chooseWeaponButton.ChooseWeaponType = ChooseWeaponType.Health;
        chooseWeaponButton.Init();
    }
}

public class Except
{
    private const int MaxAttempts = 1000000;

    public static int GetWeaponIndexExcept(int exceptValue, int min, int max)
    {
        if ((min == max && min == exceptValue) || min >= max) return -1;
        int rand;
        do
        {
            rand = Random.Range(min, max + 1);
        } while (rand == exceptValue);

        return rand;
    }

    public static int GetWeaponIndexExcept(List<int> exceptValues, int min, int max)
    {
        exceptValues = RemoveDuplicates(exceptValues);

        if (min >= max) return -1;

        foreach (var value in exceptValues.Where(value => value < min | value > max))
        {
            exceptValues.Remove(value);
        }

        if (exceptValues.Count >= max - min + 1) return -1;

        var attempts = 0;

        while (attempts < MaxAttempts)
        {
            var rand = Random.Range(min, max);
            if (!exceptValues.Contains(rand)) return rand;
            attempts++;
        }

        return -1;
    }

    public static List<int> RemoveDuplicates(List<int> arr)
    {
        return arr.Distinct().ToList();
    }
}