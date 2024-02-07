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
                        "��� ����, ��� �� ������ ������������� � ������� �������� �� ������ ����� � ������� �������.  � ���� ������������ �������, ������������� ���������� ������, ���������� ���������� ������, � ����� ���� ������������� �����������\n\n" +
                        "������� ��� ������������ � ������� �������, ����� ������ ����� � ����� ������: ����� �������, ������� ������ � ����� ����������, ���������� ������ � ����� ������ ������";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "� ���� ����� ����������������� � ���������, ������� �������������� ������ ������. ��� ����� ���������� ������ ������� F. ";
                break;

            case 2:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[2].text = "You can move around using the W A S D keys, as well as using the arrows on the keyboard." +
                        "\n\nIn the dungeon, you can reload your weapon using the R button." +
                        "\n\nYou can also pause the game using the Tab button." +
                        "\n\nYou can shoot with a weapon by clicking on the left mouse button(LMB).";
                else
                    text[2].text = "������������� ����� � ������� ������ W A S D, � ����� � ������� ��������� �� ���������. " +
                        "\n\n� ���������� �� ������ ������������ ������, � ������� ������ R." +
                        "\n\n����� �� ������ ��������� ���� �� �����, � ������� ������ Tab." +
                        "\n\n�������� � ������ ����� ������� �� ����� ������ ����(���).";
                break;

            case 3:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[3].text = "There are chasms in the game, falling under which you will fall and lose your health. It is also necessary to avoid enemy shots in order not to lose health.";
                else
                    text[3].text = "� ���� ���� ��������, ����� ��� ������� �� ������� � ��������� ��������. ����� ���������� �������� ��������� �����������, ����� �� �������� ��������. ";
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
                    text[4].text = "����� ����������� �����, �������� ���������� � ���, ��� �� ������ ���� � ����� ����� ���������� ����� ��� � ������� � ���� ������ ������� F.";
                    text[5].text = "�������� ���";
                    text[6].text = "�������� ���";
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
                    text[7].text = "� ����������� ����� ������� �������� � ����� ������� ��� �����������, ������� � ��� �� ������ �� ��������� � ������������." +
                        "\n\n\n\n\n����� � ���� ���� ������� � �������,  �� ������ �� ������� � ������� ������ F";
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
                        "��� ����, ��� �� ������ ������������� � ������� �������� �� ������ ����� � ������� �������.  � ���� ������������ �������, ������������� ���������� ������, ���������� ���������� ������, � ����� ���� ������������� �����������\n\n" +
                        "������� ��� ������������ � ������� �������, ����� ������ ����� � ����� ������: ����� �������, ������� ������ � ����� ����������, ���������� ������ � ����� ������ ������";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "� ���� ����� ����������������� � ���������, ������� �������������� ������ ������. ��� ����� ���������� ������ ������� F. ";
                break;

            case 2:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[2].text = "You can move around using the W A S D keys, as well as using the arrows on the keyboard." +
                        "\n\nIn the dungeon, you can reload your weapon using the R button." +
                        "\n\nYou can also pause the game using the Tab button." +
                        "\n\nYou can shoot with a weapon by clicking on the left mouse button(LMB).";
                else
                    text[2].text = "������������� ����� � ������� ������ W A S D, � ����� � ������� ��������� �� ���������. " +
                        "\n\n� ���������� �� ������ ������������ ������, � ������� ������ R." +
                        "\n\n����� �� ������ ��������� ���� �� �����, � ������� ������ Tab." +
                        "\n\n�������� � ������ ����� ������� �� ����� ������ ����(���).";
                break;

            case 3:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[3].text = "There are chasms in the game, falling under which you will fall and lose your health. It is also necessary to avoid enemy shots in order not to lose health.";
                else
                    text[3].text = "� ���� ���� ��������, ����� ��� ������� �� ������� � ��������� ��������. ����� ���������� �������� ��������� �����������, ����� �� �������� ��������. ";
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
                    text[4].text = "����� ����������� �����, �������� ���������� � ���, ��� �� ������ ���� � ����� ����� ���������� ����� ��� � ������� � ���� ������ ������� F.";
                    text[5].text = "�������� ���";
                    text[6].text = "�������� ���";
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
                    text[7].text = "� ����������� ����� ������� �������� � ����� ������� ��� �����������, ������� � ��� �� ������ �� ��������� � ������������." +
                        "\n\n\n\n\n����� � ���� ���� ������� � �������,  �� ������ �� ������� � ������� ������ F";
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
                        "��� ����, ��� �� ������ ������������� � ������� �������� �� ������ ����� � ������� �������.  � ���� ������������ �������, ������������� ���������� ������, ���������� ���������� ������, � ����� ���� ������������� �����������\n\n" +
                        "������� ��� ������������ � ������� �������, ����� ������ ����� � ����� ������: ����� �������, ������� ������ � ����� ����������, ���������� ������ � ����� ������ ������";
                break;

            case 1:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[1].text = "In the game, you can interact with objects that are highlighted in yellow. To do this, press the F key.";
                else
                    text[1].text = "� ���� ����� ����������������� � ���������, ������� �������������� ������ ������. ��� ����� ���������� ������ ������� F. ";
                break;

            case 2:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[2].text = "You can move around using the W A S D keys, as well as using the arrows on the keyboard." +
                        "\n\nIn the dungeon, you can reload your weapon using the R button." +
                        "\n\nYou can also pause the game using the Tab button." +
                        "\n\nYou can shoot with a weapon by clicking on the left mouse button(LMB).";
                else
                    text[2].text = "������������� ����� � ������� ������ W A S D, � ����� � ������� ��������� �� ���������. " +
                        "\n\n� ���������� �� ������ ������������ ������, � ������� ������ R." +
                        "\n\n����� �� ������ ��������� ���� �� �����, � ������� ������ Tab." +
                        "\n\n�������� � ������ ����� ������� �� ����� ������ ����(���).";
                break;

            case 3:
                if (Progress.Instance.PlayerInfoForSave.lan == 2)
                    text[3].text = "There are chasms in the game, falling under which you will fall and lose your health. It is also necessary to avoid enemy shots in order not to lose health.";
                else
                    text[3].text = "� ���� ���� ��������, ����� ��� ������� �� ������� � ��������� ��������. ����� ���������� �������� ��������� �����������, ����� �� �������� ��������. ";
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
                    text[4].text = "����� ����������� �����, �������� ���������� � ���, ��� �� ������ ���� � ����� ����� ���������� ����� ��� � ������� � ���� ������ ������� F.";
                    text[5].text = "�������� ���";
                    text[6].text = "�������� ���";
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
                    text[7].text = "� ����������� ����� ������� �������� � ����� ������� ��� �����������, ������� � ��� �� ������ �� ��������� � ������������." +
                        "\n\n\n\n\n����� � ���� ���� ������� � �������,  �� ������ �� ������� � ������� ������ F";
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
