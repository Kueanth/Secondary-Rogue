using UnityEngine;

public class Rating : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Exit()
    {
        animator.SetTrigger("end");
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
