using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FillerEntryInfo : MonoBehaviour
{
    private const string _ruPlayerText = "Игрок";
    private const string _enPlayerText = "Player";
    private const string _trPlayerText = "Oyuncu";

    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fill;
    [SerializeField] private RawImage _icon;

    private string _imageURL;
    private bool isImageLoaded = false;

    private void Update()
    {
        if(string.IsNullOrEmpty(_imageURL) == false && isImageLoaded == false)
        {
            StartCoroutine(LoadImage(_imageURL));
            isImageLoaded = true;
        }
    }

    public void Fill(string name, int score, string pictureURL)
    {
        if (string.IsNullOrEmpty(name))
            _name.text = GetCurrentText();
        else
            _name.text = name;

        _score.text = score.ToString();
        _slider.value = (float)score / Progress.Instance.WorldRecordRange;

        _imageURL = pictureURL;
    }

    public void SetFillColor(Color color)
    {
        _fill.color = color;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            _name.text = GetCurrentText();
        else
            _name.text = name;
    }

    private IEnumerator LoadImage(string url)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            _icon.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }

    private string GetCurrentText()
    {
        string text = "";

        switch (Progress.Instance.PlayerData.Language)
        {
            case Language.Ru:
                text = _ruPlayerText;
                break;

            case Language.En:
                text = _enPlayerText;
                break;

            case Language.Tr:
                text = _trPlayerText;
                break;

            default:
                break;
        }

        return text;
    }
}
