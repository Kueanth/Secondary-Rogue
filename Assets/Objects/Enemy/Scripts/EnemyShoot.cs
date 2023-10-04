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

        ref EnemyData componentsEnemy = ref entity.Get<EnemyData>();

        switch (componentsEnemy.name)
        {
            case "Enemy-0":
                GameObject bulletObject = Instantiate(bullet, transform.position, rotation);
                bulletObject.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 10f;
                Destroy(bulletObject, 10);
                break;

            case "Enemy-1":
                GameObject bulletObject1 = Instantiate(bullet, transform.position, rotation);
                bulletObject1.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 10f;

                GameObject bulletObject2 = Instantiate(bullet, transform.position, rotation);
                bulletObject2.GetComponent<Rigidbody2D>().velocity = 
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 10f;

                GameObject bulletObject3 = Instantiate(bullet, transform.position, rotation);
                bulletObject3.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 10f;

                Destroy(bulletObject1, 10);
                Destroy(bulletObject2, 10);
                Destroy(bulletObject3, 10);
                break;

            case "Enemy-2":
                GameObject bulletObject4 = Instantiate(bullet, transform.position, rotation);
                bulletObject4.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 13f;

                GameObject bulletObject5 = Instantiate(bullet, transform.position, rotation);
                bulletObject5.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 13f;

                GameObject bulletObject6 = Instantiate(bullet, transform.position, rotation);
                bulletObject6.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 13f;

                GameObject bulletObject7 = Instantiate(bullet, transform.position, rotation);
                bulletObject7.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 10f;

                GameObject bulletObject8 = Instantiate(bullet, transform.position, rotation);
                bulletObject8.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 10f;

                GameObject bulletObject9 = Instantiate(bullet, transform.position, rotation);
                bulletObject9.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 10f;

                Destroy(bulletObject4, 10);
                Destroy(bulletObject5, 10);
                Destroy(bulletObject6, 10);
                Destroy(bulletObject7, 10);
                Destroy(bulletObject8, 10);
                Destroy(bulletObject9, 10);
                break;

            case "Enemy-3":
                GameObject bulletObject10 = Instantiate(bullet, transform.position, rotation);
                bulletObject10.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 10f;

                GameObject bulletObject11 = Instantiate(bullet, transform.position, rotation);
                bulletObject11.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 10f;

                GameObject bulletObject12 = Instantiate(bullet, transform.position, rotation);
                bulletObject12.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 10f;

                GameObject bulletObject13 = Instantiate(bullet, transform.position, rotation);
                bulletObject13.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 10f;

                GameObject bulletObject14 = Instantiate(bullet, transform.position, rotation);
                bulletObject14.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 10f;

                Destroy(bulletObject10, 10);
                Destroy(bulletObject11, 10);
                Destroy(bulletObject12, 10);
                Destroy(bulletObject13, 10);
                Destroy(bulletObject14, 10);
                break;

            case "Enemy-4":
                GameObject bulletObject15 = Instantiate(bullet, transform.position, rotation);
                bulletObject15.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 11f;

                GameObject bulletObject16 = Instantiate(bullet, transform.position, rotation);
                bulletObject16.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 11f;

                GameObject bulletObject17 = Instantiate(bullet, transform.position, rotation);
                bulletObject17.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 11f;

                GameObject bulletObject18 = Instantiate(bullet, transform.position, rotation);
                bulletObject18.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 11f;

                GameObject bulletObject19 = Instantiate(bullet, transform.position, rotation);
                bulletObject19.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 11f;

                Destroy(bulletObject15, 10);
                Destroy(bulletObject16, 10);
                Destroy(bulletObject17, 10);
                Destroy(bulletObject18, 10);
                Destroy(bulletObject19, 10);

                GameObject bulletObject20 = Instantiate(bullet, transform.position, rotation);
                bulletObject20.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 8f;

                GameObject bulletObject21 = Instantiate(bullet, transform.position, rotation);
                bulletObject21.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 8f;

                GameObject bulletObject22 = Instantiate(bullet, transform.position, rotation);
                bulletObject22.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 8f;

                GameObject bulletObject23 = Instantiate(bullet, transform.position, rotation);
                bulletObject23.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 8f;

                GameObject bulletObject24 = Instantiate(bullet, transform.position, rotation);
                bulletObject24.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 8f;

                Destroy(bulletObject20, 10);
                Destroy(bulletObject21, 10);
                Destroy(bulletObject22, 10);
                Destroy(bulletObject23, 10);
                Destroy(bulletObject24, 10);
                break;

            case "Enemy-5":
                GameObject bulletObject25 = Instantiate(bullet, transform.position, rotation);
                bulletObject25.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 8f;

                GameObject bulletObject26 = Instantiate(bullet, transform.position, rotation);
                bulletObject26.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 8f;

                GameObject bulletObject27 = Instantiate(bullet, transform.position, rotation);
                bulletObject27.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 8f;

                GameObject bulletObject28 = Instantiate(bullet, transform.position, rotation);
                bulletObject28.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 8f;

                GameObject bulletObject29 = Instantiate(bullet, transform.position, rotation);
                bulletObject29.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 8f;

                GameObject bulletObject30 = Instantiate(bullet, transform.position, rotation);
                bulletObject30.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 6f) - transform.position).normalized * 8f;

                GameObject bulletObject31 = Instantiate(bullet, transform.position, rotation);
                bulletObject31.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 6f) - transform.position).normalized * 8f;

                Destroy(bulletObject25, 10);
                Destroy(bulletObject26, 10);
                Destroy(bulletObject27, 10);
                Destroy(bulletObject28, 10);
                Destroy(bulletObject29, 10);
                Destroy(bulletObject30, 10);
                Destroy(bulletObject31, 10);
                break;

            case "Enemy-6":
                GameObject bulletObject32 = Instantiate(bullet, transform.position, rotation);
                bulletObject32.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 6f;

                GameObject bulletObject33 = Instantiate(bullet, transform.position, rotation);
                bulletObject33.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 6f;

                GameObject bulletObject34 = Instantiate(bullet, transform.position, rotation);
                bulletObject34.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 6f;

                GameObject bulletObject35 = Instantiate(bullet, transform.position, rotation);
                bulletObject35.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 6f;

                GameObject bulletObject36 = Instantiate(bullet, transform.position, rotation);
                bulletObject36.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 6f;

                GameObject bulletObject37 = Instantiate(bullet, transform.position, rotation);
                bulletObject37.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 6f) - transform.position).normalized * 6f;

                GameObject bulletObject38 = Instantiate(bullet, transform.position, rotation);
                bulletObject38.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 6f) - transform.position).normalized * 6f;

                Destroy(bulletObject32, 10);
                Destroy(bulletObject33, 10);
                Destroy(bulletObject34, 10);
                Destroy(bulletObject35, 10);
                Destroy(bulletObject36, 10);
                Destroy(bulletObject37, 10);
                Destroy(bulletObject38, 10);

                GameObject bulletObject39 = Instantiate(bullet, transform.position, rotation);
                bulletObject39.GetComponent<Rigidbody2D>().velocity = (target.position - transform.position).normalized * 8f;

                GameObject bulletObject40 = Instantiate(bullet, transform.position, rotation);
                bulletObject40.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 2f) - transform.position).normalized * 8f;

                GameObject bulletObject41 = Instantiate(bullet, transform.position, rotation);
                bulletObject41.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 2f) - transform.position).normalized * 8f;

                GameObject bulletObject42 = Instantiate(bullet, transform.position, rotation);
                bulletObject42.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 8f;

                GameObject bulletObject43 = Instantiate(bullet, transform.position, rotation);
                bulletObject43.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 8f;

                GameObject bulletObject44 = Instantiate(bullet, transform.position, rotation);
                bulletObject44.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y - 4f) - transform.position).normalized * 8f;

                GameObject bulletObject45 = Instantiate(bullet, transform.position, rotation);
                bulletObject45.GetComponent<Rigidbody2D>().velocity =
                    (new Vector3(target.position.x, target.position.y + 4f) - transform.position).normalized * 8f;

                Destroy(bulletObject39, 10);
                Destroy(bulletObject40, 10);
                Destroy(bulletObject41, 10);
                Destroy(bulletObject42, 10);
                Destroy(bulletObject43, 10);
                Destroy(bulletObject44, 10);
                Destroy(bulletObject45, 10);
                break;
        }
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
            entity.Get<EnemyNewFollow>();
            transform.GetComponent<Animator>().SetBool("Attack", false);
        }
    }
}
