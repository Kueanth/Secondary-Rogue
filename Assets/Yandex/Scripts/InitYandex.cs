using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InitYandex : MonoBehaviour
{
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
    private static extern void LoadData();

    [DllImport("__Internal")]
    private static extern void RateGame();

    [DllImport("__Internal")]
    private static extern void GetDataInLeaderboards(string rawNameStr, bool includeUser, int quantityTop, int quantityAround);

    private void Start()
    {
        if (Progress.Instance.PlayerInfoForGame.auth)
        {
            _button.gameObject.SetActive(false);
            _name.text = Progress.Instance.PlayerInfoForGame.name;
            _photo.texture = Progress.Instance.PlayerInfoForGame.icon;
            animatorAuthPlayer.SetTrigger("authComplete");
            animatorRating.SetTrigger("authComplete");
            Progress.Instance.InfoInit();
            _authPlayer.enabled = false;
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
        GetDataInLeaderboards("level", true, 5, 2);
        Progress.Instance.PlayerInfoForGame.auth = true;
        loading.SetActive(false);
        Progress.Instance.paused = false;
        yield break;
    }
}
