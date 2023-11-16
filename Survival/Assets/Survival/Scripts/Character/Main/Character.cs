using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Character : MonoBehaviour
{
    [ShowInInspector]
    protected int ID { get; set; }
    
    [ShowInInspector]
    public float Health { get; set; }
    
    [ShowInInspector]
    public float Damage { get; set; }
    
    [ShowInInspector]
    public float Armor { get; set; }
    
    [ShowInInspector]
    public float Speed { get; set; }
    
    [ShowInInspector]
    public float Experience { get; set; }
}