using UnityEngine;

public class Character : MonoBehaviour
{
    private bool isEnter;
    private bool isLeaders;

    private bool running;
    private bool flipping;

    [SerializeField] private Animator Fade;
    [SerializeField] private Animator CharacterAnimator;
    [SerializeField] private SpriteRenderer CharacterSR;

    public void Start()
    {
        Cursor.visible = true;
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        GetComponent<Rigidbody2D>().velocity = movement * 5f;

        if (vertical >= 0.2f || vertical <= -0.2f)
        {
            running = true;
        }

        if (horizontal >= 0.2f)
        {
            running = true;
        }
        else if (horizontal <= -0.2f)
        {
            running = true;
        }
        else
        {
            if (vertical >= 0.2f || vertical <= -0.2f)
            {
                running = true;
            }
            else
            {
                running = false;
            }
        }

        // Set bool for animator
        if (running)

            CharacterAnimator.SetBool("Running", true);
        else
            CharacterAnimator.SetBool("Running", false);

        Vector3 positionPlayer = gameObject.transform.position;
        Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition) - gameObject.transform.position;

        // A great code for the correct rotation of the character
        if (positionMouse.x < 0)
        {
            flipping = true;
        }
        else
        {
            flipping = false;
        }

        // flipping character
        if (flipping)
        {
            CharacterSR.flipX = true;

        }
        else if (!flipping)
        {
            CharacterSR.flipX = false;
        }

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
