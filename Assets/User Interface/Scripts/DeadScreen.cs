using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Collections;

public class DeadScreen : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public Image fade;

    public PlayerTrigger playerTrigger;

    [SerializeField] GameObject player;
    [SerializeField] private GameObject loading;

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
        StartCoroutine(enumerator());

#if UNITY_WEBGL && !UNITY_EDITOR
        ShowAdWithReward();
#endif 
    }

    public void editText(int countLevel, int countEnemy, int countMoney)
    {
        textMeshProUGUI.text = "œ–Œ…ƒ≈ÕŒ ›“¿∆≈…: " + countLevel + "\n”¡»“Œ œ–Œ“»¬Õ» Œ¬: " + countEnemy + "\n«¿–¿¡Œ“¿ÕÕŒ ÃŒÕ≈“: " + countMoney;
    }

    IEnumerator enumerator()
    {
        loading.SetActive(true);

        yield return new WaitForSeconds(1f);

        loading.SetActive(false);

        yield break;
    }
}
