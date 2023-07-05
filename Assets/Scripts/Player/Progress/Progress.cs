using Agava.YandexGames;
using UnityEngine;

public class PlayerData
{
    public int MaxRange;
    public int Diamonds;
    public bool IsAskedAboutPersonalData;
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
        if(PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(JsonUtility.ToJson(Instance.PlayerData));
    }

    public static void SetDataFromJSON(string json)
    {
        Instance.PlayerData = JsonUtility.FromJson<PlayerData>(json);
    }

    public static void SetWorldRecord(int value)
    {
        Instance._topRangeInWorld = value;
    }

}
