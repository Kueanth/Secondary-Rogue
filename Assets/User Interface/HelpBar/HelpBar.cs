using UnityEngine;
using TMPro;

public class HelpBar : MonoBehaviour
{
    [SerializeField] private GameObject[] fields;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject lan;
    [SerializeField] private Animator animator;

    [SerializeField] private TextMeshProUGUI[] text;

    private int index = -1;

    public void Next()
    {
        fields[index].SetActive(false);

        index++;

        if (index == 6)
            index = 0;

        fields[index].SetActive(true);

        switch (index)
        {
            case 0:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[0].text = "Secondary Rogue\n\n" +
                        "This is a game where you can compete with other players for the first place on the leaderboard.The game features pets, a variety of weapons, interesting floor construction, as well as a bunch of different opponents" +
                        "\n\nEveryone who is present on the leaderboard will be given prizes at the end of the season: new pets that will be released in a new update, unique icons and much more";
                else
                    text[0].text = "Secondary Rogue\n" +
                        "Ёто игра, где вы можете соревноватьс€ с другими игроками за первое место в таблице лидеров.  ¬ игре присутствуют питомцы, разнообразное количество оружий, интересное построение этажей, а также кучу разнообразных противников\n" +
                        " аждому кто присутствует в таблице лидеров, будут выданы призы в конце сезона: новые питомцы, которые выйдут в новом обновлении, уникальные иконки а также многое другое";
                break;
        }
    }

    public void Back()
    {
        fields[index].SetActive(false);

        index--;

        if (index == -1)
            index = 5;

        fields[index].SetActive(true);

        switch (index)
        {
            case 0:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[0].text = "Secondary Rogue\n\n" +
                        "This is a game where you can compete with other players for the first place on the leaderboard.The game features pets, a variety of weapons, interesting floor construction, as well as a bunch of different opponents" +
                        "\n\nEveryone who is present on the leaderboard will be given prizes at the end of the season: new pets that will be released in a new update, unique icons and much more";
                else
                    text[0].text = "Secondary Rogue\n" +
                        "Ёто игра, где вы можете соревноватьс€ с другими игроками за первое место в таблице лидеров.  ¬ игре присутствуют питомцы, разнообразное количество оружий, интересное построение этажей, а также кучу разнообразных противников\n" +
                        " аждому кто присутствует в таблице лидеров, будут выданы призы в конце сезона: новые питомцы, которые выйдут в новом обновлении, уникальные иконки а также многое другое";
                break;
        }
    }

    private void OnDisable()
    {
        index = -1;
    }

    public void Open()
    {
        if (Progress.Instance.PlayerInfoForSave.lan == 0)
            lan.SetActive(true);
        else
        {
            bar.SetActive(true);
        }
    }
    
    public void Exit()
    {
        bar.SetActive(false);
    }

    public void First()
    {
        index++;
        fields[index].SetActive(true);

        switch (index)
        {
            case 0:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[0].text = "Secondary Rogue\n\n" +
                        "This is a game where you can compete with other players for the first place on the leaderboard.The game features pets, a variety of weapons, interesting floor construction, as well as a bunch of different opponents" +
                        "\n\nEveryone who is present on the leaderboard will be given prizes at the end of the season: new pets that will be released in a new update, unique icons and much more";
                else
                    text[0].text = "Secondary Rogue\n" +
                        "Ёто игра, где вы можете соревноватьс€ с другими игроками за первое место в таблице лидеров.  ¬ игре присутствуют питомцы, разнообразное количество оружий, интересное построение этажей, а также кучу разнообразных противников\n" +
                        " аждому кто присутствует в таблице лидеров, будут выданы призы в конце сезона: новые питомцы, которые выйдут в новом обновлении, уникальные иконки а также многое другое";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "¬ игре можно взаимодействовать с объектами, которые подсвечиваютс€ желтым цветом. ƒл€ этого необходимо нажать клавишу F. ";
                break;
        }
    }

    public void Close()
    {
        fields[index].SetActive(false);
        animator.Play("HelpBarExit");
    }
}
