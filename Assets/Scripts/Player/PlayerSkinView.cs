using UnityEngine;

public class PlayerSkinView : MonoBehaviour
{
    [SerializeField] private Skin _defaultSkin;
    [SerializeField] private SkinsHolder _holder;

    private GameObject _currentSkin;

    private void Start()
    {
        int skinIndex = Progress.Instance.PlayerData.CurrentSkinIndex;

        ItemInfo info = _holder.GetItemInfo(skinIndex);

        Skin skin = null;

        if (info != null)
            skin = info.Prefab;

        if (skin != null)
            _currentSkin = Instantiate(skin.gameObject, gameObject.transform);
        else
            _currentSkin = Instantiate(_defaultSkin.gameObject, gameObject.transform);
    }

    public void SetSkin(ShopItem info)
    {
        Destroy(_currentSkin);
        _currentSkin = Instantiate(info.Prefab.gameObject, gameObject.transform);

        Progress.Instance.PlayerData.CurrentSkinIndex = info.Index;
        Progress.SaveDataCloud();
    }
}
