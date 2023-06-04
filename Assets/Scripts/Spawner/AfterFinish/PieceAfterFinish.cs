using TMPro;

public class PieceAfterFinish : PieceOfRoad
{
    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void SetText(string text)
    {
        _text.text = text;
    }
}
