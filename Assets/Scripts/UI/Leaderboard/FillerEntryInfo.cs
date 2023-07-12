using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FillerEntryInfo : MonoBehaviour
{
    private const string _playerText = "Player";

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private RawImage _icon;

    public void Fill(string name, int score, string pictureURL)
    {
        if (name != null && name != "")
            _name.text = name;
        else
            _name.text = _playerText;

        _score.text = score.ToString();
        _slider.value = ((float)score) / Progress.Instance.WorldRecordRange;

        StartCoroutine(LoadImage(pictureURL));
    }

    public void SetFillColor(Color color)
    {
        _fill.color = color;
    }

    private IEnumerator LoadImage(string url)
    {
        UnityWebRequest request = new UnityWebRequest(url);

        yield return request;

        _icon.texture = DownloadHandlerTexture.GetContent(request);
    }
}
