using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

[System.Serializable]
public class PLayerLeaderboard
{
    public string publicName;
    public int rank;
    public int score;
}

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
    public static Leaderboard leaderboard;
    public PLayerLeaderboard playerLeaderboard;

    [SerializeField] private RawImage[] _photos;
    [SerializeField] private TextMeshProUGUI[] _rate;
    [SerializeField] private TextMeshProUGUI[] _score;
    [SerializeField] private TextMeshProUGUI[] _names;
    [SerializeField] private Image[] _boards;
    [SerializeField] private Sprite[] _boardSet;
    [SerializeField] private Sprite[] _playerAuthBoardSet;
    [SerializeField] private Image _board;
    [SerializeField] private Image _playerAuthBoard;

    public GameObject Rating;

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private RawImage _photo;
    [SerializeField] private Button _button;
    [SerializeField] private Animator animatorAuthPlayer;
    [SerializeField] private Animator animatorRating;
    [SerializeField] private GameObject _authPlayer;
    [SerializeField] private Animator auth;
    [SerializeField] private GameObject loading;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject initPet;

    [DllImport("__Internal")]
    private static extern void AuthPlayer();

    [DllImport("__Internal")]
    private static extern void checkedItem();

    [DllImport("__Internal")]
    private static extern void CheckPlayer();

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

    [DllImport("__Internal")]
    private static extern void AskSetLeaderboardScore(string rawNameStr);

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
            IsPlayerAuth();
#endif

        if (Progress.Instance.PlayerInfoForGame.auth)
        {

#if UNITY_WEBGL && !UNITY_EDITOR
            GetDataInLeaderboards("levels", true, 5, 5);
#endif

            _button.gameObject.SetActive(false);
            _name.text = Progress.Instance.PlayerInfoForGame.name;
            _photo.texture = Progress.Instance.PlayerInfoForGame.icon;
            animatorAuthPlayer.SetTrigger("authComplete");
            Progress.Instance.InfoInit();
            checkedItem();
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
        _authPlayer.GetComponent<Animator>().Play("CloseAuthBar");
        auth.Play("AuthButtonInit");
    }

    public void GetName(string name)
    {
        if(name != "")
            _name.text = name;

        _button.gameObject.SetActive(false);
        Progress.Instance.PlayerInfoForGame.name = name;
    }

    public void RateGameButton()
    {
        if (Progress.Instance.PlayerInfoForGame.auth)
        {
            RateGame();
        }
        else
        {
            _authPlayer.GetComponent<Animator>().Play("OpenAuthBar");
        }
    }

    public void GetPhoto(string url)
    {
        StartCoroutine(DownloadImage(url));
    }

    public void LoadAuthBar()
    {
        _authPlayer.GetComponent<Animator>().Play("OpenAuthBar");
    }

    public void Gow(string value)
    {
        leaderboard = JsonUtility.FromJson<Leaderboard>(value);

        StartCoroutine(DownloadImage(leaderboard.entries[0].imageURL, 0, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[1].imageURL, 1, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[2].imageURL, 2, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[3].imageURL, 3, leaderboard));
        StartCoroutine(DownloadImage(leaderboard.entries[4].imageURL, 4, leaderboard));

        AskSetLeaderboardScore("levels");
    }

    public void Rrrr()
    {
        StartCoroutine(DownloadImage(leaderboard.entries[0].imageURL, 0, leaderboard, true));
        StartCoroutine(DownloadImage(leaderboard.entries[1].imageURL, 1, leaderboard, true));
        StartCoroutine(DownloadImage(leaderboard.entries[2].imageURL, 2, leaderboard, true));
        StartCoroutine(DownloadImage(leaderboard.entries[3].imageURL, 3, leaderboard, true));
        StartCoroutine(DownloadImage(leaderboard.entries[9].imageURL, 4, leaderboard, true));
    }

    public void Wwww()
    {
        StartCoroutine(DownloadImage(leaderboard.entries[5].imageURL, 0, leaderboard, false));
        StartCoroutine(DownloadImage(leaderboard.entries[6].imageURL, 1, leaderboard, false));
        StartCoroutine(DownloadImage(leaderboard.entries[7].imageURL, 2, leaderboard, false));
        StartCoroutine(DownloadImage(leaderboard.entries[8].imageURL, 3, leaderboard, false));
        StartCoroutine(DownloadImage(leaderboard.entries[9].imageURL, 4, leaderboard, false));
    }

    public void Meow(string value)
    {
        playerLeaderboard = JsonUtility.FromJson<PLayerLeaderboard>(value);

        for(int i = 0; i < 5; i++)
        {
            if (playerLeaderboard.rank == i)
            {
                Rating.GetComponent<Rating>().number = i - 1;
            }
        }

        _text.text = $"Ваше место в рейтинге: {playerLeaderboard.rank}";
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);


        _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Progress.Instance.PlayerInfoForGame.icon = ((DownloadHandlerTexture)request.downloadHandler).texture;
        _button.gameObject.SetActive(false);
        LoadData();
        GetDataInLeaderboards("levels", true, 5, 5);
        _authPlayer.SetActive(false);
        Progress.Instance.PlayerInfoForGame.auth = true;
        animatorAuthPlayer.SetTrigger("authComplete");
        Progress.Instance.InfoInit();
        initPet.GetComponent<InitPets>().Delete();

        if (Progress.Instance.PlayerInfoForSave.levels < 100)
        {
            _playerAuthBoard.sprite = _playerAuthBoardSet[0];
            _board.sprite = _boardSet[0];

        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            _playerAuthBoard.sprite = _playerAuthBoardSet[1];
            _board.sprite = _boardSet[1];
        }
        else
        {
            _playerAuthBoard.sprite = _playerAuthBoardSet[2];
            _board.sprite = _boardSet[2];
        }
    }

    IEnumerator LoadPlayerCoroutine()
    {
        yield return new WaitForSeconds(3);
        CheckPlayer();
        LoadPlayer();
        LoadData();
        loading.SetActive(false);
        Progress.Instance.paused = false;
        yield break;
    }

    IEnumerator DownloadImage(string mediaUrl, int i, Leaderboard leaderboard, bool temp = true)
    {
        if (leaderboard.entries[i].score < 100)
            _boards[i].sprite = _boardSet[0];
        else if(leaderboard.entries[i].score >= 100 && leaderboard.entries[i].score < 1000)
            _boards[i].sprite = _boardSet[1];
        else
            _boards[i].sprite = _boardSet[2];

        _score[i].text = Convert.ToString(leaderboard.entries[i].score);
        _rate[i].text = Convert.ToString(leaderboard.entries[i].rank);

        if (Convert.ToString(leaderboard.entries[i].publicName) == "")
            _names[i].text = "Пользователь скрыт";
        else
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
