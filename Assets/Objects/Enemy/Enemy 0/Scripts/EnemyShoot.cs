using Leopotam.Ecs;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public LayerMask detected;
    public EcsEntity entityPlayer;
    public EcsEntity entity;

    private RaycastHit2D hit;

    public void StartAttack()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void Shoot()
    {
        ref Player componentsPlayer = ref entityPlayer.Get<Player>();

        if (target == null || componentsPlayer.pit) return;

        Vector3 diference = target.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ - 90f);

        GameObject bulletObject = Instantiate(bullet, transform.position, rotation);


        bulletObject.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 10f;

        Destroy(bulletObject, 10);
    }

    public void EndAttack()
    {
        entity.Get<EnemyNewFollow>();
        transform.GetComponent<Animator>().SetBool("Attack", false);
    }

    public void Check()
    {
        if (target != null)
            hit = Physics2D.Raycast(transform.position + (target.position - transform.position).normalized, target.position - transform.position - (target.position - transform.position).normalized, Vector3.Distance(target.position, transform.position) - 2f, detected.value);
        else return;

        if (hit.collider == null)
        {
            return;
        }   
        if (hit.collider.tag == "Walls and Decoration")
        {
            transform.GetComponent<Animator>().SetBool("Attack", false);
        }
    }
}
