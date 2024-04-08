using UnityEngine;
using TMPro;

public class Loading : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

    public void Start()
    {
        if (PlayerPrefs.GetInt("Language") == 2)
            loadingText.text = "Auth";
        else
            loadingText.text = "Авторизация";
    }
}
