using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListObjectSo", menuName = "SO/ListObjectSo")]
public class ListObjectSo : ScriptableObject
{
    public List<Enemy> enemyInRanges;
}
