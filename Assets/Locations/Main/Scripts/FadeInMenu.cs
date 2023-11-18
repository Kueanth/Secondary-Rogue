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

    public void SetSubling(int number)
    {
        switch (number)
        {
            case 1:
                transform.SetAsLastSibling();
                break;

            case 2:
                transform.SetAsFirstSibling();
                break;
        }
    }

    public void loadScene()
    {
        SceneManager.LoadScene(1);
    }

    [System.Obsolete]
    public void adView()
    {
        Application.ExternalCall("ShowAdWithoutReward");
    }

    public void ViewAuthBar()
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        auth.Play("OpenAuthBar");
        transform.SetAsFirstSibling();
    }
}
