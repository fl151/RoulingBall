using System.Runtime.InteropServices;
using UnityEngine;
using SimpleJSON;

[System.Serializable]
public class PlayerData
{
    public float MaxRange;
    public int Diamonds;
}

public class Progress : MonoBehaviour
{
    private float _topRangeInWorld;

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
            LoadData();
            GetTopRange();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(PlayerData);
        SaveData(json);
    }

    public void SetPlayerData(string value)
    {
        PlayerData = JsonUtility.FromJson<PlayerData>(value);
    }

    public void SetTopRange(string jsonString)
    {
       var json = JSON.Parse(jsonString);
        _topRangeInWorld = json["entries"][0]["score"];
    }

    [DllImport("__Internal")]
    private static extern void SaveData(string date);

    [DllImport("__Internal")]
    private static extern string LoadData();

    [DllImport("__Internal")]
    private static extern string GetTopRange();
}
