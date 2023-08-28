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
        ref EnemyData components = ref entity.Get<EnemyData>();

        bool tempBool = false;

        if (collision.gameObject.tag == "Bullet")
        {
            entity.Destroy();
            Destroy(gameObject);
            tempBool = true;
        }

        int temp = 0;

        if (!tempBool)
        {
            foreach (var i in components.targets)
            {
                if (i.gameObject.transform == collision.transform) ++temp;
            }
        }

        if (collision.gameObject.tag == "Check" && temp == 1)
        {
            entity.Get<EnemyNewFollow>();
        };
    }
}
