using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;

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

    public PlayerInfoForSave PlayerInfoForSave;
    public PlayerInfoForGame PlayerInfoForGame;

    [SerializeField] private TextMeshProUGUI info;

    public bool paused;

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
        string jsonString = JsonUtility.ToJson(PlayerInfoForSave);
        SaveData(jsonString);
    }

    public void Load(string value)
    {
        PlayerInfoForSave = JsonUtility.FromJson<PlayerInfoForSave>(value);

        info.text = "Количество пройденных этажей: " + PlayerInfoForSave.levels.ToString() + '\n' +
                    "Количество монет: " + PlayerInfoForSave.money.ToString() + '\n' +
                    "Количество убитых противников: " + PlayerInfoForSave.enemys.ToString();
    }

    public void InfoInit()
    {
        info = GameObject.FindGameObjectWithTag("Info").GetComponent<TextMeshProUGUI>();

        info.text = "Количество пройденных этажей: " + PlayerInfoForSave.levels.ToString() + '\n' +
                    "Количество монет: " + PlayerInfoForSave.money.ToString() + '\n' +
                    "Количество убитых противников: " + PlayerInfoForSave.enemys.ToString();
    }
}
