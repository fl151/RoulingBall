using UnityEngine;
using Agava.YandexGames;

public class PlayerData
{
    public int MaxRange;
    public int Diamonds;

    public bool[] AreSkinsBuåód = new bool[6];
    public int CurrentSkinIndex = -1;
}

public class Progress : MonoBehaviour
{
    private int _topRangeInWorld;

    public PlayerData PlayerData;

    public static Progress Instance;

    public int WorldRecordRange => _topRangeInWorld;

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
    }

    public static void SetWorldRecord(int value)
    {
        Instance._topRangeInWorld = value;
    }
}
