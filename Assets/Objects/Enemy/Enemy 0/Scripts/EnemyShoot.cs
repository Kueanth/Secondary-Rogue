using Leopotam.Ecs;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;

    public EcsEntity entity;

    private RaycastHit2D hit;

    public void StartAttack()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void Shoot()
    {
        if (target == null) return;

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
        hit = Physics2D.Raycast(transform.position + (target.position - transform.position).normalized, target.position);

        if (hit.collider.tag == "Walls and Decoration")
        {
            transform.GetComponent<Animator>().SetBool("Attack", false);
            Debug.Log("meow " + hit.collider.tag);
        }
        else
        {
            transform.GetComponent<Animator>().SetBool("Attack", true);
            Debug.Log("gow" + hit.collider.tag);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + (target.position - transform.position).normalized, target.position);
        Gizmos.DrawSphere(hit.point, 0.3f);
    }
}
