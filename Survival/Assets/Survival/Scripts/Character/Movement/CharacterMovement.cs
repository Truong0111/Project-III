using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private VoidEvent stopGameEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent continueGameEvent;
    [SerializeField] private VoidEvent winEvent;
    
    protected Character Character;
    [field: SerializeField] public float MoveSpeed { get; private set; }
    protected Vector3 Direction;

    public bool CanMove { get; set; } = true;
    
    public virtual void Awake()
    {
        Character = GetComponent<Character>();
        
        stopGameEvent.Register(StopMove);
        pauseGameEvent.Register(StopMove);
        continueGameEvent.Register(ContinueMove);
        winEvent.Register(StopMove);
    }

    private void OnDestroy()
    {
        stopGameEvent.Unregister(StopMove);
        pauseGameEvent.Unregister(StopMove);
        continueGameEvent.Unregister(ContinueMove);
        winEvent.Unregister(StopMove);
    }

    public void StopMove() => CanMove = false;
    public void ContinueMove() => CanMove = true;
    
    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }


    public virtual void FixedUpdate()
    {
        ApplyMove();
        ApplyRotate();
    }

    public virtual void ApplyMove()
    {
        
    }
    

    private const float RotationSpeed = 180f;

    public virtual void ApplyRotate()
    {
        if (Direction == Vector3.zero) return;
        var targetRotation = Quaternion.LookRotation(Direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 20f);
    }
}