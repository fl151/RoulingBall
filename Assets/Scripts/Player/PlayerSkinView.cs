using UnityEngine;

public class PlayerSkinView : MonoBehaviour
{
    [SerializeField] private Skin _defaultSkin;

    private Skin _skin;

    private GameObject _currentSkin;

    private void Start()
    {
        if(_currentSkin == null)
        {
            if (_skin != null)
            {
                _currentSkin = Instantiate(_skin.gameObject, gameObject.transform);
            }
            else
            {
                _currentSkin = Instantiate(_defaultSkin.gameObject, gameObject.transform);
            }
        } 
    }

    public void SetSkin(Skin skin)
    {
        _skin = skin;

        Destroy(_currentSkin);
        _currentSkin = Instantiate(_skin.gameObject, gameObject.transform);
    }
}
