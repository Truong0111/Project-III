using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Title("Event")] 
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent stopGameEvent;
    [SerializeField] private VoidEvent loseEvent;
    [SerializeField] private VoidEvent winEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent resumeGameEvent;
    [SerializeField] private VoidEvent menuEvent;

    private bool _canMove = true;
    
    private void Awake()
    {
        menuEvent.Register(StopMove);
        startGameEvent.Register(ContinueMove);
        pauseGameEvent.Register(StopMove);
        stopGameEvent.Register(StopMove);
        resumeGameEvent.Register(ContinueMove);
        winEvent.Register(StopMove);
        loseEvent.Register(StopMove);
    }

    private void OnDestroy()
    {
        menuEvent.Unregister(StopMove);
        startGameEvent.Unregister(ContinueMove);
        pauseGameEvent.Unregister(StopMove);
        stopGameEvent.Unregister(StopMove);
        resumeGameEvent.Unregister(ContinueMove);
        winEvent.Unregister(StopMove);
        loseEvent.Unregister(StopMove);
    }

    private void StopMove() => _canMove = false;
    private void ContinueMove() => _canMove = true;

    [ShowInInspector] public WeaponValue WeaponValue { get; set; }
    [ShowInInspector] public Hero Hero { get; set; }
    [ShowInInspector] public float Damage => WeaponValue.damage;
    [ShowInInspector] public float Speed => WeaponValue.speed;
    [ShowInInspector] public float Duration => WeaponValue.duration;

    [ShowInInspector] protected float DurationRemain;

    public virtual void Initialize(WeaponValue value, Hero hero, Transform parent)
    {
        transform.parent = parent;
        WeaponValue = value;
        Hero = hero;
        DurationRemain = Duration;
    }
    
    public virtual void OnEnable(){}

    public virtual void Update()
    {
        CheckDeSpawn();
        if(_canMove) ApplyMove();
    }

    protected virtual void Despawn()
    {
        gameObject.SetActive(false);
        ResetValue();
    }
    
    public virtual void ResetValue(){}
    protected virtual void CheckDeSpawn(){}
    protected virtual void ApplyMove(){}
}