using UnityEngine;
using TMPro;

public class LoadingMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

    public void Start()
    {
        if (Progress.Instance.PlayerInfoForSave.lan == 2)
            loadingText.text = "Loading";
        else
            loadingText.text = "Загрузка";
    }
}
