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

        gameObject.SetActive(false);
    }

    private IEnumerator MakeInvisible()
    {
        yield return new WaitForSeconds(_delayafter);

        gameObject.SetActive(false);
    }
}
