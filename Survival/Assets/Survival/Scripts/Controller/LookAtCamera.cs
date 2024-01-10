using System;
using System.Collections;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform subCamera;
    private Transform _camera;
    private void Start()
    {
        var camera = Camera.main;

        if (_camera == null)
        {
            if (subCamera != null)
            {
                _camera = subCamera;
                return;
            }
            enabled = false;
            return;
        }

        _camera = camera!.transform;
    }

    private void Update()
    {
        transform.forward = _camera.forward;
    }
}