using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public Hero Hero { get; set; }
    public float CurrentTime { get; private set; } = 0;
    public IEnumerator Start()
    {
        yield return new WaitUntil(() => Hero);
    }

    private void Update()
    {
        CurrentTime += Time.deltaTime;
    }
}
