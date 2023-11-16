using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : Weapon
{
    [SerializeField] public float range = 8f;
    [SerializeField] public float rotationSpeed = 200f;
    private bool _go;
    private Transform HeroTransform { get; set; }

    private Vector3 LocationInFrontOfPlayer { get; set; }

    public override void OnEnable()
    {
        if (!Hero) return;
        HeroTransform = Hero.transform;
        LocationInFrontOfPlayer = HeroTransform.position + Hero.transform.forward * range;
        StartCoroutine(Boom());
    }

    protected override void ApplyMove()
    {
        if(!Hero) Despawn();
        HeroTransform = Hero.transform;
        transform.Rotate(Vector3.up * (Time.deltaTime * rotationSpeed));

        if (_go)
        {
            transform.position = Vector3.MoveTowards(
                    transform.position,
                    LocationInFrontOfPlayer,
                    Time.deltaTime * Speed);
        }

        if (!_go)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                HeroTransform.position,
                Time.deltaTime * Speed);
        }

        if (!_go && Vector3.Distance(Hero.transform.position, transform.position) < 0.1f)
        {
            Despawn();
        }
    }

    public override void ResetValue()
    {
        transform.position = Hero.transform.position;
    }

    private IEnumerator Boom()
    {
        _go = true;
        yield return new WaitForSeconds(Duration);
        _go = false;
    }
}