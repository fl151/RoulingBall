using UnityEngine;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "ItemInfo")]
public class ItemInfo : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private Skin _prefab;

    public Sprite Icon => _icon;
    public int Price => _price;
    public Skin Prefab => _prefab;
}
