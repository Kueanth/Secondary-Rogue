using UnityEngine;
using TMPro;

public class AuthPlayerBarLan : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private void Open()
    {
        if(Progress.Instance.PlayerInfoForSave.lan == 2)
        {
            text.text = "Auth";
        }
        else
        {
            text.text = "Авторизация";
        }
    }
}
