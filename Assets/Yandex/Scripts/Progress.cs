using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

[System.Serializable]
public class PlayerInfoForSave
{
    public int pet; 
    public int checkedVideo;
    public int levels;
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

    [SerializeField] private Sprite boards;
    [SerializeField] private Sprite forBoard;
    [SerializeField] private GameObject initPet;

    public PlayerInfoForSave PlayerInfoForSave;
    public PlayerInfoForGame PlayerInfoForGame;

    public SceneData sceneData;

    [SerializeField] private TextMeshProUGUI info;

    public bool openPausedBar;

    public bool paused;

    public bool enter;

    public bool buy01, buy02;

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
    }

    public void InfoInit()
    {
        info = GameObject.FindGameObjectWithTag("Info").GetComponent<TextMeshProUGUI>();
    }

    public void addPointPet()
    {
        PlayerInfoForSave.checkedVideo++;
    }

    void PauseGame()
    {
        AudioListener.pause = true;
        sceneData.paused = true;
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        AudioListener.pause = false;
        sceneData.paused = false;
        Time.timeScale = 1;
    }
}
 