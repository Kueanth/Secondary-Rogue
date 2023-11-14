using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class PlayerInfoForSave
{
    public int levels;
    public int enemys;
    public int money;
}

[System.Serializable]
public class PlayerInfoForGame
{
    public bool auth;
    public Texture2D icon;
    public string name;
}

public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void LoadData();

    [DllImport("__Internal")]
    private static extern void SaveData(string date);

    public PlayerInfoForSave playerInfoForSave;
    public PlayerInfoForGame playerInfoForGame;

    public static Progress Instance;

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

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(playerInfoForSave);
        SaveData(jsonString);
    }

    public void Load(string value)
    {
        playerInfoForSave = JsonUtility.FromJson<PlayerInfoForSave>(value);
    }
}
