using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Ground _ground;

    private void Awake()
    {
        _ground = GetComponentInChildren<Ground>();
    }

    public void SetColor(Color color)
    {
        _ground.GetComponent<MeshRenderer>().material.color = color;
    }
}
