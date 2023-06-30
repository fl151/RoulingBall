using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingsColorChanger : MonoBehaviour
{
    [SerializeField] private PatternsExecuter _executer;
    [SerializeField] private ThingColorFinder _colorFinder;

    private Color _color;

    private void OnEnable()
    {
        _executer.ThingSpawned += OnThingSpawned;
    }

    private void Start()
    {
        _color = _colorFinder.Color;
    }

    private void OnDisable()
    {
        _executer.ThingSpawned -= OnThingSpawned;
    }

    private void OnThingSpawned(Thing thing)
    {
        thing.GetComponent<MeshRenderer>().material.color = _color;
    }
}
