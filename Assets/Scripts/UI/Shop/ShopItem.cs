using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ItemView), typeof(Button))]
public class ShopItem : MonoBehaviour
{
    [SerializeField] private ItemInfo _info;

    private Skin _prefab;
    private int _price;

    private ItemView _view;
    private Button _button;
    private Shop _shop;

    private bool _isBuyed = false;

    public Skin Prefab => _prefab;
    public int Price => _price;

    private void OnEnable()
    {
        _view = GetComponent<ItemView>();
        _view.Fill(_info.Icon, _info.Price);

        _prefab = _info.Prefab;
        _price = _info.Price;

        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnButtonClick);

        _shop = GetComponentInParent<Shop>();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (_info == null) return;

        if (_isBuyed)
        {
            _shop.SetItem(this);
        }
        else
        {
            _isBuyed = _shop.TryBuyItem(this);
        }  
    }
}
