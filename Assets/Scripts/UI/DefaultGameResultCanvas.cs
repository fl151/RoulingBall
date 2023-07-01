using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefaultGameResultCanvas : MonoBehaviour
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<DiamondsCount>().GetComponent<TMP_Text>();

        _text.text = Progress.Instance.PlayerData.Diamonds.ToString();
    }
}
