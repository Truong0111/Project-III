using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    protected Character Character;
    [field: SerializeField] public float MoveSpeed { get; private set; }
    protected Vector3 Direction;

    public virtual void Awake()
    {
        Character = GetComponent<Character>();
    }

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