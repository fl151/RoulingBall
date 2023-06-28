using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderValueChanger : MonoBehaviour
{
    [SerializeField] private float _speedValueChange;

    private Slider _slider;

    private Coroutine _coroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();

        _coroutine = StartCoroutine(ChangeValueCycle());
    }

    private void OnDisable()
    {
        StopCoroutine(_coroutine);
    }

    public float GetValue()
    {
        return _slider.value;
    }

    private IEnumerator ChangeValueCycle()
    {
        var delay = new WaitForFixedUpdate();

        while (true)
        {
            while(_slider.value != _slider.maxValue)
            {
                _slider.value += Time.deltaTime * _speedValueChange;

                yield return delay;
            }

            while (_slider.value != _slider.minValue)
            {
                _slider.value -= Time.deltaTime * _speedValueChange;

                yield return delay;
            }
        }
    }
}
