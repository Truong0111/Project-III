using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public override void ApplyMove()
    {
        if (!CanMove) return;
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        var verticalInput = Input.GetAxisRaw("Vertical");

        Direction = new Vector3(horizontalInput, 0, verticalInput).normalized;
        
        var thisTransform = transform.position;
        var targetPos = thisTransform + Direction;
        
        thisTransform =
            Vector3.MoveTowards(thisTransform, targetPos, MoveSpeed * Time.fixedDeltaTime);
        transform.position = thisTransform;
    }
}