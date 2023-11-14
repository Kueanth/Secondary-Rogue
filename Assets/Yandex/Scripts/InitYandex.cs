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

    [DllImport("__Internal")]
    private static extern void AuthPlayer();

    [DllImport("__Internal")]
    private static extern void LoadPlayer();

    [DllImport("__Internal")]
    private static extern void LoadData();

    [DllImport("__Internal")]
    private static extern void RateGame();

    private void Awake()
    {
        if (Progress.Instance.PlayerInfoForGame.auth)
        {
            _button.gameObject.SetActive(false);
            _name.text = Progress.Instance.PlayerInfoForGame.name;
            _photo.texture = Progress.Instance.PlayerInfoForGame.icon;
            animatorAuthPlayer.SetTrigger("authComplete");
        }
    }

    public void AuthButton()
    {
        AuthPlayer();
        StartCoroutine(LoadPlayerCoroutine());
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
        RateGame();
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
            animatorAuthPlayer.SetTrigger("authComplete");
        }
    }

    IEnumerator LoadPlayerCoroutine()
    {
        yield return new WaitForSeconds(3);
        LoadPlayer();
        Progress.Instance.PlayerInfoForGame.auth = true;
        yield break;
    }
}
