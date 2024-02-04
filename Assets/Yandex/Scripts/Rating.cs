using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rating : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private InitYandex initYandex;

    [SerializeField] private TextMeshProUGUI[] text;

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

    public void CheckedLan()
    {
        if(Progress.Instance.PlayerInfoForSave.lan == 2)
        {
            for(int i = 0; i < 5; i++)
            {
                text[i].text = "Absent";
            }

            text[5].text = "- The first season -";
            text[6].text = "The best players this season";
            text[7].text = "Your place in the ranking: -";
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                text[i].text = "Отсутствует";
            }

            text[5].text = "- Первый сезон -";
            text[6].text = "Лучшие игроки в этом сезоне";
            text[7].text = "Ваше место в рейтинге: -";
        }
    }
}
