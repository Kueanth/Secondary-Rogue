using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Walls and Decoration")
        {
            Destroy(gameObject);
        }
    }
}
