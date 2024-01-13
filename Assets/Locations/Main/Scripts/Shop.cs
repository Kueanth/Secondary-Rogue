using UnityEngine;

public class Shop : MonoBehaviour
{
    public void Exit()
    {
        gameObject.GetComponent<Animator>().Play("ExitShop");
    }

    public void EndAnimation()
    {
        gameObject.SetActive(false);
    }
}
