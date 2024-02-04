using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Profile : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI rating;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private RawImage photo;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject lan;
    [SerializeField] private GameObject bar;

    public void Open()
    {

        bar.SetActive(true);
    }

    public void Enter()
    {
        _name.text = Progress.Instance.PlayerInfoForGame.name;

        photo.texture = Progress.Instance.PlayerInfoForGame.icon;

        if (Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            rating.text = "Ваша лига: золотая";
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            rating.text = "Ваша лига: серебрянная";
        }
        else
        {
            rating.text = "Ваша лига: начальная";
        }

        if (Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            rating.text = "Вы находитесь на последней лиге";
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 500 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            rating.text = "До следующей лиги вам осталось пройти этажей: " + (1000 - Progress.Instance.PlayerInfoForSave.record);
        }
        else
        {
            rating.text = "До следующей лиги вам осталось пройти этажей: " + (100 - Progress.Instance.PlayerInfoForSave.record);
        }
    }

    public void Exit()
    {
        bar.SetActive(false);
    }
}
