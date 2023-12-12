using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

[System.Serializable]
public class Leaderboard
{
    public List<LeaderboardEntries> entries;
}

[System.Serializable]
public class LeaderboardEntries
{
    public string publicName;
    public string imageURL;
    public int rank;
    public int score;
}


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
    public Leaderboard leaderboard;

    [SerializeField] private RawImage[] _photos;
    [SerializeField] private TextMeshProUGUI[] _rate;
    [SerializeField] private TextMeshProUGUI[] _score;
    [SerializeField] private TextMeshProUGUI[] _name;

    [SerializeField] private TextMeshProUGUI info;

    public bool paused;

    public bool enter;

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

    public void LoadLeaderboard(string value)
    {
        leaderboard = JsonUtility.FromJson<Leaderboard>(value);

        /* info.text = leaderboard.entries[0].rank + ": " + leaderboard.entries[0].publicName + " - " + leaderboard.entries[0].score
            + '\n' + leaderboard.entries[1].rank + ": " + leaderboard.entries[1].publicName + " - " + leaderboard.entries[1].score
        + '\n' + leaderboard.entries[2].rank + ": " + leaderboard.entries[2].publicName + " - " + leaderboard.entries[2].score; */

        StartCoroutine(DownloadImage(leaderboard.entries[0].imageURL, 0, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[1].imageURL, 1, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[2].imageURL, 2, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[3].imageURL, 3, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[4].imageURL, 4, leaderboard));
    }

    public void Load(string value)
    {
        PlayerInfoForSave = JsonUtility.FromJson<PlayerInfoForSave>(value);

        /* info.text += "Количество пройденных этажей: " + PlayerInfoForSave.levels.ToString() + '\n' +
                    "Количество монет: " + PlayerInfoForSave.money.ToString() + '\n' +
                    "Количество убитых противников: " + PlayerInfoForSave.enemys.ToString(); */
    }

    public void InfoInit()
    {
        info = GameObject.FindGameObjectWithTag("Info").GetComponent<TextMeshProUGUI>();

        /* info.text += "Количество пройденных этажей: " + PlayerInfoForSave.levels.ToString() + '\n' +
                    "Количество монет: " + PlayerInfoForSave.money.ToString() + '\n' +
                    "Количество убитых противников: " + PlayerInfoForSave.enemys.ToString(); */
    }

    IEnumerator DownloadImage(string mediaUrl, int i, Leaderboard leaderboard)
    {
        _score[i].text = Convert.ToString(leaderboard.entries[i].score);
        _rate[i].text = Convert.ToString(leaderboard.entries[i].rank);
        _name[i].text = Convert.ToString(leaderboard.entries[i].publicName);

        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
        {
            _photos[i].texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        }
    }
}
