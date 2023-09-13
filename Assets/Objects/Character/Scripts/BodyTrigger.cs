using UnityEngine;
using Leopotam.Ecs;

public class BodyTrigger : MonoBehaviour
{
    public EcsEntity entity;

    public void OnTriggerEnter2D(Collider2D collider)
    {
        ref Player components = ref entity.Get<Player>();

        if (collider.tag == "Chest")
        {
            components.nearChest = true;
            components.chest = collider.transform;
        }

        if (collider.gameObject.tag == "EnemyBullet")
        {
            if (components.hp != 0)
            {
                components.vignetteEffect.SetTrigger("Effect");
                components.hp -= 1;
            }
            else
            {
                entity.Del<Player>();
                Destroy(gameObject);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        ref Player components = ref entity.Get<Player>();

        if (collision.tag == "Chest")
        {
            components.nearChest = false;
        }
    }
}
