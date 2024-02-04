using UnityEngine;

public class HelpBar : MonoBehaviour
{
    [SerializeField] private GameObject[] fields;
    [SerializeField] private GameObject bar;
    [SerializeField] private GameObject lan;
    [SerializeField] private Animator animator;

    private int index = -1;

    public void Next()
    {
        fields[index].SetActive(false);

        index++;

        if (index == 6)
            index = 0;

        fields[index].SetActive(true);
    }

    public void Back()
    {
        fields[index].SetActive(false);

        index--;

        if (index == -1)
            index = 5;

        fields[index].SetActive(true);
    }

    private void OnDisable()
    {
        index = -1;
    }

    public void Open()
    {
        if (Progress.Instance.PlayerInfoForSave.lan == 0)
            lan.SetActive(true);
        else
            bar.SetActive(true);
    }
    
    public void Exit()
    {
        bar.SetActive(false);
    }

    public void First()
    {
        index++;
        fields[index].SetActive(true);
    }

    public void Close()
    {
        animator.Play("HelpBarExit");
    }
}
