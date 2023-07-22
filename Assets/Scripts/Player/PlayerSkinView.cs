using UnityEngine;

public class PlayerSkinView : MonoBehaviour
{
    [SerializeField] private Skin _defaultSkin;
    [SerializeField] private SkinsHolder _holder;

    private GameObject _currentSkin;

    private void OnEnable()
    {
        Progress.Instance.DataLoaded += OnDataLoaded;
    }

    private void Start()
    {
        OnDataLoaded();
    }

    private void OnDisable()
    {
        Progress.Instance.DataLoaded -= OnDataLoaded;
    }

    private void OnDataLoaded()
    {
        ItemInfo info = _holder.GetItemInfo(Progress.Instance.PlayerData.CurrentSkinIndex);

        if (_currentSkin != null)
            Destroy(_currentSkin);

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
