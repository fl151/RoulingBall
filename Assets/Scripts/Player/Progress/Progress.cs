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
    }

    public static void SetDataFromJSON(string json)
    {
        var data = JsonUtility.FromJson<PlayerData>(json);

        Instance.PlayerData = data;

        Instance.DataLoaded?.Invoke();
    }

    public static void SetWorldRecord(int value)
    {
        Instance._topRangeInWorld = value;
    }
}
