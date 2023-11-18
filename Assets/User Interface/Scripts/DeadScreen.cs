using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class DeadScreen : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public Image fade;

    [SerializeField] GameObject player;

    public GameObject deadScreen;

    public Button reloadButton;

    [DllImport("__Internal")]
    private static extern void ShowAdWithReward();

    public void reloadButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void exitButtonClick()
    {
        SceneManager.LoadScene(0);
    }

    public void resurrectionClick()
    { 
#if UNITY_WEBGL
        ShowAdWithReward();
#endif 
    }

    public void editText(int countLevel, int countEnemy, int countMoney)
    {
        textMeshProUGUI.text = "опнидемн щрюфеи: " + countLevel + "\nсахрн опнрхбмхйнб: " + countEnemy + "\nгюпюанрюммн лнмер: " + countMoney;
    }
}
