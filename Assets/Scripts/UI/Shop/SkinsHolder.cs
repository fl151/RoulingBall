using UnityEngine;

public class SkinsHolder : MonoBehaviour
{
    [SerializeField] private ItemInfo[] _itemsInfo;

    public ItemInfo GetItemInfo(int index)
    {
        if (index > -1 && index < _itemsInfo.Length)
            return _itemsInfo[index];
        else
            return null;
    }
}
