using UnityEngine;
using UnityEngine.UI;

public class Rating : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private InitYandex initYandex;

    public int number;

    [SerializeField] private Image[] _you;

    [SerializeField] private Image imageBack;

    [SerializeField] private Sprite[] forImage;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Exit()
    {
        _you[number].rectTransform.sizeDelta = new Vector2(0f, 0f);
        animator.SetTrigger("end");
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        _you[number].rectTransform.sizeDelta = new Vector2(685.907f, 87.065f);
    }

    public void OpenPlayerTop()
    {
        initYandex.Wwww();
        imageBack.sprite = forImage[1];
        
    }

    public void OpenMainTop()
    {
        initYandex.Rrrr();
        imageBack.sprite = forImage[0];
    }
}
