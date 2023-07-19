using System.Collections;
using TMPro;
using UnityEngine;

public class ErrorText : MonoBehaviour
{
    private const float _delayafter = 0.5f;

    [SerializeField] private TMP_Text _text;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _coroutine =  StartCoroutine(MakeInvisible());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    private IEnumerator MakeInvisible()
    {
        yield return new WaitForSeconds(_delayafter);

        while(_text.color.a > 0)
            _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _text.color.a - Time.deltaTime);

        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 1);

        gameObject.SetActive(false);
    }
}
