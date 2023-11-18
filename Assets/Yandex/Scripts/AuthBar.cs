using UnityEngine;

public class AuthBar : MonoBehaviour
{
    [SerializeField] private GameObject Player;

    public void Ep()
    {
        Progress.Instance.paused = true;
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Player.GetComponent<Animator>().SetBool("Paused", true);
        Player.GetComponent<Animator>().Play("Idle");
    }
    
    public void Gow()
    {
        Progress.Instance.paused = false;
        Player.GetComponent<Animator>().SetBool("Paused", false);
    }
}
