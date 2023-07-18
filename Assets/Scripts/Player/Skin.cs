using UnityEngine;

[ExecuteAlways]
public class Skin : MonoBehaviour
{
    [SerializeField] private GameObject _defaultSkin;
    [SerializeField] private GameObject _skin;

    private GameObject _currentSkin;

    private void Update()
    {
        if(_currentSkin == null)
        {
            if (_skin != null)
            {
                _currentSkin = Instantiate(_skin, gameObject.transform);
            }
            else
            {
                _currentSkin = Instantiate(_defaultSkin, gameObject.transform);
            }
        } 
    }
}
