using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreenAct : MonoBehaviour
{
    public Animator Fade;
    public Animator DeadScreen;

    public void reloadGame()
    {
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("Em");
    }

    public void exitGame()
    {
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("Gow");
    }

    public void adGame()
    {
        gameObject.SetActive(false);
    }

    public void reloadGameBar()
    {
        DeadScreen.SetTrigger("Meow");
    }

    public void exitGameBar()
    {
        DeadScreen.SetTrigger("Gow");
    }

    [System.Obsolete]
    public void exitGameEnd()
    {
        SceneManager.LoadScene(0);
    }

    [System.Obsolete]
    public void reloadGameEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
