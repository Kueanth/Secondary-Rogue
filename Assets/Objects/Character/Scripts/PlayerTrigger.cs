using UnityEngine;
using Leopotam.Ecs;

public class PlayerTrigger : MonoBehaviour
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

        if (collider.gameObject.tag == "Pit")
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
