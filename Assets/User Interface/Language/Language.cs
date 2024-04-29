using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rating rating;
    [SerializeField] private AuthBar authBar;

    public void Russian()
    {
        AudioObject.Instance.Click();
        PlayerPrefs.SetInt("Language", 1);
        authBar.Lan();
        rating.CheckedLan();
        animator.Play("LanguageExit");
    }

    public void English()
    {
        AudioObject.Instance.Click();
        PlayerPrefs.SetInt("Language", 2);
        authBar.Lan();
        rating.CheckedLan();
        animator.Play("LanguageExit");
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        AudioObject.Instance.Click();
        gameObject.SetActive(true);
    }
}