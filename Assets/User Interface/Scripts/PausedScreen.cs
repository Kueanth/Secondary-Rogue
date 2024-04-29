using UnityEngine;
using UnityEngine.SceneManagement;
using Leopotam.Ecs;
using UnityEngine.UI;

public class PausedScreen : MonoBehaviour
{
    public GameObject Fade;
    public GameObject GameObj;

    public GameObject pausedScreen;

    public UI ui;

    public EcsEntity player;

    public SceneData sceneData;

    public void Awake()
    {
        if (AudioObject.Instance.isActive)
            button.sprite = sprites[1];
        else
            button.sprite = sprites[0];
    }

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

    public void Three()
    {
        AudioObject.Instance.Quieter();
        player.Get<Player>().rigidbody2D.velocity = Vector2.zero;
        sceneData.paused = true;
    }

    public void Four()
    {
        AudioObject.Instance.Louder();
        Progress.Instance.openPausedBar = false;
        Time.timeScale = 1;
        ui.gameScreen.aim.enabled = true;
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
        GameObj.GetComponent<Animator>().Play("Close");
    }

    public void exitGameEnd()
    {
        sceneData.paused = false;
        PlayerInput.value = 0;
        GameObj.GetComponent<Animator>().Play("ExitGame");
    }

    public void reloadGameEnd()
    {
        sceneData.paused = false;
        PlayerInput.value = 0;
        GameObj.GetComponent<Animator>().Play("ReloadGame");
    }

    public void resumeGameEnd()
    {
        sceneData.paused = false;
        PlayerInput.value = 0;
        GameObj.GetComponent<Animator>().Play("Close");
    }

    public void End()
    {
        AudioObject.Instance.Louder();
        Progress.Instance.openPausedBar = false;;
        Time.timeScale = 1;
        Fade.SetActive(true);
        PlayerInput.value = 0;
        Progress.Instance.openPausedBar = false;
        Fade.GetComponent<Animator>().Play("ExitInRoom");
    }

    public void ReloadFade()
    {
        AudioObject.Instance.Louder();
        Progress.Instance.openPausedBar = false;
        Time.timeScale = 1;
        Fade.SetActive(true);
        PlayerInput.value = 0;
        Progress.Instance.openPausedBar = false;
        Fade.GetComponent<Animator>().Play("ReloadFade");
    }

    public Sprite[] sprites;

    public Image button;

    public void Checked()
    {
        if (AudioObject.Instance.isActive)
            Off();
        else
            On();
    }

    public void On()
    {
        button.sprite = sprites[1];
        AudioObject.Instance.isActive = true;
        AudioObject.Instance.EditMute();
    }

    public void Off()
    {
        button.sprite = sprites[0];
        AudioObject.Instance.isActive = false;
        AudioObject.Instance.EditMute();
    }
}
