using UnityEngine;

public class Character : MonoBehaviour
{
    private bool isEnter;
    private bool isLeaders;

    [SerializeField] private Animator Fade;

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        GetComponent<Rigidbody2D>().velocity = movement * 5f;

        if (Input.GetKeyDown(KeyCode.F) && isEnter)
        {
            Fade.SetTrigger("Enter");
            isEnter = false;
        }

        if(Input.GetKeyDown(KeyCode.F) && isLeaders)
        {
            // Empty
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Enter")
        {
            isEnter = true;
        }

        if(collision.name == "Leaders")
        {
            isLeaders = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Enter")
        {
            isEnter = false;
        }

        if (collision.name == "Leaders")
        {
            isLeaders = false;
        }
    }
}
