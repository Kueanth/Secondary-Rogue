using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FadeInMenu : MonoBehaviour
{
    [SerializeField] private Animator auth;
    [SerializeField] private GameObject player;

    [DllImport("__Internal")]
    private static extern void OpenGame();
    
    public void SetSubling(int number)
    {
        switch (number)
        {
            case 1:
                transform.SetAsLastSibling();
                Progress.Instance.paused = true;
                break;

            case 2:
                transform.SetAsFirstSibling();
                Progress.Instance.paused = false;
                break;
        }
    }

    public void loadScene()
    {
        Progress.Instance.enter = false;
        SceneManager.LoadScene(1);
    }

    [System.Obsolete]
    public void adView()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        OpenGame();
#endif
    }

    public void ViewAuthBar()
    {
        
    }

    public void EnterDungeon()
    {
        StartCoroutine(AudioObject.Instance.EnterInDungeon());
    }
}
