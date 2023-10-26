using UnityEngine;

public class Character : MonoBehaviour
{
    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);
        movement.Normalize();

        GetComponent<Rigidbody2D>().velocity = movement * 5f;

        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
