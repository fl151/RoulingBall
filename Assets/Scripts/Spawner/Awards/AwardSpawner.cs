using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AwardSpawner : MonoBehaviour
{
    [SerializeField] protected Award _prefab;
    [SerializeField] protected FinderRandomPattern _finderPattern;
    [SerializeField] protected PatternsExecuter _patternExecuter;
}
