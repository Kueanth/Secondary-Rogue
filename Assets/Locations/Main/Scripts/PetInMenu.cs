using UnityEngine;

public class PetInMenu : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] private float speed;

    private bool active = true;

    public void Update()
    {
        if (active)
            gameObject.GetComponent<Rigidbody2D>().velocity = (target.position - gameObject.transform.position).normalized * speed;
        else
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Point")
            active = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Point")
            active = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Point")
            active = false;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Point")
            active = true;
    }
}
