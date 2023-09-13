using UnityEngine;
using Leopotam.Ecs;

public class ChestTrigger : MonoBehaviour
{
    public EcsEntity entity;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material.color = new Color32(255, 230, 0, 255);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gameObject.GetComponentInParent<SpriteRenderer>().material.color = new Color32(0, 0, 0, 0);
        }
    }
}
