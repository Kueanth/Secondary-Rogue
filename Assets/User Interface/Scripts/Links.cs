using UnityEngine;

public class Links : MonoBehaviour
{
    public void OpenTelegram()
    {
        AudioObject.Instance.Click();
        Application.OpenURL("https://t.me/dislabel");
    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/kueanth/");
    }

    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCcea6fkLzA2R-dM0ofw8suw");
    }
}
