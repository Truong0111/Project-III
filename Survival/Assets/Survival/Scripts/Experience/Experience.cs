using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [ShowInInspector]
    public float Value { get; set; }
    
    private void OnEnable()
    {
        transform.DOLocalRotate(new Vector3(45f, 360f, 45f), 0.5f)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Hero>(out var hero))
        {
            hero.Experience += Value;
            SimplePool.Despawn(gameObject);
        }
    }
}
