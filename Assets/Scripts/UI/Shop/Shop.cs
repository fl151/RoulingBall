using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerSkinView _playerSkinView;
    [SerializeField] private GameObject _errorView;
    [SerializeField] private TMP_Text _dimondsCount;

    [SerializeField] private SkinsHolder _skinHolder;

    private ShopItem _current;

    private void Start()
    {
        UpdateDimonds();

        var items = GetComponentsInChildren<ShopItem>(true);

        for (int i = 0; i < items.Length; i++)
        {
            items[i].Instantiate(_skinHolder.GetItemInfo(i + 1), i);

            if (Progress.Instance.PlayerData.AreSkinsBuåód[i])
            {
                items[i].GetComponent<ItemView>().Buy();

                if (Progress.Instance.PlayerData.CurrentSkinIndex - 1 == i)
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

            Progress.Instance.PlayerData.AreSkinsBuåód[item.Index] = true;

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

        Progress.Instance.PlayerData.CurrentSkinIndex = item.Index + 1;
        Progress.SaveDataCloud();
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
        if(_current != null)
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
