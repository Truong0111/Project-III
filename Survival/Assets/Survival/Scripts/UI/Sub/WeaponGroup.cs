using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class WeaponGroup : Singleton<WeaponGroup>
{ 
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent loseEvent;
    [SerializeField] private VoidEvent winEvent;
    [SerializeField] private VoidEvent menuEvent;

    [SerializeField] private GameObject weaponShowUI;
    public List<WeaponShowUI> weaponShowUis;
    
    private void Awake()
    {
        startGameEvent.Register(ShowWeaponGroupText);
        loseEvent.Register(HideWeaponGroupText);
        winEvent.Register(HideWeaponGroupText);
        menuEvent.Register(HideWeaponGroupText);
        
        gameObject.SetActive(false);
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        startGameEvent.Unregister(ShowWeaponGroupText);
        loseEvent.Unregister(HideWeaponGroupText);
        winEvent.Unregister(HideWeaponGroupText);
        menuEvent.Unregister(HideWeaponGroupText);
    }

    public void AddWeaponShowUI(WeaponSpawner weaponSpawner)
    {
        var weaponShow = SimplePool.Spawn(weaponShowUI, Vector3.zero, Quaternion.identity).GetComponent<WeaponShowUI>();
        weaponShow.transform.SetParent(transform);
        weaponShow.WeaponSpawner = weaponSpawner;
        weaponShow.UpdateWeaponShowUI();
        weaponShowUis.Add(weaponShow);
    }

    public void UpdateWeaponShowUI()
    {
        foreach (var weaponShow in weaponShowUis)
        {
            weaponShow.UpdateWeaponShowUI();
        }
    }
    
    private void ShowWeaponGroupText()
    {
        gameObject.SetActive(true);
        weaponShowUis = new List<WeaponShowUI>();
    }
    private void HideWeaponGroupText() => gameObject.SetActive(false);
}
