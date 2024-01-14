using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class Shop : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void buyItem(string id);

    [DllImport("__Internal")]
    private static extern void checkedItem();

    [DllImport("__Internal")]
    private static extern void checkedItemConsume();

    [DllImport("__Internal")]
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
    }

    // Methods for buttons

    public void InitializationShop()
    {
        if(Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            text[0].text = "Использовать";
            text[1].text = "Использовать";
            text[2].text = "Использовать";

            buttons[0].interactable = true;
            buttons[1].interactable = true;
            buttons[2].interactable = true;
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 500 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            text[0].text = "Использовать";
            text[1].text = "Использовать";
            text[2].text = "Недоступен";

            buttons[0].interactable = true;
            buttons[1].interactable = true;
            buttons[2].interactable = false;
        }
        else
        {
            text[0].text = "Использовать";
            text[1].text = "Недоступен";
            text[2].text = "Недоступен";

            buttons[0].interactable = true;
            buttons[1].interactable = false;
            buttons[2].interactable = false;
        }
        
        if(Progress.Instance.PlayerInfoForSave.checkedVideo != 10)
        {
            text[3].text = $"{Progress.Instance.PlayerInfoForSave.checkedVideo} / 10"; 
        }
        else
        {
            text[3].text = "Использовать";
        }
    }

    public void Checked01(bool value)
    {
        if(value)
        {
            text[5].text = "Использовать";
            Progress.Instance.buy01 = true;
        }
        else
        {
            text[5].text = "105 Ян";
        }
    }

    public void Checked02(bool value)
    {
        if (value)
        {
            text[6].text = "Использовать";
            Progress.Instance.buy02 = true;
        }
        else
        {
            text[6].text = "750 Ян";
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
            text[2].text = "Использовать";
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
