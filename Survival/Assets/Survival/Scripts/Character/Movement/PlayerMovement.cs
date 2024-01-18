using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    private DynamicJoystick _dynamicJoystick;

    public override void Start()
    {
        base.Start();
        _dynamicJoystick = (DynamicJoystick)DynamicJoystick.Instance;
#if UNITY_STANDALONE_WIN
        _dynamicJoystick.enabled = false;
#endif
    }

    public override void ApplyMove()
    {
        Character.Animator.SetBool(AnimatorConstant.IsMoveHashed,Direction != Vector3.zero && CanMove);
        if (!CanMove) return;
        
        var horizontal = _dynamicJoystick.Horizontal;
        var vertical = _dynamicJoystick.Vertical;
        Direction = new Vector3(horizontal, 0, vertical).normalized;
        
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");
        Direction = new Vector3(horizontalInput, 0, verticalInput).normalized;
#endif
        
        var thisTransform = transform.position;
        var targetPos = thisTransform + Direction;
        
        thisTransform = Vector3.MoveTowards(thisTransform, targetPos, MoveSpeed * Time.fixedDeltaTime);
        transform.position = thisTransform;
        
    }
}