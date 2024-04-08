using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class Rating : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private InitYandex initYandex;

    [SerializeField] private TextMeshProUGUI[] text;

    public int number;

    [SerializeField] private Image[] _you;

    [SerializeField] private Image imageBack;

    [SerializeField] private Sprite[] forImage;

    [SerializeField] private InitYandex _initYandex;

    [DllImport("__Internal")]
    private static extern void AskSetLeaderboardScore(string rawNameStr);

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Exit()
    {
        AudioObject.Instance.Click();
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
        if(PlayerPrefs.GetInt("Language") == 2)
        {
            for(int i = 0; i < 5; i++)
            {
                if (text[i].text == "Отсутствует")
                text[i].text = "Absent";
            }

            text[5].text = "- The first season -";
            text[6].text = "The best players this season";
            text[7].text = "Your place in the ranking: " + _initYandex.playerLeaderboard.rank;

            text[8].text = "Auth";
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                if (text[i].text == "Absent")
                    text[i].text = "Отсутствует";
            }

            text[5].text = "- Первый сезон -";
            text[6].text = "Лучшие игроки в этом сезоне";
            text[7].text = "Ваше место в рейтинге: " + _initYandex.playerLeaderboard.rank;

            text[8].text = "Авторизация";
        }
    }
}
