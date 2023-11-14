using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Character : MonoBehaviour
{
    private bool isEnter;
    private bool isLeaders;

    private bool running;
    private bool flipping;

    [SerializeField] private Animator Fade;
    [SerializeField] private Animator CharacterAnimator;
    [SerializeField] private SpriteRenderer CharacterSR;
    [SerializeField] private Texture2D CursorImage;

    public void Start()
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.Auto);
        Progress.Instance.InfoInit();
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        GetComponent<Rigidbody2D>().velocity = movement * 5f;

        if (horizontal >= 0.2f)
        {
            running = true;
            flipping = false;
        }
        else if (horizontal <= -0.2f)
        {
            running = true;
            flipping = true;
        }
        else
        {
            if (vertical >= 0.2f)
            {
                running = true;
            }
            else if(vertical <= -0.2f)
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
            Fade.SetTrigger("Meow");
            isEnter = false;
        }

        if(Input.GetKeyDown(KeyCode.F) && isLeaders)
        {
            ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Enter")
        {
            isEnter = true;
        }

        if(collision.name == "Sign")
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

        if (collision.name == "Sign")
        {
            isLeaders = false;
        }
    }
}
