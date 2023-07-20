using UnityEngine;

public class PlayerSkinView : MonoBehaviour
{
    [SerializeField] private Skin _defaultSkin;
    [SerializeField] private SkinsHolder _holder;

    private GameObject _currentSkin;

    private void Start()
    {
        ItemInfo info = _holder.GetItemInfo(Progress.Instance.PlayerData.CurrentSkinIndex);

        if (info != null)
            _currentSkin = Instantiate(info.Prefab.gameObject, gameObject.transform);
        else
            _currentSkin = Instantiate(_defaultSkin.gameObject, gameObject.transform);
    }

    public void SetSkin(ShopItem info)
    {
        Destroy(_currentSkin);
        _currentSkin = Instantiate(info.Prefab.gameObject, gameObject.transform);
    }
}
