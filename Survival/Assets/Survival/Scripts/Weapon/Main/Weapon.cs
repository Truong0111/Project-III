using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponValue WeaponValue { get; protected set; }
    
    public Hero Hero { get; protected set; }
    public float Damage { get; protected set; }
    public float Speed { get; protected set; }
    public float Duration { get; protected set; }

    public virtual void Initialize(WeaponValue value, Hero hero, Transform parent)
    {
        transform.parent = parent;
        
        WeaponValue = value;
        Hero = hero;
        
        Damage = value.damage;
        Speed = value.speed;
        Duration = value.duration;
    }

    public virtual void OnEnable()
    {
        
    }

    public virtual void Update()
    {
        CheckDeSpawn();
        ApplyMove();
    }

    public virtual void ResetValue()
    {
        
    }
    protected virtual void CheckDeSpawn(){}

    protected virtual void ApplyMove(){}

    public virtual void Despawn()
    {
        gameObject.SetActive(false);
        ResetValue();
    }
}