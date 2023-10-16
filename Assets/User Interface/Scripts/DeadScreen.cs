using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeadScreen : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;

    public GameObject deadScreen;

    public Button reloadButton;

    public void reloadButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void editText(int countLevel, int countEnemy, int countMoney)
    {
        textMeshProUGUI.text = "опнидемн щрюфеи: " + countLevel + "\nсахрн опнрхбмхйнб: " + countEnemy + "\nгюпюанрюммн лнмер: " + countMoney;
    }
}
