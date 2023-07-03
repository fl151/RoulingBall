using System.Collections;
using Agava.YandexGames;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float MaxRange;
    public int Diamonds;
}

public class Progress : MonoBehaviour
{
    private float _topRangeInWorld = 0;

    public PlayerData PlayerData;

    public static Progress Instance;

    public float WorldRecordRange => _topRangeInWorld;

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

    public static void Save()
    {
        if(PlayerAccount.IsAuthorized)
            PlayerAccount.SetCloudSaveData(JsonUtility.ToJson(Instance.PlayerData));
    }

    public static void SetData(string json)
    {
        Instance.PlayerData = JsonUtility.FromJson<PlayerData>(json);
    }

    public static void SetWorldRecord(int value)
    {
        Instance._topRangeInWorld = value;
    }

}
