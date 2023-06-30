using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingColorFinder : MonoBehaviour
{
    [SerializeField] private Color[] _validThingsColors;

    private Color _color;

    public Color Color => _color;

    private void Awake()
    {
        _color = GetRandomColor(_validThingsColors);
    }

    private Color GetRandomColor(Color[] colors)
    {
        if (colors.Length == 0) return Color.black;

        int index = Random.Range(0, colors.Length);

        return colors[index];
    }
}
