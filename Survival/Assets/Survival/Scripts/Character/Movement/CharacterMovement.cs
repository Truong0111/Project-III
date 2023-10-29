using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [field:SerializeField] public float MoveSpeed { get; private set; }
    protected Rigidbody Rigidbody;
    protected Vector3 Direction;

    public virtual void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        ApplyMove();
        ApplyRotate();
    }

    public virtual void ApplyMove()
    {
        
    }

    public virtual void ApplyRotate()
    {
        var currentRotation = transform.rotation;
        var targetRotation = Quaternion.Euler(Direction);
        
        if (currentRotation == targetRotation) return;
        Rigidbody.MoveRotation(targetRotation);
    }
}
