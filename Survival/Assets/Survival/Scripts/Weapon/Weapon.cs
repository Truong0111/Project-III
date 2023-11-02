using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

public class Weapon : MonoBehaviour
{
    public WeaponValue WeaponValue { get; private set; }

    private Transform _parent;
    private float _damage;
    private float _speed;
    private float _duration;

    public void Initialize(WeaponValue value, Transform parent)
    {
        transform.parent = parent;
        WeaponValue = value;
        
        _parent = parent;
        _damage = value.damage;
        _speed = value.speed;
        _duration = value.duration;
    }
    
    public virtual void Awake()
    {
        
    }

    public virtual void Update()
    {
        CheckDespawn();
        ApplyMove();
    }

    private void CheckDespawn()
    {
        _duration -= Time.deltaTime;
        if (_duration > 0) return;
        Despawn();
    }

    public virtual void ApplyMove()
    {
        transform.RotateAround(_parent.position, Vector3.up, _speed * Time.deltaTime);
    }

    public virtual void CheckDuration()
    {
        
    }

    public virtual void Despawn()
    {
        SimplePool.Despawn(gameObject);
    }
}