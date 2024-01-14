using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class Character : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void AskSetLeaderboardScore(string rawNameStr);

    private bool isEnter;
    private bool isShop;
    private bool isLeaders;

    private bool running;
    private bool flipping;

    [SerializeField] private Animator Fade;
    [SerializeField] private Animator CharacterAnimator;
    [SerializeField] private SpriteRenderer CharacterSR;
    [SerializeField] private Texture2D CursorImage;
    [SerializeField] private GameObject FadeObject;
    [SerializeField] private GameObject LeadersObject;
    [SerializeField] private GameObject ShopObject;
    [SerializeField] private Animator AuthBar;

    [SerializeField] private Transform pointForPet;
    [SerializeField] public SpriteRenderer Pet;

    [SerializeField] private InitYandex initYandex;

    public void Start()
    {
        Cursor.SetCursor(CursorImage, Vector2.zero, CursorMode.Auto);

        if(Progress.Instance.PlayerInfoForGame.auth) Progress.Instance.InfoInit();
    }

    public void Update()
    {
        if (!Progress.Instance.paused)
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
                Pet.GetComponent<Animator>().SetBool("Speed", true);
            }
            else if (horizontal <= -0.2f)
            {
                running = true;
                flipping = true;
                Pet.GetComponent<Animator>().SetBool("Speed", true);
            }
            else
            {
                if (vertical >= 0.2f)
                {
                    running = true;
                    Pet.GetComponent<Animator>().SetBool("Speed", true);
                }
                else if (vertical <= -0.2f)
                {
                    running = true;
                    Pet.GetComponent<Animator>().SetBool("Speed", true);
                }
                else
                {
                    running = false;
                    Pet.GetComponent<Animator>().SetBool("Speed", false);
                }
            }

            // Set bool for animator
            if (running)

                CharacterAnimator.SetBool("Running", true);
            else
                CharacterAnimator.SetBool("Running", false);

            if (Pet.transform.position.x > gameObject.transform.position.x)
                Pet.flipX = true;
            else
                Pet.flipX = false;

            // flipping character
            if (flipping)
            {
                CharacterSR.flipX = true;
                pointForPet.localPosition = new Vector2(0.8f, -0.3f);
            }
            else if (!flipping)
            {
                CharacterSR.flipX = false;
                pointForPet.localPosition = new Vector2(-0.8f, -0.3f);  
            }

            if (Input.GetKeyDown(KeyCode.F) && isEnter)
            {
                FadeObject.transform.SetAsLastSibling();
                Progress.Instance.enter = true;
                Fade.SetTrigger("Meow");
                isEnter = false;
            }

            if (Input.GetKeyDown(KeyCode.F) && isLeaders)
            {
                if (Progress.Instance.PlayerInfoForGame.auth)
                {
                    LeadersObject.SetActive(true);
                    AskSetLeaderboardScore("levels");
                }
                else
                {
                    AuthBar.Play("OpenAuthBar");
                }
            }

            if (Input.GetKeyDown(KeyCode.F) && isShop)
            {
                if (Progress.Instance.PlayerInfoForGame.auth)
                {
                    ShopObject.SetActive(true);
                }
                else
                {
                    AuthBar.Play("OpenAuthBar");
                }
            }
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

        if(collision.name == "NPC")
        {
            isShop = true;
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

        if (collision.name == "NPC")
        {
            isShop = false;
        }

    }
}
