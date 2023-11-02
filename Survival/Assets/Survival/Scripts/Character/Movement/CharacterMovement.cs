using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    protected Character Character;
    [field:SerializeField] public float MoveSpeed { get; private set; }
    protected Vector3 Direction;

    public virtual void Awake()
    {
        Character = GetComponent<Character>();
    }

    public virtual void Start()
    {
        // MoveSpeed = Character.
    }

    public virtual void Update()
    {
        
        ApplyRotate();
    }


    public virtual void FixedUpdate()
    {
        ApplyMove();
    }

    public virtual void ApplyMove()
    {
        
    }

    public virtual void ApplyRotate()
    {
        var currentRotation = transform.rotation;
        var targetRotation = Quaternion.Euler(Direction);
        
        if (currentRotation == targetRotation) return;
    }
}
