using UnityEngine;

public class EnemyBulletTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Walls and Decoration")
        {
            Destroy(gameObject);
        }

        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
