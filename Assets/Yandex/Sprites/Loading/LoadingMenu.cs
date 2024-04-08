using UnityEngine;
using TMPro;

public class LoadingMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 2)
            loadingText.text = "Loading";
        else
            loadingText.text = "Загрузка";
    }
}
