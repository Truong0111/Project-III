using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] private VoidEvent startGameEvent;
    public Hero Hero { get; set; }

    public IEnumerator Start()
    {
        yield return new WaitUntil(() => Hero);
        startGameEvent.Raise();
    }
}
