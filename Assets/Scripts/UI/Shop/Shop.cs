using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerSkinView _playerSkinView;
    [SerializeField] private GameObject _errorView;
    [SerializeField] private TMP_Text _dimondsCount;

    [SerializeField] private SkinsHolder _skinHolder;

    private ShopItem _current;

    private void OnEnable()
    {
        UpdateDimonds();
    }

    private void Start()
    {
        var items = GetComponentsInChildren<ShopItem>();

        for (int i = 0; i < items.Length; i++)
        {
            items[i].Instantiate(_skinHolder.GetItemInfo(i), i);

            if (Progress.Instance.PlayerData.AreSkinsBu��d[i])
            {
                items[i].GetComponent<ItemView>().Buy();

                if (Progress.Instance.PlayerData.CurrentSkinIndex == i)
                {
                    SetActive(items[i]);
                }
            }
        }
    }

    public bool TryBuyItem(ShopItem item)
    {
        if (item.Price <= Progress.Instance.PlayerData.Diamonds)
        {
            Progress.Instance.PlayerData.Diamonds -= item.Price;
            UpdateDimonds();

            Progress.Instance.PlayerData.AreSkinsBu��d[item.Index] = true;

            Progress.SaveDataCloud();

            item.GetComponent<ItemView>().Buy();

            SetItem(item);

            return true;
        }
        else
        {
            ShowError();
            return false;
        }
    }

    public void SetItem(ShopItem item)
    {
        _playerSkinView.SetSkin(item);

        SetInactiveLast();
        SetActive(item);
    }

    private void SetActive(ShopItem item)
    {
        _current = item;
        _current.GetComponent<ItemView>().SetActive();
    }

    private void UpdateDimonds()
    {
        _dimondsCount.text = Progress.Instance.PlayerData.Diamonds.ToString();
    }

    private void SetInactiveLast()
    {
        _current.GetComponent<ItemView>().SetInactive();
    }

    private void ShowError()
    {
        if (_errorView.activeSelf)
        {
            _errorView.SetActive(false);
        }

        _errorView.SetActive(true);
    }
}
