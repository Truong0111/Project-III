using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraTarget;

    [SerializeField] private float cSpeed = 100f;
    [SerializeField] private Vector3 dist;
    [SerializeField] private Transform lookTarget;


    private void Start()
    {
        if (!cameraTarget) cameraTarget = FindFirstObjectByType<Hero>().transform;
        if (!lookTarget) lookTarget = cameraTarget;
    }

    private void FixedUpdate()
    {
        var dPos = cameraTarget.position + dist;
        var sPos 
            = Vector3.MoveTowards(transform.position, dPos, cSpeed * Time.fixedDeltaTime);

        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }
}