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
                    text[0].text = "Secondary Rogue\n\n" +
                        "Это игра, где вы можете соревноваться с другими игроками за первое место в таблице лидеров.  В игре присутствуют питомцы, разнообразное количество оружий, интересное построение этажей, а также кучу разнообразных противников\n\n" +
                        "Каждому кто присутствует в таблице лидеров, будут выданы призы в конце сезона: новые питомцы, которые выйдут в новом обновлении, уникальные иконки а также многое другое";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "В игре можно взаимодействовать с объектами, которые подсвечиваются желтым цветом. Для этого необходимо нажать клавишу F. ";
                break;

            case 2:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[2].text = "You can move around using the W A S D keys, as well as using the arrows on the keyboard." +
                        "\n\nIn the dungeon, you can reload your weapon using the R button." +
                        "\n\nYou can also pause the game using the Tab button." +
                        "\n\nYou can shoot with a weapon by clicking on the left mouse button(LMB).";
                else
                    text[2].text = "Передвигаться можно с помощью клавиш W A S D, а также с помощью стрелочек на клавитуре. " +
                        "\n\nВ подземелье вы можете перезарядить оружие, с помощью кнопки R." +
                        "\n\nТакже вы можете поставить игру на паузу, с помощью кнопки Tab." +
                        "\n\nСтрелять с оружия можно нажимая на левую кнопку мыши(ЛКМ).";
                break;

            case 3:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[3].text = "There are chasms in the game, falling under which you will fall and lose your health. It is also necessary to avoid enemy shots in order not to lose health.";
                else
                    text[3].text = "В игре есть пропасти, попав под которые вы упадете и потеряете здоровье. Также необходимо избегать выстрелов противников, чтобы не потерять здоровье. ";
                break;

            case 4:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                {
                    text[4].text = "After passing the floor, information will appear that you have passed the floor and after that you need to find the hatch and go to it and press the F key.";
                    text[5].text = "The open hatch";
                    text[6].text = "Closed hatch";
                }
                else
                {
                    text[4].text = "После прохождения этажа, появится информация о том, что вы прошли этаж и после этого необходимо найти люк и подойдя к нему нажать клавишу F.";
                    text[5].text = "Открытый люк";
                    text[6].text = "Закрытый люк";
                }
                break;

            case 5:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                {
                    text[7].text = "Opponents can lose and drop health or ammunition for reloading, going up to them you can pick them up and use them." +
                        "\n\n\n\n\nThere are also chests of weapons in the game, you can open them with the F button";
                }
                else
                {
                    text[7].text = "С противников может выпасть здоровье а также патроны для перезарядки, подойдя к ним вы можете их подобрать и использовать." +
                        "\n\n\n\n\nТакже в игре есть сундуки с оружием,  вы можете их открыть с помощью кнопки F";
                }
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
                    text[0].text = "Secondary Rogue\n\n" +
                        "Это игра, где вы можете соревноваться с другими игроками за первое место в таблице лидеров.  В игре присутствуют питомцы, разнообразное количество оружий, интересное построение этажей, а также кучу разнообразных противников\n\n" +
                        "Каждому кто присутствует в таблице лидеров, будут выданы призы в конце сезона: новые питомцы, которые выйдут в новом обновлении, уникальные иконки а также многое другое";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "В игре можно взаимодействовать с объектами, которые подсвечиваются желтым цветом. Для этого необходимо нажать клавишу F. ";
                break;

            case 2:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[2].text = "You can move around using the W A S D keys, as well as using the arrows on the keyboard." +
                        "\n\nIn the dungeon, you can reload your weapon using the R button." +
                        "\n\nYou can also pause the game using the Tab button." +
                        "\n\nYou can shoot with a weapon by clicking on the left mouse button(LMB).";
                else
                    text[2].text = "Передвигаться можно с помощью клавиш W A S D, а также с помощью стрелочек на клавитуре. " +
                        "\n\nВ подземелье вы можете перезарядить оружие, с помощью кнопки R." +
                        "\n\nТакже вы можете поставить игру на паузу, с помощью кнопки Tab." +
                        "\n\nСтрелять с оружия можно нажимая на левую кнопку мыши(ЛКМ).";
                break;

            case 3:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[3].text = "There are chasms in the game, falling under which you will fall and lose your health. It is also necessary to avoid enemy shots in order not to lose health.";
                else
                    text[3].text = "В игре есть пропасти, попав под которые вы упадете и потеряете здоровье. Также необходимо избегать выстрелов противников, чтобы не потерять здоровье. ";
                break;

            case 4:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                {
                    text[4].text = "After passing the floor, information will appear that you have passed the floor and after that you need to find the hatch and go to it and press the F key.";
                    text[5].text = "The open hatch";
                    text[6].text = "Closed hatch";
                }
                else
                {
                    text[4].text = "После прохождения этажа, появится информация о том, что вы прошли этаж и после этого необходимо найти люк и подойдя к нему нажать клавишу F.";
                    text[5].text = "Открытый люк";
                    text[6].text = "Закрытый люк";
                }
                break;

            case 5:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                {
                    text[7].text = "Opponents can lose health and ammunition for reloading, going up to them you can pick them up and use them." +
                        "\n\n\n\n\nThere are also chests of weapons in the game, you can open them with the F button";
                }
                else
                {
                    text[7].text = "С противников может выпасть здоровье а также патроны для перезарядки, подойдя к ним вы можете их подобрать и использовать." +
                        "\n\n\n\n\nТакже в игре есть сундуки с оружием,  вы можете их открыть с помощью кнопки F";
                }
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
                    text[0].text = "Secondary Rogue\n\n" +
                        "Это игра, где вы можете соревноваться с другими игроками за первое место в таблице лидеров.  В игре присутствуют питомцы, разнообразное количество оружий, интересное построение этажей, а также кучу разнообразных противников\n\n" +
                        "Каждому кто присутствует в таблице лидеров, будут выданы призы в конце сезона: новые питомцы, которые выйдут в новом обновлении, уникальные иконки а также многое другое";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "В игре можно взаимодействовать с объектами, которые подсвечиваются желтым цветом. Для этого необходимо нажать клавишу F. ";
                break;

            case 2:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[2].text = "You can move around using the W A S D keys, as well as using the arrows on the keyboard." +
                        "\n\nIn the dungeon, you can reload your weapon using the R button." +
                        "\n\nYou can also pause the game using the Tab button." +
                        "\n\nYou can shoot with a weapon by clicking on the left mouse button(LMB).";
                else
                    text[2].text = "Передвигаться можно с помощью клавиш W A S D, а также с помощью стрелочек на клавитуре. " +
                        "\n\nВ подземелье вы можете перезарядить оружие, с помощью кнопки R." +
                        "\n\nТакже вы можете поставить игру на паузу, с помощью кнопки Tab." +
                        "\n\nСтрелять с оружия можно нажимая на левую кнопку мыши(ЛКМ).";
                break;

            case 3:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[3].text = "There are chasms in the game, falling under which you will fall and lose your health. It is also necessary to avoid enemy shots in order not to lose health.";
                else
                    text[3].text = "В игре есть пропасти, попав под которые вы упадете и потеряете здоровье. Также необходимо избегать выстрелов противников, чтобы не потерять здоровье. ";
                break;

            case 4:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                {
                    text[4].text = "After passing the floor, information will appear that you have passed the floor and after that you need to find the hatch and go to it and press the F key.";
                    text[5].text = "The open hatch";
                    text[6].text = "Closed hatch";
                }
                else
                {
                    text[4].text = "После прохождения этажа, появится информация о том, что вы прошли этаж и после этого необходимо найти люк и подойдя к нему нажать клавишу F.";
                    text[5].text = "Открытый люк";
                    text[6].text = "Закрытый люк";
                }
                break;

            case 5:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                {
                    text[7].text = "Opponents can lose health and ammunition for reloading, going up to them you can pick them up and use them." +
                        "\n\n\n\n\nThere are also chests of weapons in the game, you can open them with the F button";
                }
                else
                {
                    text[7].text = "С противников может выпасть здоровье а также патроны для перезарядки, подойдя к ним вы можете их подобрать и использовать." +
                        "\n\n\n\n\nТакже в игре есть сундуки с оружием,  вы можете их открыть с помощью кнопки F";
                }
                break;
        }
    }

    public void Close()
    {
        fields[index].SetActive(false);
        animator.Play("HelpBarExit");
    }
}
