using UnityEngine;
using Leopotam.Ecs;

public class BodyTrigger : MonoBehaviour
{
    public EcsEntity entity;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();

        if (collider.gameObject.tag == "EnemyBullet")
        {
            if (components.hp != 0)
            {
                components.hp -= 1;
            }
            else
            {
                entity.Del<Player>();
                Destroy(gameObject);
            }
        }
    }
}
