using UnityEngine;

public class Language : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Russian()
    {
        Progress.Instance.PlayerInfoForSave.lan = 1;
        animator.Play("LanguageExit");
    }

    public void English()
    {
        Progress.Instance.PlayerInfoForSave.lan = 2;
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