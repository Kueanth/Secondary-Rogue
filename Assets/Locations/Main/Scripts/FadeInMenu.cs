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

    [System.Obsolete]
    public void adView()
    {
        Application.ExternalCall("ShowAdWithoutReward");
    }
}
