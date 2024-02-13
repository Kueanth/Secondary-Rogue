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
        AudioObject.Instance.Click();
        if (!Progress.Instance.PlayerInfoForGame.auth)
            animator.Play("OpenAuthBar");
        else
            bar.SetActive(true);
    }

    public void Close()
    {
        bar.GetComponent<Animator>().Play("ProfileExit");
    } 

    public void Enter()
    {
        _name.text = Progress.Instance.PlayerInfoForGame.name;

        photo.texture = Progress.Instance.PlayerInfoForGame.icon;

        if (Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            if (Progress.Instance.PlayerInfoForSave.lan == 1)
                rating.text = "Ваша лига: золотая";
            else
                rating.text = "Your league: Golden";
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            if(Progress.Instance.PlayerInfoForSave.lan == 1)
                rating.text = "Ваша лига: серебряная";
            else
                rating.text = "Your league: Silver";
        }
        else
        {
            if(Progress.Instance.PlayerInfoForSave.lan == 1)
            rating.text = "Ваша лига: начальная";
            else
                rating.text = "Your league: Initial";
        }

        if (Progress.Instance.PlayerInfoForSave.levels >= 1000)
        {
            if(Progress.Instance.PlayerInfoForSave.lan == 1)
                description.text = "Вы находитесь на последней лиге";
            else
                description.text = "You are in the last league";
        }
        else if (Progress.Instance.PlayerInfoForSave.levels >= 100 && Progress.Instance.PlayerInfoForSave.levels < 1000)
        {
            if(Progress.Instance.PlayerInfoForSave.lan == 1)
            description.text = "До следующей лиги вам осталось пройти этажей: " + (1000 - Progress.Instance.PlayerInfoForSave.levels);
            else
                description.text = "You have only a few floors left to go to the next league: " + (1000 - Progress.Instance.PlayerInfoForSave.levels);
        }
        else
        {
            if (Progress.Instance.PlayerInfoForSave.lan == 1)
                description.text = "До следующей лиги вам осталось пройти этажей: " + (100 - Progress.Instance.PlayerInfoForSave.levels);
            else
                description.text = "You have only a few floors left to go to the next league: " + (100 - Progress.Instance.PlayerInfoForSave.levels);
        }
    }

    public void Exit()
    {
        bar.SetActive(false);
    }
}
