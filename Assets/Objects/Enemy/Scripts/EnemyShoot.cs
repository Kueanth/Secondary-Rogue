using Leopotam.Ecs;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform target;
    public LayerMask detected;
    public EcsEntity entityPlayer;
    public EcsEntity entity;

    public SceneData sceneData;

    private RaycastHit2D hit;

    public void StartAttack()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void Shoot()
    {
        if (sceneData.paused) return;

        ref Player componentsPlayer = ref entityPlayer.Get<Player>();

        if (target == null || componentsPlayer.pit) return;

        Vector3 diference = target.position - transform.position;
        float rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotateZ - 90f);

        ref EnemyData componentsEnemy = ref entity.Get<EnemyData>();

        AudioObject.Instance.Shoot();

        switch (componentsEnemy.name)
        {
            case "Enemy-0":
                GameObject bulletObject = Instantiate(bullet, transform.position, rotation);
                bulletObject.GetComponent<Rigidbody2D>().velocity = bulletObject.transform.up * 13f;
                Destroy(bulletObject, 10);
                break;

            case "Enemy-1":
                GameObject bulletObject1 = Instantiate(bullet, transform.position, rotation);
                bulletObject1.GetComponent<Rigidbody2D>().velocity = bulletObject1.transform.up * 13f;

                Quaternion rotation2 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject2 = Instantiate(bullet, transform.position, rotation2);
                bulletObject2.GetComponent<Rigidbody2D>().velocity =
                    bulletObject2.transform.up * 13f;

                Quaternion rotation3 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject3 = Instantiate(bullet, transform.position, rotation3);
                bulletObject3.GetComponent<Rigidbody2D>().velocity =
                    bulletObject3.transform.up * 13f;

                Destroy(bulletObject1, 10);
                Destroy(bulletObject2, 10);
                Destroy(bulletObject3, 10);
                break;

            case "Enemy-2":
                GameObject bulletObject4 = Instantiate(bullet, transform.position, rotation);
                bulletObject4.GetComponent<Rigidbody2D>().velocity = bulletObject4.transform.up * 15f;

                Quaternion rotation5 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject5 = Instantiate(bullet, transform.position, rotation5);
                bulletObject5.GetComponent<Rigidbody2D>().velocity =
                    bulletObject5.transform.up * 15f;

                Quaternion rotation6 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject6 = Instantiate(bullet, transform.position, rotation6);
                bulletObject6.GetComponent<Rigidbody2D>().velocity =
                    bulletObject6.transform.up * 15f;

                GameObject bulletObject7 = Instantiate(bullet, transform.position, rotation);
                bulletObject7.GetComponent<Rigidbody2D>().velocity = bulletObject7.transform.up * 13f;

                Quaternion rotation8 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject8 = Instantiate(bullet, transform.position, rotation8);
                bulletObject8.GetComponent<Rigidbody2D>().velocity =
                    bulletObject8.transform.up * 13f;

                Quaternion rotation9 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject9 = Instantiate(bullet, transform.position, rotation9);
                bulletObject9.GetComponent<Rigidbody2D>().velocity =
                    bulletObject9.transform.up * 13f;

                Destroy(bulletObject4, 10);
                Destroy(bulletObject5, 10);
                Destroy(bulletObject6, 10);
                Destroy(bulletObject7, 10);
                Destroy(bulletObject8, 10);
                Destroy(bulletObject9, 10);
                break;

            case "Enemy-3":
                GameObject bulletObject10 = Instantiate(bullet, transform.position, rotation);
                bulletObject10.GetComponent<Rigidbody2D>().velocity = bulletObject10.transform.up * 13f;

                Quaternion rotation11 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject11 = Instantiate(bullet, transform.position, rotation11);
                bulletObject11.GetComponent<Rigidbody2D>().velocity =
                    bulletObject11.transform.up * 13f;

                Quaternion rotation12 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject12 = Instantiate(bullet, transform.position, rotation12);
                bulletObject12.GetComponent<Rigidbody2D>().velocity =
                    bulletObject12.transform.up * 13f;

                Quaternion rotation13 = Quaternion.Euler(0f, 0f, rotateZ - 110f);
                GameObject bulletObject13 = Instantiate(bullet, transform.position, rotation13);
                bulletObject13.GetComponent<Rigidbody2D>().velocity =
                    bulletObject13.transform.up * 13f;

                Quaternion rotation14 = Quaternion.Euler(0f, 0f, rotateZ - 70f);
                GameObject bulletObject14 = Instantiate(bullet, transform.position, rotation14);
                bulletObject14.GetComponent<Rigidbody2D>().velocity =
                    bulletObject14.transform.up * 13f;

                Destroy(bulletObject10, 10);
                Destroy(bulletObject11, 10);
                Destroy(bulletObject12, 10);
                Destroy(bulletObject13, 10);
                Destroy(bulletObject14, 10);
                break;

            case "Enemy-4":
                GameObject bulletObject15 = Instantiate(bullet, transform.position, rotation);
                bulletObject15.GetComponent<Rigidbody2D>().velocity = bulletObject15.transform.up * 14f;

                Quaternion rotation16 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject16 = Instantiate(bullet, transform.position, rotation16);
                bulletObject16.GetComponent<Rigidbody2D>().velocity =
                    bulletObject16.transform.up * 14f;

                Quaternion rotation17 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject17 = Instantiate(bullet, transform.position, rotation17);
                bulletObject17.GetComponent<Rigidbody2D>().velocity =
                    bulletObject17.transform.up * 14f;

                Quaternion rotation18 = Quaternion.Euler(0f, 0f, rotateZ - 110f);
                GameObject bulletObject18 = Instantiate(bullet, transform.position, rotation18);
                bulletObject18.GetComponent<Rigidbody2D>().velocity =
                    bulletObject18.transform.up * 14f;

                Quaternion rotation19 = Quaternion.Euler(0f, 0f, rotateZ - 70f);
                GameObject bulletObject19 = Instantiate(bullet, transform.position, rotation19);
                bulletObject19.GetComponent<Rigidbody2D>().velocity =
                    bulletObject19.transform.up * 14f;

                Destroy(bulletObject15, 10);
                Destroy(bulletObject16, 10);
                Destroy(bulletObject17, 10);
                Destroy(bulletObject18, 10);
                Destroy(bulletObject19, 10);

                GameObject bulletObject20 = Instantiate(bullet, transform.position, rotation);
                bulletObject20.GetComponent<Rigidbody2D>().velocity = bulletObject20.transform.up * 10f;

                Quaternion rotation21 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject21 = Instantiate(bullet, transform.position, rotation21);
                bulletObject21.GetComponent<Rigidbody2D>().velocity =
                    bulletObject21.transform.up * 10f;

                Quaternion rotation22 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject22 = Instantiate(bullet, transform.position, rotation22);
                bulletObject22.GetComponent<Rigidbody2D>().velocity =
                    bulletObject22.transform.up * 10f;

                Quaternion rotation23 = Quaternion.Euler(0f, 0f, rotateZ - 110f);
                GameObject bulletObject23 = Instantiate(bullet, transform.position, rotation23);
                bulletObject23.GetComponent<Rigidbody2D>().velocity =
                    bulletObject23.transform.up * 10f;

                Quaternion rotation24 = Quaternion.Euler(0f, 0f, rotateZ - 70f);
                GameObject bulletObject24 = Instantiate(bullet, transform.position, rotation24);
                bulletObject24.GetComponent<Rigidbody2D>().velocity =
                    bulletObject24.transform.up * 10f;

                Destroy(bulletObject20, 10);
                Destroy(bulletObject21, 10);
                Destroy(bulletObject22, 10);
                Destroy(bulletObject23, 10);
                Destroy(bulletObject24, 10);
                break;

            case "Enemy-5":
                GameObject bulletObject25 = Instantiate(bullet, transform.position, rotation);
                bulletObject25.GetComponent<Rigidbody2D>().velocity = bulletObject25.transform.up * 10f;

                Quaternion rotation26 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject26 = Instantiate(bullet, transform.position, rotation26);
                bulletObject26.GetComponent<Rigidbody2D>().velocity =
                    bulletObject26.transform.up * 10f;

                Quaternion rotation27 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject27 = Instantiate(bullet, transform.position, rotation27);
                bulletObject27.GetComponent<Rigidbody2D>().velocity =
                    bulletObject27.transform.up * 10f;

                Quaternion rotation28 = Quaternion.Euler(0f, 0f, rotateZ - 110f);
                GameObject bulletObject28 = Instantiate(bullet, transform.position, rotation28);
                bulletObject28.GetComponent<Rigidbody2D>().velocity =
                    bulletObject28.transform.up * 10f;

                Quaternion rotation29 = Quaternion.Euler(0f, 0f, rotateZ - 70f);
                GameObject bulletObject29 = Instantiate(bullet, transform.position, rotation29);
                bulletObject29.GetComponent<Rigidbody2D>().velocity =
                    bulletObject29.transform.up * 10f;

                Quaternion rotation30 = Quaternion.Euler(0f, 0f, rotateZ - 120f);
                GameObject bulletObject30 = Instantiate(bullet, transform.position, rotation30);
                bulletObject30.GetComponent<Rigidbody2D>().velocity =
                    bulletObject30.transform.up * 10f;

                Quaternion rotation31 = Quaternion.Euler(0f, 0f, rotateZ - 60f);
                GameObject bulletObject31 = Instantiate(bullet, transform.position, rotation31);
                bulletObject31.GetComponent<Rigidbody2D>().velocity =
                    bulletObject31.transform.up * 10f;

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
                bulletObject32.GetComponent<Rigidbody2D>().velocity = bulletObject32.transform.up * 9f;

                Quaternion rotation33 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject33 = Instantiate(bullet, transform.position, rotation33);
                bulletObject33.GetComponent<Rigidbody2D>().velocity =
                    bulletObject33.transform.up * 9f;

                Quaternion rotation34 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject34 = Instantiate(bullet, transform.position, rotation34);
                bulletObject34.GetComponent<Rigidbody2D>().velocity =
                    bulletObject34.transform.up * 9f;

                Quaternion rotation35 = Quaternion.Euler(0f, 0f, rotateZ - 110f);
                GameObject bulletObject35 = Instantiate(bullet, transform.position, rotation35);
                bulletObject35.GetComponent<Rigidbody2D>().velocity =
                    bulletObject35.transform.up * 9f;

                Quaternion rotation36 = Quaternion.Euler(0f, 0f, rotateZ - 70f);
                GameObject bulletObject36 = Instantiate(bullet, transform.position, rotation36);
                bulletObject36.GetComponent<Rigidbody2D>().velocity =
                    bulletObject36.transform.up * 9f;

                Quaternion rotation37 = Quaternion.Euler(0f, 0f, rotateZ - 120f);
                GameObject bulletObject37 = Instantiate(bullet, transform.position, rotation37);
                bulletObject37.GetComponent<Rigidbody2D>().velocity =
                    bulletObject37.transform.up * 9f;

                Quaternion rotation38 = Quaternion.Euler(0f, 0f, rotateZ - 60f);
                GameObject bulletObject38 = Instantiate(bullet, transform.position, rotation38);
                bulletObject38.GetComponent<Rigidbody2D>().velocity =
                    bulletObject38.transform.up * 9f;

                Destroy(bulletObject32, 10);
                Destroy(bulletObject33, 10);
                Destroy(bulletObject34, 10);
                Destroy(bulletObject35, 10);
                Destroy(bulletObject36, 10);
                Destroy(bulletObject37, 10);
                Destroy(bulletObject38, 10);

                GameObject bulletObject39 = Instantiate(bullet, transform.position, rotation);
                bulletObject39.GetComponent<Rigidbody2D>().velocity = bulletObject39.transform.up * 11f;

                Quaternion rotation40 = Quaternion.Euler(0f, 0f, rotateZ - 100f);
                GameObject bulletObject40 = Instantiate(bullet, transform.position, rotation40);
                bulletObject40.GetComponent<Rigidbody2D>().velocity =
                    bulletObject40.transform.up * 11f;

                Quaternion rotation41 = Quaternion.Euler(0f, 0f, rotateZ - 80f);
                GameObject bulletObject41 = Instantiate(bullet, transform.position, rotation41);
                bulletObject41.GetComponent<Rigidbody2D>().velocity =
                    bulletObject41.transform.up * 11f;

                Quaternion rotation42 = Quaternion.Euler(0f, 0f, rotateZ - 110f);
                GameObject bulletObject42 = Instantiate(bullet, transform.position, rotation42);
                bulletObject42.GetComponent<Rigidbody2D>().velocity =
                    bulletObject42.transform.up * 11f;

                Quaternion rotation43 = Quaternion.Euler(0f, 0f, rotateZ - 70f);
                GameObject bulletObject43 = Instantiate(bullet, transform.position, rotation43);
                bulletObject43.GetComponent<Rigidbody2D>().velocity =
                    bulletObject43.transform.up * 11f;

                Quaternion rotation44 = Quaternion.Euler(0f, 0f, rotateZ - 120f);
                GameObject bulletObject44 = Instantiate(bullet, transform.position, rotation44);
                bulletObject44.GetComponent<Rigidbody2D>().velocity =
                    bulletObject44.transform.up * 11f;

                Quaternion rotation45 = Quaternion.Euler(0f, 0f, rotateZ - 60f);
                GameObject bulletObject45 = Instantiate(bullet, transform.position, rotation45);
                bulletObject45.GetComponent<Rigidbody2D>().velocity =
                    bulletObject45.transform.up * 11f;

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
