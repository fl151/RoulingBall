using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public enum Language
{
    Null,
    Ru,
    En,
    Tr
}

public class PlayerData
{
    public int MaxRange = 0;
    public int Diamonds = 0;

    public bool[] AreSkinsBuåód = { false, false, false, false, false, false };
    public int CurrentSkinIndex = 0;

    public Language Language = Language.Null;
}

public class Progress : MonoBehaviour
{
    private int _topRangeInWorld;

    public PlayerData PlayerData = new PlayerData();

    public static Progress Instance;

    public int WorldRecordRange => _topRangeInWorld;

    public event UnityAction DataLoaded;
    public event UnityAction<PlayerData> NeedAsk;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void SaveDataCloud()
    {
        string json = JsonUtility.ToJson(Instance.PlayerData);

        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(json);

        PlayerPrefs.SetString("data", json);

        Debug.Log("save");
    }

    public static void SetDataFromJSON(string json)
    {
        var dataCloud = JsonUtility.FromJson<PlayerData>(json);

        var dataPrefs = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("data"));

        if (AreDatasEquals(dataCloud, dataPrefs))
            SetData(dataPrefs);  
        else if (dataPrefs == default)
            SetData(dataCloud);
        else
            AskUserAboutProgress(dataCloud);
    }

    public static void SetPrefsData()
    {
        var dataPrefs = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("data"));

        SetData(dataPrefs);
    }

    public static void SetWorldRecord(int value)
    {
        Instance._topRangeInWorld = value;
    }

    public static void SetData(PlayerData data)
    {
        Instance.PlayerData = data;
        Instance.DataLoaded?.Invoke();

        Debug.Log("Set data");

        SaveDataCloud();
    }

    private static void AskUserAboutProgress(PlayerData dataCloud)
    {
        Instance.NeedAsk?.Invoke(dataCloud);
    }

    private static bool AreDatasEquals(PlayerData data1, PlayerData data2)
    {
        if (data1.Diamonds != data2.Diamonds)
            return false;

        if (data1.MaxRange != data2.MaxRange)
            return false;

        if (data1.Language != data2.Language)
            return false;

        if (data1.CurrentSkinIndex != data2.CurrentSkinIndex)
            return false;

        for (int i = 0; i < data1.AreSkinsBuåód.Length; i++)
        {
            if (data1.AreSkinsBuåód[i] != data2.AreSkinsBuåód[i])
                return false;
        }

        return true;
    }
}
