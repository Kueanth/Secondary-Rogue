using UnityEngine;
using UnityEngine.UI;

public class MusicManagment : MonoBehaviour
{
    public Sprite[] sprites;

    public Image button;

    public void Awake()
    {
        if (AudioObject.Instance.isActive)
            button.sprite = sprites[1];
        else
            button.sprite = sprites[0];
    }

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