using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI buttons;
    [SerializeField] private TextMeshProUGUI text;

    public void Exit()
    {
        gameObject.GetComponent<Animator>().Play("ExitShop");
    }

    public void EndAnimation()
    {
        gameObject.SetActive(false);
    }
}
