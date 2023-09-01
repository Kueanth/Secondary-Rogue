using UnityEngine;
using Leopotam.Ecs;

public class PlayerTrigger : MonoBehaviour
{
    public EcsEntity entity;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyBullet")
        {
            entity.Del<Player>();
            Destroy(gameObject);
        }
    }
}
