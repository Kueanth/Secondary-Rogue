using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rating rating;

    public void Russian()
    {
        AudioObject.Instance.Click();
        Progress.Instance.PlayerInfoForSave.lan = 1;
        rating.CheckedLan();
        animator.Play("LanguageExit");
    }

    public void English()
    {
        AudioObject.Instance.Click();
        Progress.Instance.PlayerInfoForSave.lan = 2;
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