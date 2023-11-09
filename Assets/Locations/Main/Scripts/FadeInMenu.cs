using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FadeInMenu : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene(1);
    }

    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private RawImage _photo;

    [DllImport("__Internal")]
    private static extern void GetDataPlayer();

    public void loadData()
    {
        GetDataPlayer();
    }

    public void GetData(string name)
    {
        _name.text = name;
    }

    public void SetPhoto(string url)
    {
        DownloadImage(url);
    }

    IEnumerator DownloadImage(string mediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(mediaUrl);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            Debug.Log(request.error);
        else
            _photo.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    }
}
