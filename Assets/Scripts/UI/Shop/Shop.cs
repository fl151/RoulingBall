using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private PlayerSkinView _playerSkinView;
    [SerializeField] private GameObject _errorView;
    [SerializeField] private TMP_Text _dimondsCount;

    private ShopItem _current;

    private void OnEnable()
    {
        UpdateDimonds();
    }

    public bool TryBuyItem(ShopItem item)
    {
        if (item.Price <= Progress.Instance.PlayerData.Diamonds)
        {
            Progress.Instance.PlayerData.Diamonds -= item.Price;
            UpdateDimonds();

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
        _playerSkinView.SetSkin(item.Prefab);

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
