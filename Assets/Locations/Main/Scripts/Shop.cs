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
        else if(Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 500)
        {
            text[0].text = "Использовать";
            text[1].text = "Недоступен";
            text[2].text = "Недоступен";

            buttons[0].interactable = true;
            buttons[1].interactable = false;
            buttons[2].interactable = false;
        }
        else
        {
            text[0].text = "Недоступен";
            text[1].text = "Недоступен";
            text[2].text = "Недоступен";

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
            text[3].text = "Использовать";

            buttons[3].interactable = true;
        }
    }

    public void Checked01()
    {

    }

    public void Checked02()
    {

    }
}
