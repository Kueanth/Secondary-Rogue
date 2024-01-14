using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class Shop : MonoBehaviour
{
    [DllImport("___Internal")]
    private static extern void buyItem(string id);

    [DllImport("___Internal")]
    private static extern void checkedItem();

    [DllImport("___Internal")]
    private static extern void checkedItemConsume();

    [DllImport("___Internal")]
    private static extern void ShowAdWithRewardPet();

    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI[] text;

    [SerializeField] private InitPets initPets;

    public void Exit()
    {
        gameObject.GetComponent<Animator>().Play("ExitShop");
    }

    public void EndAnimation()
    {
        gameObject.SetActive(false);
    }

    public void Enter()
    {
        checkedItem();
        checkedItemConsume();
    }

    // Methods for buttons

    public void InitializationShop()
    {
        if(Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            text[0].text = "������������";
            text[1].text = "������������";
            text[2].text = "������������";

            buttons[0].interactable = true;
            buttons[1].interactable = true;
            buttons[2].interactable = true;
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 500 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            text[0].text = "������������";
            text[1].text = "������������";
            text[2].text = "����������";

            buttons[0].interactable = true;
            buttons[1].interactable = true;
            buttons[2].interactable = false;
        }
        else if(Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 500)
        {
            text[0].text = "������������";
            text[1].text = "����������";
            text[2].text = "����������";

            buttons[0].interactable = true;
            buttons[1].interactable = false;
            buttons[2].interactable = false;
        }
        else
        {
            text[0].text = "����������";
            text[1].text = "����������";
            text[2].text = "����������";

            buttons[0].interactable = false;
            buttons[1].interactable = false;
            buttons[2].interactable = false;
        }
        
        if(Progress.Instance.PlayerInfoForSave.checkedVideo != 10)
        {
            text[3].text = $"{Progress.Instance.PlayerInfoForSave.checkedVideo} / 10"; 
        }
        else
        {
            text[3].text = "������������";
        }
    }

    public void Checked01(int value)
    {
        if(value == 1)
        {
            text[5].text = "������������";
            Progress.Instance.buy01 = true;
        }
        else
        {
            text[5].text = "105 ��";
        }
    }

    public void Checked02(int value)
    {
        if (value == 1)
        {
            text[6].text = "������������";
            Progress.Instance.buy02 = true;
        }
        else
        {
            text[6].text = "750 ��";
        }
    }

    public void One()
    {
        Progress.Instance.PlayerInfoForSave.pet = 0;
        initPets.Delete();
    }

    public void Two()
    {
        Progress.Instance.PlayerInfoForSave.pet = 1;
        initPets.Delete();
    }

    public void Three()
    {
        if(Progress.Instance.PlayerInfoForSave.checkedVideo == 10)
        {
            text[3].text = "������������";
            Progress.Instance.PlayerInfoForSave.pet = 2;
            initPets.Delete();
        }
        else
        {
            ShowAdWithRewardPet();
        }
    }

    public void Four()
    {
        Progress.Instance.PlayerInfoForSave.pet = 3;
        initPets.Delete();
    }

    public void Five()
    {
        if(Progress.Instance.buy02)
        {
            Progress.Instance.PlayerInfoForSave.pet = 4;
            initPets.Delete();
        }
        else
        {
            buyItem("02");
        }
    }

    public void Six()
    {
        if (Progress.Instance.buy01)
        {
            Progress.Instance.PlayerInfoForSave.pet = 5;
            initPets.Delete();
        }
        else
        {
            buyItem("01");
        }
    }
}