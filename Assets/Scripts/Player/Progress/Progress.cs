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
        if (PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(JsonUtility.ToJson(Instance.PlayerData));

        PlayerPrefs.SetString("data", JsonUtility.ToJson(Instance.PlayerData));
        PlayerPrefs.Save();
    }

    public static void SetDataFromJSON(string json)
    {
        var dataCloud = JsonUtility.FromJson<PlayerData>(json);

        var dataPrefs = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("data"));

        if (dataCloud == dataPrefs)
            return;
        else if (dataPrefs == default)
            SetData(dataCloud);
        else
            AskUserAboutProgress(dataCloud);
    }

    public static void SetWorldRecord(int value)
    {
        Instance._topRangeInWorld = value;
    }

    public static void SetData(PlayerData data)
    {
        Instance.PlayerData = data;
        Instance.DataLoaded?.Invoke();
        SaveDataCloud();
    }

    private static void AskUserAboutProgress(PlayerData dataCloud)
    {
        Instance.NeedAsk?.Invoke(dataCloud);
    }
}
