using UnityEngine;
using Leopotam.Ecs;

public class EnemyTrigger : MonoBehaviour
{
    public EcsEntity entity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls and Decoration")
        {
            entity.Get<EnemyNewFollow>();
        };
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Check")
        {
            entity.Get<EnemyNewFollow>();
        };
    }
}
