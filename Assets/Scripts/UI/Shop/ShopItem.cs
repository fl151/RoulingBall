using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemView), typeof(Button))]
public class ShopItem : MonoBehaviour
{
    private Skin _prefab;
    private int _price;
    private int _index;

    private Button _button;
    private Shop _shop;
    private ItemView _view;

    private bool _isBuyed = false;

    public Skin Prefab => _prefab;
    public int Price => _price;
    public int Index => _index;

    private void OnEnable()
    {
        if (_button == null)
            _button = GetComponent<Button>();

        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    public void Instantiate(ItemInfo info, int index)
    {
        _index = index;

        if (info != default)
        {
            _view = GetComponent<ItemView>();
            _view.Fill(info.Icon, info.Price);

            _prefab = info.Prefab;
            _price = info.Price;

            _shop = GetComponentInParent<Shop>();
        }
    }

    public void SetIsBuyed()
    {
        _isBuyed = true;
    }

    private void OnButtonClick()
    {
        if (_isBuyed)
        {
            _shop.SetItem(this);
        }
        else
        {
            _isBuyed = _shop.TryBuyItem(this);

            if (_isBuyed)
                _view.Buy();
        }
    }
}
