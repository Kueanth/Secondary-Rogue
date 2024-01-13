using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using System.Collections;

public class DeadScreen : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI textMeshProUGUI1;
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

    public void editText(int countLevel, int record)
    {
        textMeshProUGUI.text = "опнидемн щрюфеи: " + countLevel;
        textMeshProUGUI1.text = "пейнпд: " + record;
    }

    IEnumerator enumerator()
    {
        loading.SetActive(true);

        yield return new WaitForSeconds(1f);

        loading.SetActive(false);

        yield break;
    }
}
