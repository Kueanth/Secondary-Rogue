using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
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

public class InitYandex : MonoBehaviour
{
    public Leaderboard leaderboard;

    [SerializeField] private RawImage[] _photos;
    [SerializeField] private TextMeshProUGUI[] _rate;
    [SerializeField] private TextMeshProUGUI[] _score;
    [SerializeField] private TextMeshProUGUI[] _names;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private RawImage _photo;

    [SerializeField] private Button _button;

    [SerializeField] private Animator animatorAuthPlayer;
    [SerializeField] private Animator animatorRating;

    [SerializeField] private Animator _authPlayer;

    [SerializeField] private Animator auth;

    [SerializeField] private GameObject loading;

    [DllImport("__Internal")]
    private static extern void AuthPlayer();

    [DllImport("__Internal")]
    private static extern void LoadPlayer();

    [DllImport("__Internal")]
    private static extern void IsPlayerAuth();

    [DllImport("__Internal")]
    private static extern void LoadData();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void GetDataInLeaderboards(string rawNameStr, bool includeUser, int quantityTop, int quantityAround);

    private void Start()
    {
        if (Progress.Instance.PlayerInfoForGame.auth)
        {

#if UNITY_WEBGL && !UNITY_EDITOR
            GetDataInLeaderboards("levels", true, 5, 2);
#endif

            _button.gameObject.SetActive(false);
            _name.text = Progress.Instance.PlayerInfoForGame.name;
            _photo.texture = Progress.Instance.PlayerInfoForGame.icon;
            animatorAuthPlayer.SetTrigger("authComplete");
            animatorRating.SetTrigger("authComplete");
            Progress.Instance.InfoInit();   
        }
        else
        {
#if UNITY_WEBGL && !UNITY_EDITOR
            IsPlayerAuth();
#endif
        }
    }

    public void AuthButton()
    {
        Progress.Instance.paused = true;
        loading.SetActive(true);
        AuthPlayer();
        StartCoroutine(LoadPlayerCoroutine());
    }

    public void CloseAuthBar()
    {
        _authPlayer.Play("CloseAuthBar");
        auth.Play("AuthButtonInit");
    }

    public void GetName(string name)
    {
        if(name != "")
        {
            _name.text = name;
            _button.gameObject.SetActive(false);
            Progress.Instance.PlayerInfoForGame.name = name;
        }
    }

    public void RateGameButton()
    {
        if (Progress.Instance.PlayerInfoForGame.auth)
        {
            RateGame();
        }
        else
        {
            _authPlayer.Play("OpenAuthBar");
        }
    }

    public void GetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    public void LoadAuthBar(int aug)
    {
        if (aug == 0)
            _authPlayer.Play("OpenAuthBar");
    }

    public void Gow(string value)
    {
        leaderboard = JsonUtility.FromJson<Leaderboard>(value);

        StartCoroutine(DownloadImage(leaderboard.entries[0].imageURL, 0, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[1].imageURL, 1, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[2].imageURL, 2, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[3].imageURL, 3, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[4].imageURL, 4, leaderboard));
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else if(_name.text != "")
        {
            _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Progress.Instance.PlayerInfoForGame.icon = ((DownloadHandlerTexture)request.downloadHandler).texture;
            _button.gameObject.SetActive(false);
            LoadData();
            GetDataInLeaderboards("levels", true, 5, 2);
            Progress.Instance.PlayerInfoForGame.auth = true;
            animatorAuthPlayer.SetTrigger("authComplete");
            animatorRating.SetTrigger("authComplete");
            if (_authPlayer.enabled) _authPlayer.Play("CloseAuthBar");
            Progress.Instance.InfoInit();
        }
    }

    IEnumerator LoadPlayerCoroutine()
    {
        yield return new WaitForSeconds(3);
        LoadPlayer();
        LoadData();
        loading.SetActive(false);
        Progress.Instance.paused = false;
        yield break;
    }

    IEnumerator DownloadImage(string mediaUrl, int i, Leaderboard leaderboard)
    {
        _score[i].text = Convert.ToString(leaderboard.entries[i].score);
        _rate[i].text = Convert.ToString(leaderboard.entries[i].rank);
        _names[i].text = Convert.ToString(leaderboard.entries[i].publicName);

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
