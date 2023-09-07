using UnityEngine;
using Leopotam.Ecs;

public class EnemyTrigger : MonoBehaviour
{
    public EcsEntity entity;

    public GameObject particle;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Walls and Decoration" || collision.gameObject.tag == "Table")
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
            if(components.hp != 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Get Attack");
                components.rigidbody2D.AddForce(new Vector2(-(collision.transform.position.x - transform.position.x), -(collision.transform.position.y - transform.position.y)).normalized * 2f, ForceMode2D.Impulse);
                components.hp -= 1;
            }   
            else
            {
                GameObject effect = Instantiate(particle, gameObject.transform);
                effect.transform.parent = null;
                gameObject.GetComponent<Animator>().SetTrigger("Get Attack");
                entity.Destroy();
                Destroy(gameObject);
                tempBool = true;
            }
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
