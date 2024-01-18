using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [field: SerializeField] public float TimeTarget { get; set; } = 900f;
}
