using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreenAct : MonoBehaviour
{
    public Animator Fade;
    public Animator DeadScreen;

    public void reloadGame()
    {
        AudioObject.Instance.Louder();
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("Em");
    }

    public void exitGame()
    {
        AudioObject.Instance.Louder();
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

    public void exitGameEnd()
    {
        SceneManager.LoadScene(0);
    }

    public void reloadGameEnd()
    {
        AudioObject.Instance.Louder();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void endGameAdBar()
    {
        AudioObject.Instance.Louder();
    }

    public void Awake()
    {
        AudioObject.Instance.Quieter();
    }
}
