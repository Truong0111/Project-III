using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    public override void ApplyMove()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Direction = new Vector3(horizontalInput, 0, verticalInput) * MoveSpeed;
        
        Rigidbody.AddForce(Direction,ForceMode.VelocityChange);
    }
}
