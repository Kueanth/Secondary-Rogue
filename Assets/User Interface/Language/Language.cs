using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rating rating;

    public void Russian()
    {
        Progress.Instance.PlayerInfoForSave.lan = 1;
        rating.CheckedLan();
        animator.Play("LanguageExit");
    }

    public void English()
    {
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
        gameObject.SetActive(true);
    }
}