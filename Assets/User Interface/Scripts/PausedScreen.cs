using UnityEngine;
using UnityEngine.SceneManagement;
using Leopotam.Ecs;

public class PausedScreen : MonoBehaviour
{
    public GameObject Fade;
    public Animator GameObj;

    public GameObject pausedScreen;

    public UI ui;

    public EcsEntity player;

    public SceneData sceneData;

    public void reloadGame()
    {
        Fade.gameObject.SetActive(true);
        Fade.GetComponent<Animator>().SetTrigger("Em");
    }

    public void exitGame()
    {
        Fade.gameObject.SetActive(true);
        Fade.GetComponent<Animator>().SetTrigger("Gow");
    }

    public void First()
    {
        Progress.Instance.openPausedBar = true;
    }

    public void Second()
    {
        Progress.Instance.openPausedBar = false;
    }

    public void Three()
    {
        player.Get<Player>().rigidbody2D.velocity = Vector2.zero;
        sceneData.paused = true;
    }

    public void Four()
    {
        player.Get<Player>().rigidbody2D.velocity = Vector2.zero;
        sceneData.paused = false;
    }

    public void Open()
    {
        Time.timeScale = 0;
    }

    public void Close()
    {
        Time.timeScale = 1;
    }

    public void Reload()
    {
        GameObj.Play("Close");
    }

    public void exitGameEnd()
    {
        sceneData.paused = false;
        PlayerInput.value = 0;
        GameObj.Play("ExitGame");
    }

    public void reloadGameEnd()
    {
        sceneData.paused = false;
        PlayerInput.value = 0;
        GameObj.Play("ReloadGame");
    }

    public void resumeGameEnd()
    {
        sceneData.paused = false;
        PlayerInput.value = 0;
        GameObj.Play("Close");
    }

    public void End()
    {
        Fade.SetActive(true);
        PlayerInput.value = 0;
        Progress.Instance.openPausedBar = false;
        Fade.GetComponent<Animator>().Play("ExitInRoom");
    }

    public void ReloadFade()
    {
        Fade.SetActive(true);
        PlayerInput.value = 0;
        Progress.Instance.openPausedBar = false;
        Fade.GetComponent<Animator>().Play("ReloadFade");
    }
}
