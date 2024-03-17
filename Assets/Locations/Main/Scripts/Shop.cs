using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class Shop : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void buyItem01();

    [DllImport("__Internal")]
    private static extern void buyItem02();

    [DllImport("__Internal")]
    private static extern void checkedItem();

    [DllImport("__Internal")]
    private static extern void checkedItemConsume();

    [DllImport("__Internal")]
    private static extern void ShowAdWithRewardPet();

    [SerializeField] private Button[] buttons;
    [SerializeField] private TextMeshProUGUI[] text;

    [SerializeField] private InitPets initPets;
    [SerializeField] private TextMeshProUGUI[] names;

    [SerializeField] private GameObject AdBar;

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
        if (Progress.Instance.PlayerInfoForSave.lan == 2)
        {
            names[0].text = "Turtle";
            names[1].text = "Rabbit";
            names[2].text = "Fox";
            names[3].text = "Badger";
            names[4].text = "Hedgehog";
            names[5].text = "Cat";
        }
        else
        {
            names[0].text = "Черепаха";
            names[1].text = "Кролик";
            names[2].text = "Лиса";
            names[3].text = "Борсук";
            names[4].text = "Ёжик";
            names[5].text = "Кот";
        }

        if(Progress.Instance.PlayerInfoForSave.lan == 2)
        {
            names[6].text = "105 Yan";
            names[7].text = "750 Yan";
        }
        else
        {
            names[6].text = "105 Ян";
            names[7].text = "750 Ян";
        }

        checkedItem();
    }

    // Methods for buttons

    public void InitializationShop()
    {
        if(Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            if (Progress.Instance.PlayerInfoForSave.lan == 1)
            {
                text[0].text = "Использовать";
                text[1].text = "Использовать";
                text[2].text = "Использовать";
            }
            else
            {
                text[0].text = "Use";
                text[1].text = "Use";
                text[2].text = "Use";
            }
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            if (Progress.Instance.PlayerInfoForSave.lan == 1)
            {
                text[0].text = "Использовать";
                text[1].text = "Использовать";
                text[2].text = "Недоступен";
            }
            else
            {
                text[0].text = "Use";
                text[1].text = "Use";
                text[2].text = "Unavailable";
            }
        }
        else
        {
            if (Progress.Instance.PlayerInfoForSave.lan == 1)
            {
                text[0].text = "Использовать";
                text[1].text = "Недоступен";
                text[2].text = "Недоступен";
            }
            else
            {
                text[0].text = "Use";
                text[1].text = "Unavailable";
                text[2].text = "Unavailable";
            }
        }
        
        if(Progress.Instance.PlayerInfoForSave.checkedVideo != 10)
        {
            text[3].text = $"{Progress.Instance.PlayerInfoForSave.checkedVideo} / 10"; 
        }
        else
        {
            AdBar.SetActive(false);

            if(Progress.Instance.PlayerInfoForSave.lan == 1)
                text[3].text = "Использовать";
            else
                text[3].text = "Use";
        }
    }

    public void Checked01()
    {
        if (Progress.Instance.PlayerInfoForSave.lan == 1)
            text[4].text = "Использовать";
        else
            text[4].text = "Use";

        Progress.Instance.buy01 = true;
    }

    public void Checked02()
    {
        if (Progress.Instance.PlayerInfoForSave.lan == 1)
            text[5].text = "Использовать";
        else
            text[5].text = "Use";

        Progress.Instance.buy02 = true;
    }

    public void One()
    {
        AudioObject.Instance.Click();
        Progress.Instance.PlayerInfoForSave.pet = 0;
        initPets.Delete();
        Progress.Instance.Save();
        GetComponent<Animator>().Play("ExitShop");
    }

    public void Two()
    {
        AudioObject.Instance.Click();
        if (Progress.Instance.PlayerInfoForSave.levels >= 100)
        {
            Progress.Instance.PlayerInfoForSave.pet = 1;
            initPets.Delete();
            Progress.Instance.Save();
            GetComponent<Animator>().Play("ExitShop");
        }
    }

    public void Three()
    {
        AudioObject.Instance.Click();
        if (Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            Progress.Instance.PlayerInfoForSave.pet = 2;
            initPets.Delete();
            Progress.Instance.Save();
            GetComponent<Animator>().Play("ExitShop");
        }
    }

    public void Four()
    {
        AudioObject.Instance.Click();
        if (Progress.Instance.PlayerInfoForSave.checkedVideo == 10)
        {
            AdBar.SetActive(false);

            if (Progress.Instance.PlayerInfoForSave.lan == 1)
                text[3].text = "Использовать";
            else
                text[3].text = "Use";

            Progress.Instance.PlayerInfoForSave.pet = 3;
            initPets.Delete();
            Progress.Instance.Save();
            GetComponent<Animator>().Play("ExitShop");
        }
        else
        {
            ShowAdWithRewardPet();
        }
    }

    public void Five()
    {
        AudioObject.Instance.Click();
        if (Progress.Instance.buy02)
        {
            Progress.Instance.PlayerInfoForSave.pet = 4;
            initPets.Delete();
            Progress.Instance.Save();
            GetComponent<Animator>().Play("ExitShop");
        }
        else
        {
            buyItem02();
        }
    }

    public void Six()
    {
        AudioObject.Instance.Click();
        if (Progress.Instance.buy01)
        {
            Progress.Instance.PlayerInfoForSave.pet = 5;
            initPets.Delete();
            Progress.Instance.Save();
            GetComponent<Animator>().Play("ExitShop");
        }
        else
        {
            buyItem01();
        }
    }

    public void EditText()
    {
        if (Progress.Instance.PlayerInfoForSave.checkedVideo != 10)
        {
            text[3].text = $"{Progress.Instance.PlayerInfoForSave.checkedVideo} / 10";
        }
        else
        {
            if (Progress.Instance.PlayerInfoForSave.lan == 1)
                text[3].text = "Использовать";
            else
                text[3].text = "Use";
        }

        Progress.Instance.Save();
    }
}