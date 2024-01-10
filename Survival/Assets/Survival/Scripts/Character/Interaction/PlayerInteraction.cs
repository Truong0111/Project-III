using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Hero Hero => gameObject.GetComponentInParent<Hero>();
}
    