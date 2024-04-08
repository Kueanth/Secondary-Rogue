using UnityEngine;
using TMPro;

public class AuthBar : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private TextMeshProUGUI[] text;

    public void Ep()
    {
        Progress.Instance.paused = true;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<Animator>().SetBool("Paused", true);
        Player.GetComponent<Animator>().Play("Idle");
    }
    
    public void Gow()
    {
        Progress.Instance.paused = false;
        Player.GetComponent<Animator>().SetBool("Paused", false);
    }

    public void Lan()
    {
        if(PlayerPrefs.GetInt("Language") == 2)
        {
            text[0].text = "You can play as a guest in the game, as well as log in. If you log in, you will be able to: rate the game, be on the leaderboard, purchase donation items and also save your rating, which will allow you to compete with other players!";
            text[1].text = "Auth";
        }
        else
        {
            text[0].text = "¬ игре можно играть как гость, а также авторизоватьс€. ≈сли вы авторизуетесь, вы сможете: оценить игру, находитьс€ в таблице лидеров, приобрести донатные предметы а также сохранить свой рейтинг, что позволит вам соревноватьс€ с другими игроками!";
            text[1].text = "јвторизоватьс€";
        }
    }
}
