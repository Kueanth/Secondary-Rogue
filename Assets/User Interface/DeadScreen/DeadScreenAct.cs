using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadScreenAct : MonoBehaviour
{
    public Animator Fade;
    public Animator DeadScreen;

    public void reloadGame()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("Em");
    }

    public void exitGame()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        Fade.gameObject.SetActive(true);
        Fade.SetTrigger("Gow");
    }

    public void adGame()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        gameObject.SetActive(false);
    }

    public void reloadGameBar()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        DeadScreen.SetTrigger("Meow");
    }

    public void exitGameBar()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        DeadScreen.SetTrigger("Gow");
    }

    [System.Obsolete]
    public void exitGameEnd()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        SceneManager.LoadScene(0);
    }

    [System.Obsolete]
    public void reloadGameEnd()
    {
#if Unity_WEBGL
        Progress.Instance.Save();
#endif
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
