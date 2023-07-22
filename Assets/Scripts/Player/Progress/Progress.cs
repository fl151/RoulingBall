using UnityEngine;
using Agava.YandexGames;
using UnityEngine.Events;

public class PlayerData
{
    public int MaxRange;
    public int Diamonds;

    public bool[] AreSkinsBu��d = new bool[6];
    public int CurrentSkinIndex;
}

public class Progress : MonoBehaviour
{
    private int _topRangeInWorld;

    public PlayerData PlayerData;

    public static Progress Instance;

    public int WorldRecordRange => _topRangeInWorld;

    public event UnityAction DataLoaded;

    private void Awake()
    {
        if(Instance == null)
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
